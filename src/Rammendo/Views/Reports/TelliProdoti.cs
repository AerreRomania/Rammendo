﻿using System.Drawing;
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
            FillComboBoxes();
        }

        private async void LoadData() {
            var article = CbArticolo.SelectedIndex > 0 ? CbArticolo.Text : null;
            var commessa = CbCommessa.SelectedIndex > 0 ? CbCommessa.Text : null;

            if (CbArticolo.SelectedIndex == -1) article = null;
            if (CbCommessa.SelectedIndex == -1) commessa = null;

            try {
                var data = await _telliProdotiViewModel.Data(article, commessa);
                if (data != null) {
                    DgvTelliProdoti.DataSource = data;
                }

                DgvTelliProdoti.Rows[0].DefaultCellStyle.ForeColor = Color.OrangeRed;
                DgvTelliProdoti.Rows[0].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                DgvTelliProdoti.Rows[0].DefaultCellStyle.BackColor = Color.MistyRose;

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
                            row.DefaultCellStyle.ForeColor = Color.OrangeRed;
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
            catch (System.Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void FillComboBoxes() {
            var data = await _telliProdotiViewModel.Data(null, null);

            CbArticolo.Items.Clear();
            CbCommessa.Items.Clear();
            CbArticolo.Items.Add("<Reset>");
            CbCommessa.Items.Add("<Reset>");
            foreach (var item in _telliProdotiViewModel.ListArticles) {
                CbArticolo.Items.Add(item);
            }
            foreach (var item in _telliProdotiViewModel.ListCommesse) {
                CbCommessa.Items.Add(item);
            }
        }

        private void CbArticolo_SelectedIndexChanged(object sender, System.EventArgs e) {
            LoadData();
        }

        private void CbCommessa_SelectedIndexChanged(object sender, System.EventArgs e) {
            CbArticolo.SelectedIndex = -1;
            LoadData();
        }
    }
}
