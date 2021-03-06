﻿using Rammendo.Helpers;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Rammendo.Behaviors
{
    public class CWindow : Form
    {
        private readonly Resizer _resizer = new Resizer();
        private bool IsChildForm { get; set; }
        private Panel ParentPanel { get; set; }

        public CWindow() {
            InitializeComponent();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }

        public CWindow(bool isChildForm, Panel parent = null) : base() {
   
            IsChildForm = isChildForm;
            ParentPanel = parent;
            InitializeComponent();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }

        public void GenerateChildForm() {
            WindowState = FormWindowState.Minimized;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            ControlBox = false;
            Visible = false;
            TopLevel = false;
            Visible = true;
            Location = new Point(0, 0);
            ParentPanel.Controls.Add(this);
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            Show();
            Resize += (s, e) => {
                Size = ParentPanel.Size;
            };
            Size = ParentPanel.Size;
        }

        protected override CreateParams CreateParams {
            get {
                return _resizer.CreateParams(base.CreateParams);
            }
        }

        protected override void WndProc(ref Message m) {
            if (IsChildForm) {
               base.WndProc(ref m);
                return;
            }
            
            int x = (int)(m.LParam.ToInt64() & 0xFFFF);
            int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
            Point pt = PointToClient(new Point(x, y));

            if (m.Msg == 0x84) {
                switch (_resizer.GetMosuePosition(pt, this)) {
                    case "l": m.Result = (IntPtr)10; return;
                    case "r": m.Result = (IntPtr)11; return;
                    case "a": m.Result = (IntPtr)12; return;
                    case "la": m.Result = (IntPtr)13; return;
                    case "ra": m.Result = (IntPtr)14; return;
                    case "u": m.Result = (IntPtr)15; return;
                    case "lu": m.Result = (IntPtr)16; return;
                    case "ru": m.Result = (IntPtr)17; return;
                    case "": m.Result = pt.Y < 32 ? (IntPtr)2 : (IntPtr)1; return;

                }
            }

            switch (m.Msg) {
                case Resizer.WM_NCPAINT:
                    if (_resizer.aeroEnabled) {
                        var v = 2;
                        Resizer.DwmSetWindowAttribute(Handle, 2, ref v, 4);
                        Resizer.Margins margins = new Resizer.Margins() {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        Resizer.DwmExtendFrameIntoClientArea(Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);

            if (m.Msg == Resizer.WM_NCHITTEST && (int)m.Result == Resizer.HTCLIENT)
                m.Result = (IntPtr)Resizer.HTCAPTION;
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CWindow));
            this.SuspendLayout();
            // 
            // CWindow
            // 
            this.ClientSize = new System.Drawing.Size(120, 34);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CWindow";
            this.ResumeLayout(false);

        }
    }
}
