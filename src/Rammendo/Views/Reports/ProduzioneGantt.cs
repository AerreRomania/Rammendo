using Rammendo.Behaviors;
using Rammendo.Controls;
using Rammendo.Helpers;
using Rammendo.Models.ProduzioneGantt;
using Rammendo.ViewModels;
using Rammendo.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class ProduzioneGantt : CWindow
    {
        private readonly ProduzioneGanttViewModel _produzioneGanttViewModel;
        private readonly CaricoLavoroViewModel _caricoLavoroViewModel;
        private readonly Ganttogram _gntChart = new Ganttogram();
        private List<Bar> _gntChartBarsList = new List<Bar>();
        private List<Schedule> _lstSchedule = new List<Schedule>();
        
        public ProduzioneGantt(Panel parent) : base(true, parent)
        {
            InitializeComponent();
            _produzioneGanttViewModel = new ProduzioneGanttViewModel();
            _caricoLavoroViewModel = new CaricoLavoroViewModel();
            GenerateChildForm();

            CbArticolo.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            CbCommessa.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            CboFinezze.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            CbArticolo.SelectedIndexChanged += CbArticolo_SelectedIndexChanged;
            CbCommessa.SelectedIndexChanged += CbCommessa_SelectedIndexChanged;
            CboFinezze.SelectedIndexChanged += CboFinezze_SelectedIndexChanged;
            DgvCaricoLavoro.CellDoubleClick += DgvCaricoLavoro_CellDoubleClick;

            FillComboBoxes();
            AddGanttContextMenu();

            _gntChart.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(_gntChart);
            _gntChart.BringToFront();
            _gntChart.DoubleBuffered(true);
            _gntChart.MouseMove += _gntChart.Chart_MouseMove;
            _gntChart.DoubleClick += Gantt_DoubleClick;
            _gntChart.MouseClick += Gantt_MouseClick;

            _gntChart.FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-1);
            _gntChart.ToDate = _gntChart.FromDate.AddDays(+1);

            _gntChart.Refresh();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadScheduleTasks();
        }

        private void LoadScheduleTasks()
        {
            _lstSchedule = new List<Schedule>();
            var qry = @"
WITH cte_rammendo_production (operator, barcode, startDate, endDate, qty) AS (
   SELECT operator,barcode, 
		MIN(productionDate), 
		MAX(productionDate), 
		SUM(qty) FROM rammendoproduction
   GROUP BY operator,barcode
)

SELECT 
A.Id, A.Operator, A.Barcode, 
A.StartTime, A.EndTime,
B.startDate as ProductionStartTime,B.endDate ProductionEndTime,
A.DelayStartTime, A.DelayEndTime,
A.Qty as FixedQty, B.qty as ProdQty, A.CapiH, A.Line, A.Idx
FROM RammendoSchedule A
LEFT JOIN cte_rammendo_production B 
ON A.Barcode = B.barcode AND A.Operator = B.Operator
ORDER BY 
	LEN(A.Line), 
	A.Line,
	A.Operator,
    -- use idx value for sorting tasks by operator and line
    -- each operator and line combination will starts with 1 and then ++
    A.Idx;";

            try
            {
                using (var c = new SqlConnection(Central.CONNECTION_STRING))
                {
                    var cmd = new SqlCommand(qry, c);
                    c.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            int.TryParse(dr[0].ToString(), out var id);
                            DateTime.TryParse(dr[3].ToString(), out var start);
                            DateTime.TryParse(dr[4].ToString(), out var end);
                            DateTime.TryParse(dr[5].ToString(), out var prodStart);
                            DateTime.TryParse(dr[6].ToString(), out var prodEnd);
                            DateTime.TryParse(dr[7].ToString(), out var delayStart);
                            DateTime.TryParse(dr[8].ToString(), out var delayEnd);
                            int.TryParse(dr[9].ToString(), out var fixedQty);
                            int.TryParse(dr[10].ToString(), out var prodQty);

                            double.TryParse(dr[11].ToString(), out var capiH);
                            int.TryParse(dr[13].ToString(), out var idx);

                            _lstSchedule.Add(new Schedule(id, dr[1].ToString(), dr[2].ToString(),
                                start, end, prodStart, prodEnd, delayStart, delayEnd, fixedQty, prodQty, capiH,
                                dr[12].ToString(), idx));
                        }
                    c.Close();
                }

                _gntChart.Bars = new List<BarProperty>();
                _gntChart.HeaderList = new List<Header>();
                _gntChartBarsList = new List<Bar>();

                var name = _lstSchedule.Select(x => x.Operator).FirstOrDefault();
                var line = _lstSchedule.Select(x => x.Line).FirstOrDefault();
                var index = 0;
                foreach (var item in _lstSchedule)
                {
                    if (name != item.Operator || line != item.Line)
                    {
                        index++;
                    }
                    
                    //check if there is a gap and remove it     
                    var itemBefore = _lstSchedule.Where(x => x.Operator == item.Operator 
                        && x.Line == item.Line && x.Idx < item.Idx).LastOrDefault();

                    if (itemBefore != null )
                    {
                        var ticks = item.EndTime.Subtract(item.StartTime).Ticks;
                        var endTime = itemBefore.DelayEndTime > DateTime.MinValue ? itemBefore.DelayEndTime : itemBefore.EndTime;
                        item.StartTime = endTime;
                        item.EndTime = item.StartTime.AddTicks(ticks);
                    }

                    if (item.ProductionEndTime > item.EndTime)
                    {
                        //create delay if production endDate is greater programmed endDate
                        item.DelayStartTime = item.EndTime;
                        item.DelayEndTime = item.ProductionEndTime;
                    }

                    if (item.ProductionStartTime > DateTime.MinValue &&
                        item.ProductionStartTime < item.StartTime)
                    {
                        //check if productionStartDate start before programmed StartDate
                        item.ProductionStartTime = item.StartTime;
                    }

                    _gntChartBarsList.Add(new Bar(item.Operator,
                        item.StartTime,
                        item.EndTime,
                        Color.DarkCyan,
                        Color.SkyBlue,
                        item.ProductionStartTime,
                        item.ProductionEndTime,
                        item.DelayStartTime,
                        item.DelayEndTime,
                        item.Line,
                        index,
                        item.Id.ToString() + "_" + item.Barcode, 
                        item.FixedQty, item.ProdQty));

                    name = item.Operator;
                    line = item.Line;
                }

                foreach (var gntChartbar in _gntChartBarsList)
                {
                    _gntChart.AddBars(gntChartbar.RowText, gntChartbar.RowText + "_" + gntChartbar.Tag, gntChartbar,
                        gntChartbar.FromTime, gntChartbar.ToTime,
                        gntChartbar.ProdFromTime, gntChartbar.ProdToTime,
                        gntChartbar.DelayFromTime, gntChartbar.DelayToTime,
                        gntChartbar.Color, gntChartbar.HoverColor,
                        gntChartbar.Tag, gntChartbar.Index, gntChartbar.Department, 
                        gntChartbar.FixedQty, gntChartbar.ProductionQty);
                }

                _gntChart.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool _isDoubleClick;
        private void Gantt_DoubleClick(object sender, EventArgs e)
        {
            _isDoubleClick = true;
            if (_gntChart.MouseOverRowValue == null) return;
            var val = (Bar)_gntChart.MouseOverRowValue;

            var canManage = !(val.ProdFromTime > DateTime.MinValue && val.ProdToTime > DateTime.MinValue);

            var scheduleOrganizer = new ScheduleOrganizer(val.RowText, val.Department, val.FromTime, val.ToTime, 0, val.FixedQty, val.ProductionQty, canManage);
            scheduleOrganizer.ShowDialog();
            scheduleOrganizer.Dispose();
            LoadScheduleTasks();
            _isDoubleClick = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed)
            {                
                splitContainer1.Panel2Collapsed = false;
                button1.Text = "Close Carico Lavoro";
                button1.BackColor = Color.Crimson;
                CommessaDetails.CanProgram = true;

                if (DgvCaricoLavoro.DataSource == null)
                {
                    await LoadData();
                }
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                button1.Text = "Carico Lavoro";
                button1.BackColor = Color.DarkCyan;
            }
        }

        #region CaricoLavoro

        private async Task LoadData()
        {
            try
            {
                var article = CbArticolo.SelectedIndex > 0 ? CbArticolo.Text : null;
                var commessa = CbCommessa.SelectedIndex > 0 ? CbCommessa.Text : null;
                var fin = CboFinezze.SelectedIndex > 0 ? CboFinezze.Text : null;

                if (CbArticolo.SelectedIndex == -1) article = null;
                if (CbCommessa.SelectedIndex == -1) commessa = null;
                if (CboFinezze.SelectedIndex == -1) fin = null;

                var data = await _caricoLavoroViewModel.Data(article, commessa, fin);

                if (data != null)
                {
                    DgvCaricoLavoro.DataSource = data;
                    DgvCaricoLavoro.Rows[0].DefaultCellStyle.ForeColor = Color.OrangeRed;
                    DgvCaricoLavoro.Rows[0].DefaultCellStyle.SelectionForeColor = Color.OrangeRed;
                    DgvCaricoLavoro.Rows[0].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point);
                    DgvCaricoLavoro.Rows[0].DefaultCellStyle.BackColor = Color.MistyRose;
                    DgvCaricoLavoro.Rows[0].Height = 32;

                    DgvCaricoLavoro.Columns[0].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    DgvCaricoLavoro.Columns[0].DefaultCellStyle.SelectionForeColor = Color.Blue;

                    foreach (DataGridViewRow row in DgvCaricoLavoro.Rows)
                    {
                        if (row.Index <= 0) continue;

                        row.Cells[0].ToolTipText = "Perform double click for commessa details";
                    }
                }
                else
                {
                    MessageBox.Show("No data.",
                        this.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        private async void FillComboBoxes()
        {
            await _caricoLavoroViewModel.Data(null, null, null);

            CbArticolo.Items.Clear();
            CbCommessa.Items.Clear();
            CboFinezze.Items.Clear();
            CbArticolo.Items.Add("<Reset>");
            CbCommessa.Items.Add("<Reset>");
            CboFinezze.Items.Add("<Reset>");

            foreach (var item in _caricoLavoroViewModel.ListArticles)
            {
                CbArticolo.Items.Add(item);
            }
            foreach (var item in _caricoLavoroViewModel.ListCommesse)
            {
                CbCommessa.Items.Add(item);
            }
            foreach (var item in _caricoLavoroViewModel.ListFinezze)
            {
                CboFinezze.Items.Add(item);
            }
        }

        private async void CbArticolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbCommessa.SelectedIndex = -1;
            CboFinezze.SelectedIndex = -1;
            await LoadData();
        }

        private async void CbCommessa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbArticolo.SelectedIndex = -1;
            CboFinezze.SelectedIndex = -1;
            await LoadData();
        }

        private async void CboStagione_SelectedIndexChanged(object sender, EventArgs e)
        {

            CbArticolo.SelectedIndex = -1;
            CbCommessa.SelectedIndex = -1;
            CboFinezze.SelectedIndex = -1;
            await LoadData();
        }

        private async void CboFinezze_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbArticolo.SelectedIndex = -1;
            CbCommessa.SelectedIndex = -1;
            await LoadData();
        }

        private void DgvCaricoLavoro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 1) return;

            var commessa = DgvCaricoLavoro.Rows[e.RowIndex].Cells[0].Value.ToString();
            var article = DgvCaricoLavoro.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (e.ColumnIndex == 0)
            {
                var frm = new CommessaDetails(commessa, article);
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (DgvCaricoLavoro.DataSource != null) DgvCaricoLavoro.DataSource = null;
            await LoadData();
        }

        #endregion

        #region GanttControls

        private void button5_Click(object sender, EventArgs e)
        {
            _gntChart.FromDate = _gntChart.FromDate.AddDays(-1);
            _gntChart.ToDate = _gntChart.ToDate.AddDays(-1);
            _gntChart.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            _gntChart.FromDate = _gntChart.FromDate.AddDays(-7);
            _gntChart.ToDate = _gntChart.ToDate.AddDays(-7);
            _gntChart.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _gntChart.FromDate = _gntChart.FromDate.AddDays(+7);
            _gntChart.ToDate = _gntChart.ToDate.AddDays(+7);
            _gntChart.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _gntChart.FromDate = _gntChart.FromDate.AddDays(+1);
            _gntChart.ToDate = _gntChart.ToDate.AddDays(+1);
            _gntChart.Refresh();
        }

        private void AddGanttContextMenu()
        {
            var ctxMenuStrip = new ContextMenuStrip();
            ctxMenuStrip.RenderMode = ToolStripRenderMode.System;
            ctxMenuStrip.ImageScalingSize = new Size(20, 20);
            ctxMenuStrip.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            ToolStripMenuItem tsmi0 = new ToolStripMenuItem();
            
            tsmi0.Text = "Program";
            tsmi0.Click += (s, e) =>
            {
                if (splitContainer1.Panel2Collapsed)
                {
                    button1.PerformClick();
                }
            };

            ctxMenuStrip.Items.Add(tsmi0);

            _gntChart.ContextMenuStrip = ctxMenuStrip;
        }

        private void btn_ZoomIn_Click(object sender, EventArgs e)
        {
            if (_gntChart.ToDate.Subtract(_gntChart.FromDate).TotalDays == 1) return;

            _gntChart.FromDate = _gntChart.FromDate.AddDays(+1);
            _gntChart.ToDate = _gntChart.ToDate.AddDays(-1);
            _gntChart.Refresh();
        }

        private void btn_ZoomOut_Click(object sender, EventArgs e)
        {
            if (_gntChart.ToDate.Subtract(_gntChart.FromDate).TotalDays > 15)
            {
                return;
            }

            _gntChart.FromDate = _gntChart.FromDate.AddDays(-1);
            _gntChart.ToDate = _gntChart.ToDate.AddDays(+1);
            _gntChart.Refresh();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                _gntChart.ScrollPosition = vScrollBar1.Value;
                _gntChart.Refresh();
                _gntChart.Invalidate();
            }
            catch (Exception)
            {
            }
        }

        private async void Gantt_MouseClick(object sender, MouseEventArgs eventArgs)
        {
            await Task.Delay(500);

            if (_isDoubleClick) return;

            if (_gntChart.MouseOverRowValue != null)
            {
                pnToolTip.Visible = false;

                var val = (Bar)_gntChart.MouseOverRowValue;

                var sb = new System.Text.StringBuilder();
                sb.AppendLine(val.Tag);
                sb.AppendLine();
                sb.AppendLine("Start time: " + val.FromTime.ToString("dd-MM-yyyy HH:mm") + "   ");
                sb.AppendLine("End time: " + val.ToTime.ToString("dd-MM-yyyy HH:mm") + "   ");

                if (val.ProdFromTime > DateTime.MinValue)
                {
                    sb.AppendLine("Production start time: " + val.ProdFromTime.ToString("dd-MM-yyyy HH:mm"));
                }

                if (val.ProdToTime > DateTime.MinValue)
                {
                    sb.AppendLine("Production end time: " + val.ProdToTime.ToString("dd-MM-yyyy HH:mm"));
                }

                lblOperatorTip.Text = val.RowText;
                lblDetailsTip.Text = sb.ToString();

                pnToolTip.Location = _gntChart.PointToClient(new Point(Cursor.Position.X, (Cursor.Position.Y + pnToolTip.Height / 2) - 20));
                if (pnToolTip.Location.X + pnToolTip.Width > _gntChart.Width)
                {
                    var x = pnToolTip.Location.X + pnToolTip.Width - _gntChart.Width; 
                    pnToolTip.Location = _gntChart.PointToClient(new Point(Cursor.Position.X - x, (Cursor.Position.Y + pnToolTip.Height / 2) - 20));
                }
                
                pnToolTip.Visible = true;
                pnToolTip.Refresh();
            }
            else
            {
                if (pnToolTip.Visible)
                {
                    pnToolTip.Visible = false;
                }
            }
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            pnToolTip.Visible = false;
        }
    }
}