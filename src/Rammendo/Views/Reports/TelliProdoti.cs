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
            _telliProdotiViewModel = new TelliProdotiViewModel();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.DoubleBuffered(true);

            dataGridView1.ColumnHeadersHeight = 60;
            LoadData();
        }

        private async void LoadData() {
            var data = await _telliProdotiViewModel.Data();
            if (data != null) {
                dataGridView1.DataSource = data;
            }

            dataGridView1.Rows[0].DefaultCellStyle.ForeColor = Color.Crimson;
            dataGridView1.Rows[0].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;

            if (dataGridView1.Columns.Count > 0) {
                foreach (DataGridViewColumn c in dataGridView1.Columns) {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            if (dataGridView1.Rows.Count > 0) {
                foreach (DataGridViewRow row in dataGridView1.Rows) {
                    row.Height = 40;
                    if (row.Index == 0) continue;

                    if (row.Cells[0].Value.ToString().Contains("Totale")) {
                        row.DefaultCellStyle.ForeColor = Color.Crimson;
                        row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else {
                        row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                        row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
        }
    }
}
