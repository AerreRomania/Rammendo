using Rammendo.Behaviors;
using Rammendo.Helpers;
using Rammendo.ViewModels;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class CommessaDetails : CWindow
    {
        private readonly CommessaDetailsViewModel _commessaDetailsViewModel;

        private string Commessa { get; set; }
        
        public CommessaDetails(string commessa, string article = null) : base(false) {
            InitializeComponent();
            _commessaDetailsViewModel = new CommessaDetailsViewModel(commessa, article);
            this.DoubleBuffered(true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            Commessa = commessa;
            
            pnTitlebar.MouseMove += (s, mv) => {
                if (mv.Button == MouseButtons.Left && WindowState != FormWindowState.Maximized) {
                    Resizer.ReleaseCapture();
                    Resizer.SendMessage(Handle, Resizer.WM_NCLBUTTONDOWN, Resizer.HT_CAPTION, 0);
                }
            };
        }

        protected async override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            await LoadData();
        }

        private async Task LoadData() {
            PbLoader.Visible = true;
            PbError.Visible = false;
            await Task.Delay(300);

            var data = await _commessaDetailsViewModel.Data(Commessa);

            if (data != null) {
                DgvTelliProdoti.DataSource = data;

                for (var i = 0; i <= 1; i++) {
                    DgvTelliProdoti.Rows[i].DefaultCellStyle.ForeColor = Color.OrangeRed;
                    DgvTelliProdoti.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold, GraphicsUnit.Point);
                    DgvTelliProdoti.Rows[i].DefaultCellStyle.BackColor = i == 0 ? Color.WhiteSmoke : Color.MistyRose;
                    DgvTelliProdoti.Rows[i].DefaultCellStyle.SelectionBackColor = i == 0 ? Color.WhiteSmoke : Color.MistyRose;

                    DgvTelliProdoti.Rows[i].Height = i == 0 ? 20 : 32;
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
