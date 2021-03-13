using Rammendo.Behaviors;
using Rammendo.Helpers;
using Rammendo.ViewModels;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class TelliProdotiPersone : CWindow
    {
        private readonly TelliProdotiPersoneViewModel _telliProdotiPersoneViewModel;

        private readonly Font _font;

        public TelliProdotiPersone(Panel parent) : base(true, parent) {
            InitializeComponent();
            _telliProdotiPersoneViewModel = new TelliProdotiPersoneViewModel();
            GenerateChildForm();
            CGridBig.DoubleBuffered(true);
            _font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        protected async override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            await LoadData();
        }

        private async Task LoadData() {
            PbLoader.Visible = true;
            PbError.Visible = false;
            await Task.Delay(300);

            try {
                var data = await _telliProdotiPersoneViewModel.Data();

                if (data != null) {
                    CGridBig.DataSource = data;
                    if (CGridBig.Columns.Count > 6) CGridBig.Columns[6].Frozen = true;

                    foreach (DataGridViewColumn c in CGridBig.Columns) {
                        if (c.Index > 6) {
                            c.HeaderText = c.HeaderText.Split('_')[1];
                            CGridBig.Rows[0].Cells[c.Index].Style.ForeColor = Color.Transparent;
                            c.Width = 70;
                        }
                        else {
                            c.Width = c.Index == 0 ? 40 : c.Index == 1 ? 150 : 70;
                            c.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                            c.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                        }
                    }

                    CGridBig.Rows[0].Height = 32;
                    CGridBig.Rows[0].DefaultCellStyle.BackColor = Color.LightYellow;
                    PbLoader.Visible = false;
                }
                else {
                    PbLoader.Visible = false;
                    MessageBox.Show("No data.",
                        this.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PbError.Visible = true;
                }
            }
            catch {
                PbLoader.Visible = false;
                PbError.Visible = true;
            }
            
        }

        private Rectangle _rect = new Rectangle();

        private void CGridBig_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.RowIndex != 0) return;
            if (e.ColumnIndex <= 6) return;
            e.Graphics.FillRectangle(Brushes.LightYellow, e.CellBounds);

            for (var j = 7; j <= CGridBig.ColumnCount - 1;) {
                e.Graphics.FillRectangle(Brushes.LightYellow, _rect);

                _rect = CGridBig.GetCellDisplayRectangle(j, 0, true);
                _rect.Width = e.CellBounds.Width * 4;

                string txt = CGridBig.Rows[0].Cells[j].Value.ToString();
                StringFormat format = new StringFormat {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(txt, _font, Brushes.Coral, _rect, format);

                e.Graphics.DrawLine(new Pen(Brushes.LightGray, 1), _rect.X, 
                                                                   _rect.Y + _rect.Height - 1, 
                                                                   _rect.X + _rect.Width, 
                                                                   _rect.Y + _rect.Height - 1);
                e.Graphics.DrawLine(new Pen(Brushes.LightGray, 1), _rect.X + _rect.Width - 1, 
                                                                   _rect.Y, 
                                                                   _rect.X + _rect.Width - 1, 
                                                                   _rect.Y + _rect.Height);

                j += 4;
            }
   
            e.Handled = true;
        }

        private void CGridBig_Paint(object sender, PaintEventArgs e) {

        }

        private void CGridBig_Scroll(object sender, ScrollEventArgs e) {
            if (e.NewValue < e.OldValue) {
                CGridBig.Invalidate();
            }
            CGridBig.Refresh();
            CGridBig.Update();
        }
    }
}
