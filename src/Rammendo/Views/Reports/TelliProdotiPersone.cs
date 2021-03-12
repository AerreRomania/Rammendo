using Rammendo.Behaviors;
using Rammendo.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class TelliProdotiPersone : CWindow
    {
        private readonly TelliProdotiPersoneViewModel _telliProdotiPersoneViewModel;

        public TelliProdotiPersone(Panel parent) : base(true, parent) {
            InitializeComponent();
            _telliProdotiPersoneViewModel = new TelliProdotiPersoneViewModel();
            GenerateChildForm();
        }

        protected async override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            await LoadData();
        }

        private async Task LoadData() {
            PbLoader.Visible = true;
            PbError.Visible = false;
            await Task.Delay(300);

            var data = await _telliProdotiPersoneViewModel.Data();

            if (data != null) {
                CGridBig.DataSource = data;
              
                foreach (DataGridViewColumn c in CGridBig.Columns) {
                    if (c.Index < 6) continue;
                    c.HeaderText = c.HeaderText.Split('_')[1];
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
    }
}
