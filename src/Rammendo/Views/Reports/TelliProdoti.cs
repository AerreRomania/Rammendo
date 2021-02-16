using Rammendo.Behaviors;
using Rammendo.ViewModels;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class TelliProdoti : CWindow
    {
        private readonly TelliProdotiViewModel _telliProdotiViewModel;

        public TelliProdoti(Panel parent = null) : base(true, parent) {
            InitializeComponent();
            _telliProdotiViewModel = new TelliProdotiViewModel();
            LoadData();
        }

        private async void LoadData() {
            var data = await _telliProdotiViewModel.Data();
            dataGridView1.DataSource = data;
        }
    }
}
