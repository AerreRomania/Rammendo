using Microsoft.SqlServer.Server;
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
            FillComboBoxes();
        }

        protected async override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            await LoadData();
        }

        private async Task LoadData() {
            PbLoader.Visible = true;
            PbError.Visible = false;
            await Task.Delay(300);

            var article = CbArticolo.SelectedIndex > 0 ? CbArticolo.Text : null;
            var commessa = CbCommessa.SelectedIndex > 0 ? CbCommessa.Text : null;
            var stag = CboStagione.SelectedIndex > 0 ? CboStagione.Text : null;
            var fin = CboFinezze.SelectedIndex > 0 ? CboFinezze.Text : null;

            if (CbArticolo.SelectedIndex == -1) article = null;
            if (CbCommessa.SelectedIndex == -1) commessa = null;
            if (CboStagione.SelectedIndex == -1) stag = null;
            if (CboFinezze.SelectedIndex == -1) fin = null;

            var data = await _telliProdotiArticoloViewModel.Data(article, commessa, stag, fin);

            if (data != null) {
                DgvTelliProdoti.DataSource = data;
                DgvTelliProdoti.Rows[0].DefaultCellStyle.ForeColor = Color.OrangeRed;
                DgvTelliProdoti.Rows[0].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                DgvTelliProdoti.Rows[0].DefaultCellStyle.BackColor = Color.MistyRose;
                DgvTelliProdoti.Rows[0].Height = 32;

                if (DgvTelliProdoti.Columns.Count > 8) {
                    DgvTelliProdoti.Columns[9].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    DgvTelliProdoti.Columns[10].DefaultCellStyle.BackColor = Color.WhiteSmoke;
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

        private async void FillComboBoxes() {
            await _telliProdotiArticoloViewModel.Data(null, null, null, null);

            CbArticolo.Items.Clear();
            CbCommessa.Items.Clear();
            CboStagione.Items.Clear();
            CboFinezze.Items.Clear();
            CbArticolo.Items.Add("<Reset>");
            CbCommessa.Items.Add("<Reset>");
            CboStagione.Items.Add("<Reset>");
            CboFinezze.Items.Add("<Reset>");

            foreach (var item in _telliProdotiArticoloViewModel.ListArticles) {
                CbArticolo.Items.Add(item);
            }
            foreach (var item in _telliProdotiArticoloViewModel.ListCommesse) {
                CbCommessa.Items.Add(item);
            }
            foreach (var item in _telliProdotiArticoloViewModel.ListStagione) {
                CboStagione.Items.Add(item);
            }
            foreach (var item in _telliProdotiArticoloViewModel.ListFinezze) {
                CboFinezze.Items.Add(item);
            }
        }

        private async void CbArticolo_SelectedIndexChanged(object sender, EventArgs e) {
        
            CbCommessa.SelectedIndex = -1;
            CboStagione.SelectedIndex = -1;
            CboFinezze.SelectedIndex = -1;
            await LoadData();
        }

        private async void CbCommessa_SelectedIndexChanged(object sender, EventArgs e) {
          
            CbArticolo.SelectedIndex = -1;
            CboStagione.SelectedIndex = -1;
            CboFinezze.SelectedIndex = -1;
            await LoadData();
        }

        private async void CboStagione_SelectedIndexChanged(object sender, EventArgs e) {
            
            CbArticolo.SelectedIndex = -1;
            CbCommessa.SelectedIndex = -1;
            CboFinezze.SelectedIndex = -1;
            await LoadData();
        }

        private async void CboFinezze_SelectedIndexChanged(object sender, EventArgs e) {
           
            CbArticolo.SelectedIndex = -1;
            CboStagione.SelectedIndex = -1;
            CbCommessa.SelectedIndex = -1;
            await LoadData();
        }
    }
}
