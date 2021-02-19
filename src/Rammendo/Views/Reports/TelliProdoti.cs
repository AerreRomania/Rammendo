using System.Drawing;
using System.Windows.Forms;
using Rammendo.Behaviors;
using Rammendo.Helpers;
using Rammendo.ViewModels;

namespace Rammendo.Views.Reports
{
    public partial class TelliProdoti : CWindow
    {
        private readonly TelliProdotiViewModel _telliProdotiViewModel;
        public TelliProdoti(Panel parent) : base(true, parent) {
            InitializeComponent();
            GenerateChildForm();
            _telliProdotiViewModel = new TelliProdotiViewModel();
            LoadData();
        }

        private async void LoadData() {
            var data = await _telliProdotiViewModel.Data();
            if (data != null) {
                DgvTelliProdoti.DataSource = data;
            }

            DgvTelliProdoti.Rows[0].DefaultCellStyle.ForeColor = Color.DarkCyan;
            DgvTelliProdoti.Rows[0].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            DgvTelliProdoti.Rows[0].DefaultCellStyle.BackColor = Color.PaleTurquoise;

            if (DgvTelliProdoti.Columns.Count > 0) {
                foreach (DataGridViewColumn c in DgvTelliProdoti.Columns) {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            if (DgvTelliProdoti.Rows.Count > 0) {
                foreach (DataGridViewRow row in DgvTelliProdoti.Rows) {
                    row.Height = 32;
                    if (row.Index == 0) continue;

                    if (row.Cells[0].Value.ToString().Contains("Totale")) {
                        row.DefaultCellStyle.ForeColor = Color.DarkCyan;
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        row.DefaultCellStyle.BackColor = Color.Gainsboro;
                        row.Height = 22;
                    }
                    else {
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                        row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
        }
    }
}
