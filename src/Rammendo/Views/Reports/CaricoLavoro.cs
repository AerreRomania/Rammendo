using Rammendo.Behaviors;
using Rammendo.ViewModels;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class CaricoLavoro : CWindow
    {
        private readonly CaricoLavoroViewModel _caricoLavoroViewModel;
        public CaricoLavoro(Panel parent) : base(true, parent)
        {
            InitializeComponent();
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
        }

        protected async override void OnLoad(EventArgs e)
        {
            await LoadData();
            base.OnLoad(e);
        }

        private async Task LoadData()
        {
            try
            {
                PbLoader.Visible = true;
                PbError.Visible = false;

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
                    PbError.Visible = true;
                }
            }
            catch
            {
                PbLoader.Value = 0;
                PbLoader.Visible = false;
            }
            finally
            {
                PbLoader.Value = 0;
                PbLoader.Visible = false;
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
    }
}
