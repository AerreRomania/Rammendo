using Rammendo.Behaviors;
using Rammendo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class TelliProdotiArticolo : CWindow
    {
        private readonly TelliProdotiArticoloViewModel _telliProdotiArticoloViewModel;

        public TelliProdotiArticolo(Panel parent) : base(true, parent) {
            InitializeComponent();
            _telliProdotiArticoloViewModel = new TelliProdotiArticoloViewModel();
            GenerateChildForm();
        }

        protected override async void OnLoad(EventArgs e) {
            await LoadData();
            base.OnLoad(e);
        }

        private async Task LoadData() {
            PbLoader.Visible = true;
            PbError.Visible = false;
            var article = CbArticolo.SelectedIndex > 0 ? CbArticolo.Text : null;
            var commessa = CbCommessa.SelectedIndex > 0 ? CbCommessa.Text : null;

            await Task.Delay(10);

            if (CbArticolo.SelectedIndex == -1) article = null;
            if (CbCommessa.SelectedIndex == -1) commessa = null;

            var data = await _telliProdotiArticoloViewModel.Data(article, commessa);

            if (data != null) { //do dedicated changes over inherited class
                DgvTelliProdoti.DataSource = data;
                //DgvTelliProdoti.Rows[0].DefaultCellStyle.ForeColor = Color.OrangeRed;
                //DgvTelliProdoti.Rows[0].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                //DgvTelliProdoti.Rows[0].DefaultCellStyle.BackColor = Color.MistyRose;

                //if (DgvTelliProdoti.Rows.Count > 0) {
                //    foreach (DataGridViewRow row in DgvTelliProdoti.Rows) {
                //        row.Height = 32;
                //        if (row.Index == 0) continue;

                //        if (row.Cells[0].Value.ToString().Contains("Totale")) {
                //            row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                //            row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                //            row.DefaultCellStyle.BackColor = Color.Gainsboro;
                //            row.Height = 22;
                //        }
                //        else {
                //            row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                //            row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                //        }
                //    }
                //}
                PbLoader.Visible = false;
            }
            else {
                PbLoader.Visible = false;
                MessageBox.Show("No data.",
                    this.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                PbError.Visible = true;
            }
        }
    }
}
