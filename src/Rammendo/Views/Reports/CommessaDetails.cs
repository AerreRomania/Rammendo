using Rammendo.Behaviors;
using Rammendo.Helpers;
using Rammendo.ViewModels;
using Rammendo.Views.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class CommessaDetails : CWindow
    {
        private readonly CommessaDetailsViewModel _commessaDetailsViewModel;

        private string Commessa { get; set; }
        public static bool CanProgram { get; set; } = false;

        public CommessaDetails(string commessa, string article = null) : base(false) {
            InitializeComponent();
            _commessaDetailsViewModel = new CommessaDetailsViewModel(article);
            this.DoubleBuffered(true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            Commessa = commessa;

            pnTitlebar.MouseMove += (s, mv) => {
                if (mv.Button == MouseButtons.Left && WindowState != FormWindowState.Maximized) {
                    Resizer.ReleaseCapture();
                    Resizer.SendMessage(Handle, Resizer.WM_NCLBUTTONDOWN, Resizer.HT_CAPTION, 0);
                }
            };

            if (!CanProgram)
            {
                panel1.Visible = false;
            }
        }

        protected async override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            await LoadData();
        }

        private async Task<IList<string>> GetProgramedBarcodes()
        {
            var lst = new List<string>();
            var qry = "select distinct barcode from RammendoSchedule";

            using (var c = new SqlConnection(Central.CONNECTION_STRING))
            {
                var cmd = new SqlCommand(qry, c);
                c.Open();
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    while (dr.Read())
                    {
                        lst.Add(dr[0].ToString());
                    }
                c.Close();
            }

            return await Task.FromResult(lst);
        }

        private async Task LoadData() {
            PbLoader.Visible = true;
            PbError.Visible = false;
            await Task.Delay(300);

            var data = await _commessaDetailsViewModel.Data(Commessa);
            var programmedBarcodes = await GetProgramedBarcodes();

            if (data != null) {
                DgvTelliProdoti.DataSource = data;

                for (var i = 0; i <= 1; i++) {
                    DgvTelliProdoti.Rows[i].DefaultCellStyle.ForeColor = Color.OrangeRed;
                    DgvTelliProdoti.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point);
                    DgvTelliProdoti.Rows[i].DefaultCellStyle.BackColor = i == 0 ? Color.WhiteSmoke : Color.MistyRose;
                    DgvTelliProdoti.Rows[i].DefaultCellStyle.SelectionBackColor = i == 0 ? Color.WhiteSmoke : Color.MistyRose;

                    DgvTelliProdoti.Rows[i].Height = i == 0 ? 20 : 32;
                }

                if (DgvTelliProdoti.Rows.Count >= 1)
                {
                    DgvTelliProdoti.Rows[1].Frozen = true;
                }

                if (CanProgram)
                {
                    foreach (DataGridViewRow row in DgvTelliProdoti.Rows)
                    {
                        foreach (var barcode in programmedBarcodes)
                        {
                            if (row.Cells[4].Value.ToString() == barcode)
                            {
                                row.DefaultCellStyle.BackColor = Color.Khaki;
                            }
                        }
                    }
                }

                PbLoader.Visible = false;
            }
            else {
                PbLoader.Visible = false;
                MessageBox.Show("No data.",
                    this.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                PbError.Visible = true;
            }
        }

        private async void DgvTelliProdoti_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 2) return;
            if (!CanProgram)
            {
                return;
            }
            var oldColor = DgvTelliProdoti.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor;
            DgvTelliProdoti.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.LightCyan;

            await Task.Delay(50);

            var barcode = DgvTelliProdoti.Rows[e.RowIndex].Cells[4].Value.ToString();
            var scheduleForm = new ScheduleControl(barcode);
            scheduleForm.ShowDialog();
            scheduleForm.Dispose();
            DgvTelliProdoti.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = oldColor;
        }
    }
}
