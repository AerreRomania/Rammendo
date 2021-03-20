using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rammendo.Behaviors;
using Rammendo.ViewModels;

namespace Rammendo.Views.Reports
{
    public partial class TelliProdoti : CWindow
    {
        private readonly TelliProdotiViewModel _telliProdotiViewModel;
        public TelliProdoti(Panel parent) : base(true, parent)
        {
            InitializeComponent();
            GenerateChildForm();
            _telliProdotiViewModel = new TelliProdotiViewModel();

            CbArticolo.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            CbCommessa.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);

            FillComboBoxes();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                PbLoader.Visible = true;
                PbError.Visible = false;

                await Task.Delay(300);

                var article = CbArticolo.SelectedIndex > 0 ? CbArticolo.Text : null;
                var commessa = CbCommessa.SelectedIndex > 0 ? CbCommessa.Text : null;

                if (CbArticolo.SelectedIndex == -1) article = null;
                if (CbCommessa.SelectedIndex == -1) commessa = null;

                var data = await _telliProdotiViewModel.Data(article, commessa);

                if (data != null)
                {
                    DgvTelliProdoti.DataSource = data;
                    DgvTelliProdoti.Rows[0].DefaultCellStyle.ForeColor = Color.OrangeRed;
                    DgvTelliProdoti.Rows[0].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point);
                    DgvTelliProdoti.Rows[0].DefaultCellStyle.BackColor = Color.MistyRose;

                    if (DgvTelliProdoti.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in DgvTelliProdoti.Rows)
                        {
                            row.Height = 32;
                            if (row.Index == 0) continue;

                            if (row.Cells[0].Value.ToString().Contains("Totale"))
                            {
                                row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                                row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point);
                                row.DefaultCellStyle.BackColor = Color.Gainsboro;
                                row.Height = 22;
                            }
                            else
                            {
                                row.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular, GraphicsUnit.Point);
                                row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                            }
                        }
                    }

                    PbLoader.Visible = false;
                }
                else
                {
                    PbLoader.Visible = false;
                    MessageBox.Show("No data.",
                        this.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PbError.Visible = true;
                }
            }
            catch
            {
                PbLoader.Visible = false;
                PbError.Visible = true;
            }

        }

        private async void FillComboBoxes()
        {
            await _telliProdotiViewModel.Data(null, null);

            CbArticolo.Items.Clear();
            CbCommessa.Items.Clear();
            CbArticolo.Items.Add("<Reset>");
            CbCommessa.Items.Add("<Reset>");
            foreach (var item in _telliProdotiViewModel.ListArticles)
            {
                CbArticolo.Items.Add(item);
            }
            foreach (var item in _telliProdotiViewModel.ListCommesse)
            {
                CbCommessa.Items.Add(item);
            }
        }

        private async void CbArticolo_SelectedIndexChanged(object sender, EventArgs e)
        { 
            await LoadData();
            CbCommessa.SelectedIndex = -1;
        }

        private async void CbCommessa_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadData();
            CbArticolo.SelectedIndex = -1;
        }

        void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
    }
}
