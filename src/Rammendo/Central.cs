using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Rammendo.Behaviors;
using Rammendo.Helpers;
using Rammendo.Views.Reports;

namespace Rammendo
{
    public partial class Central : CWindow
    {
        private Geometry _geometry = new Geometry();        
        public static DateTime DateFrom { get; private set; }
        public static DateTime DateTo { get; private set; }
        public static bool MostraAttuale { get; private set; }
        public static System.Text.StringBuilder IdStateArray { get; private set; }
        public static string CONNECTION_STRING = "data source=192.168.96.37;initial catalog=ONLYOU; User ID=nicu; password=onlyouolimpias;";

        public Central() : base(false) {
            InitializeComponent();
            this.DoubleBuffered(true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            //Store.Default.Url = "http://192.168.1.102:55432/api/";
            Store.Default.Url = "http://192.168.96.37:55388/api/";
            Store.Default.Save();
        }

        private void Menu_Load(object send, EventArgs args) {
            pnTitlebar.MouseMove += (s, mv) => {
                if (mv.Button == MouseButtons.Left && WindowState != FormWindowState.Maximized) {
                    Resizer.ReleaseCapture();
                    Resizer.SendMessage(Handle, Resizer.WM_NCLBUTTONDOWN, Resizer.HT_CAPTION, 0);
                }
            };

            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory)) {
                if (Path.GetExtension(file) != ".exe") continue;
            }

            treeMenu.Width = 0;
            IdStateArray = new System.Text.StringBuilder();
            var currentDate = DateTime.Now;
            dtpFrom.Value = new DateTime(currentDate.Year, currentDate.Month, 1);
            dtpTo.Value = dtpFrom.Value.AddMonths(1).AddDays(-1);
            DateFrom = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day);
            DateTo = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day);
            pnDockBar.BackColor = Color.WhiteSmoke;
            CreateMenuTree();
            _fromNavigation = false;

            btnTelliProdoti.PerformClick();
        }

        private void CreateMenuTree() {
            var root = new TreeNode("");
            var node1 = root.Nodes.Add("Telli prodoti");
            var node2 = root.Nodes.Add("Report 2");
            var node3 = root.Nodes.Add("Report 3");
            var node4 = root.Nodes.Add("Report 4");
            var node5 = root.Nodes.Add("Carico lavoro");
            var node6 = root.Nodes.Add("Produzione gantt");

            treeMenu.BeginUpdate();
            treeMenu.Nodes.Add(root);
            treeMenu.EndUpdate();

            treeMenu.AfterSelect += (sender, eventArgs) => {
                pnNavi.Enabled = false;
                foreach (var ctrl in pnForms.Controls) {
                    if (ctrl is Form f) {
                        f.Close();
                        f.Dispose();
                    }
                }

                ClearReflectedHandlers();
                ResetMenuCommands();
                SuspendLayout();

                if (treeMenu.SelectedNode == node1) {
                    var frm = new TelliProdotiArticolo(pnForms);
                    btnTelliProdoti.BackColor = Color.DarkCyan;
                    btnTelliProdoti.ForeColor = Color.White;
                }

                if (treeMenu.SelectedNode == node2) {
                    var frm = new TelliProdoti(pnForms);
                    btnTelliProdotiArticolo.BackColor = Color.DarkCyan;
                    btnTelliProdotiArticolo.ForeColor = Color.White;
                }

                if (treeMenu.SelectedNode == node3) {
                    var frm = new TelliProdotiPersone(pnForms);
                    btnTelliProdotiPersone.BackColor = Color.DarkCyan;
                    btnTelliProdotiPersone.ForeColor = Color.White;
                }

                if (treeMenu.SelectedNode == node4)
                {
                    var frm = new CaricoLavoro(pnForms);
                    btnCaricoLavoro.BackColor = Color.DarkCyan;
                    btnCaricoLavoro.ForeColor = Color.White;
                }

                if (treeMenu.SelectedNode == node5)
                {
                    var frm = new ProduzioneGantt(pnForms);
                    btnProduzioneGantt.BackColor = Color.DarkCyan;
                    btnProduzioneGantt.ForeColor = Color.White;
                }

                pnNavi.Enabled = true;
                treeMenu.Enabled = true;
                if (eventArgs.Action != TreeViewAction.Unknown) return;
                if (!_fromNavigation) {
                    if (!listBox1.Items.Contains(treeMenu.SelectedNode))
                        listBox1.Items.Add(treeMenu.SelectedNode);

                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

                btnBack.Enabled = true;

              ResumeLayout(true);
            };
            treeMenu.BeginUpdate();
            treeMenu.CollapseAll();
            treeMenu.BeforeExpand += CheckForCheckedChildrenHandler;
            treeMenu.ExpandAll();
            treeMenu.BeforeExpand -= CheckForCheckedChildrenHandler;
            treeMenu.EndUpdate();
        }

        private static void CheckForCheckedChildrenHandler(object sender,
            TreeViewCancelEventArgs e) {
            if (!HasCheckedChildNodes(e.Node)) e.Cancel = true;
        }

        private static bool HasCheckedChildNodes(TreeNode node) {
            if (node.Nodes.Count == 0) return false;
            foreach (TreeNode childNode in node.Nodes) {
                if (childNode.Checked == false) return true;
                if (HasCheckedChildNodes(childNode)) return true;
            }
            return false;
        }

        private void DtpFrom_ValueChanged(object sender, EventArgs e) {
            DateFrom = new DateTime(dtpFrom.Value.Year, dtpFrom.Value.Month, dtpFrom.Value.Day);
        }

        private void DtpTo_ValueChanged(object sender, EventArgs e) {
            DateTo = new DateTime(dtpTo.Value.Year, dtpTo.Value.Month, dtpTo.Value.Day);
        }

        private void ClearReflectedHandlers() {
            for (var i = pnChecks.Controls.Count - 1; i >= 0; i--) {
                if ((!(pnChecks.Controls[i] is CheckBox cbs))) continue;
                var f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                var obj = f1.GetValue(cbs);
                var pi = cbs.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                var list = (EventHandlerList)pi.GetValue(cbs, null);
                list.RemoveHandler(obj, list[obj]);
            }

            for (var i = pnNavi.Controls.Count - 1; i >= 0; i--)

                switch (pnNavi.Controls[i]) {
                    case PictureBox pb when pb.Name != "pbMenu": {
                            if (pb.Name == "pbSettings") continue;
                            var f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                            var obj = f1.GetValue(pb);
                            var pi = pb.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                            var list = (EventHandlerList)pi.GetValue(pb, null);
                            list.RemoveHandler(obj, list[obj]);
                            break;
                        }
                    case CheckBox cb: {
                            var f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                            var obj = f1.GetValue(cb);
                            var pi = cb.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                            var list = (EventHandlerList)pi.GetValue(cb, null);
                            list.RemoveHandler(obj, list[obj]);
                            break;
                        }
                    case Button btn when btn.Name != "pbMenu": {
                            if (btn.Name != "btnExcel") continue;

                            var f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                            var obj = f1.GetValue(btn);
                            var pi = btn.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                            var list = (EventHandlerList)pi.GetValue(btn, null);
                            list.RemoveHandler(obj, list[obj]);
                            break;
                        }
                }
        }

        private void BtnProgram_Click(object sender, EventArgs e) {
            treeMenu.SelectedNode = treeMenu.Nodes[0];
            treeMenu.Select();

            foreach (Control c in pnDockBar.Controls) {
                if (c is Button b && b.Tag.ToString() == 1.ToString() &&
                    b.Name != "btnProgram") {
                    c.Visible = !c.Visible;

                    if (!c.Visible) {
                    }
                    else {
                        if (c.Visible) {
                            btnTelliProdoti.PerformClick();
                        }
                    }
                }
            }
        }

        private void BtnTelliProdotiGiorno_Click(object sender, EventArgs e) {
            _fromNavigation = false;

            treeMenu.SelectedNode = null;
            treeMenu.SelectedNode = treeMenu.Nodes[0].Nodes[0];
            treeMenu.Select();
            treeMenu.Refresh();
        }

        private void BtnTelliProdotiArticolo_Click(object sender, EventArgs e) {
            _fromNavigation = false;
            treeMenu.SelectedNode = null;
            treeMenu.SelectedNode = treeMenu.Nodes[0].Nodes[1];
            treeMenu.Select();
            treeMenu.Refresh();
        }

        private void BtnTelliProdotiPersone_Click(object sender, EventArgs e) {
            _fromNavigation = false;
            treeMenu.SelectedNode = null;
            treeMenu.SelectedNode = treeMenu.Nodes[0].Nodes[2];
            treeMenu.Select();
            treeMenu.Refresh();
        }

        private void btnCaricoLavoro_Click(object sender, EventArgs e)
        {
            _fromNavigation = false;
            treeMenu.SelectedNode = null;
            treeMenu.SelectedNode = treeMenu.Nodes[0].Nodes[3];
            treeMenu.Select();
            treeMenu.Refresh();
        }

        private void btnProduzioneGantt_Click(object sender, EventArgs e)
        {
            _fromNavigation = false;
            treeMenu.SelectedNode = null;
            treeMenu.SelectedNode = treeMenu.Nodes[0].Nodes[4];
            treeMenu.Select();
            treeMenu.Refresh();
        }

        private void ResetMenuCommands() {
            btnTelliProdoti.Text = "Telli Prodotti Giornaliero";
            btnTelliProdoti.BackColor = Color.FromArgb(210, 210, 210);
            btnTelliProdoti.ForeColor = Color.FromArgb(113, 113, 113);
            btnTelliProdotiArticolo.Text = "Telli Prodotii per Articolo";
            btnTelliProdotiArticolo.BackColor = Color.FromArgb(210, 210, 210);
            btnTelliProdotiArticolo.ForeColor = Color.FromArgb(113, 113, 113);
            btnTelliProdotiPersone.Text = "Rammendo per Persona";
            btnTelliProdotiPersone.BackColor = Color.FromArgb(210, 210, 210);
            btnTelliProdotiPersone.ForeColor = Color.FromArgb(113, 113, 113);
            btnCaricoLavoro.Text = "Carico Lavoro";
            btnCaricoLavoro.BackColor = Color.FromArgb(210, 210, 210);
            btnCaricoLavoro.ForeColor = Color.FromArgb(113, 113, 113);
            btnProduzioneGantt.Text = "Produzione Gantt";
            btnProduzioneGantt.BackColor = Color.FromArgb(210, 210, 210);
            btnProduzioneGantt.ForeColor = Color.FromArgb(113, 113, 113);
        }

        internal bool _fromNavigation = false;
        private void BtnForward_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndex == listBox1.Items.Count - 1) {
                return;
            }
            btnBack.Enabled = true;
            _fromNavigation = true;
            if ((TreeNode)listBox1.SelectedItem == FindLastNode(treeMenu.SelectedNode))
                listBox1.SelectedIndex += 1;
            else
                listBox1.SelectedIndex = listBox1.Items.IndexOf(FindLastNode(treeMenu.SelectedNode));

            treeMenu.SelectedNode = (TreeNode)listBox1.SelectedItem;
        }
        private void BtnBack_Click(object sender, EventArgs e) {
            if (listBox1.SelectedIndex == 0) {
                btnBack.Enabled = false;
                return;
            }
            _fromNavigation = true;

            if ((TreeNode)listBox1.SelectedItem == FindLastNode(treeMenu.SelectedNode))
                listBox1.SelectedIndex -= 1;
            else
                listBox1.SelectedIndex = listBox1.Items.IndexOf(treeMenu.SelectedNode);

            treeMenu.SelectedNode = (TreeNode)listBox1.SelectedItem;
        }

        private TreeNode FindLastNode(TreeNode x) {
            return x;
        }

        private void MenuButtons_Paint(object sender, PaintEventArgs e) {
            var btn = (Button)sender;

            using (GraphicsPath path = _geometry.RoundedRectanglePath(new Rectangle(-1, -1, btn.Width - 1, btn.Height - 1), 4)) {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                btn.Region = new Region(path);
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            }
        }

        private void PnTitleBar_Paint(object sender, PaintEventArgs e) {
            var pn = (Panel)sender;
            var fnt = new Font("Segoe UI", 16);
            var logoRect = new Rectangle(10, 5, 102, 40);
            var refreshTitle = "Programma Rammendo";
            var refreshTitleSize = e.Graphics.MeasureString(refreshTitle, fnt);
            var posX = pn.Width / 2 - refreshTitleSize.Width / 2;
            var posY = pn.Height / 2 - refreshTitleSize.Height / 2;
            e.Graphics.DrawString(refreshTitle, fnt, Brushes.WhiteSmoke, posX, posY);
        }

        private void Button2_Click_2(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void Button1_Click_1(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
                StartPosition = FormStartPosition.Manual;
                Location = new Point(Screen.PrimaryScreen.WorkingArea.Left + 10, Screen.PrimaryScreen.WorkingArea.Top + 10);
            }
            else {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void Central_SizeChanged(object sender, EventArgs e) {
            pnTitlebar.Invalidate();
        }

        private void PnTitlebar_DoubleClick(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
                StartPosition = FormStartPosition.Manual;
                Location = new Point(Screen.PrimaryScreen.WorkingArea.Left + 10, Screen.PrimaryScreen.WorkingArea.Top + 10);
            }
            else {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e) {
            var frm = new Settings();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void cbMostra_CheckedChanged(object sender, EventArgs e) {
            MostraAttuale = cbMostra.Checked;
        }
    }
}