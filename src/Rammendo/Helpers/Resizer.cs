using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Rammendo.Helpers
{
    public class Resizer
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse

            );
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        public bool aeroEnabled;
        private const int CS_DROPSHADOW = 0x00020000;
        public const int WM_NCPAINT = 0x0085;

        private bool Above, Right, Under, Left, Right_above, Right_under, Left_under, Left_above;
        readonly int Thickness = 6;
        readonly int Area = 8;

        public Resizer(int thickness) {
            Thickness = thickness;
        }

        public Resizer() {
            Thickness = 10;
        }

        public bool CheckAeroEnabled() {
            if (Environment.OSVersion.Version.Major >= 6) {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        public struct Margins
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        public const int WM_NCHITTEST = 0x84;
        public const int HTCLIENT = 0x1;
        public const int HTCAPTION = 0x2;

        public CreateParams CreateParams(CreateParams cp) {
            aeroEnabled = CheckAeroEnabled();
            if (aeroEnabled)
                cp.ClassStyle |= CS_DROPSHADOW;
            return cp;
        }

        public string GetMosuePosition(Point mouse, Form form) {
            if (form.WindowState == FormWindowState.Maximized) return "";

            bool above_underArea = mouse.X > Area && mouse.X < form.ClientRectangle.Width - Area;
            bool right_left_Area = mouse.Y > Area && mouse.Y < form.ClientRectangle.Height - Area;

            bool _Above = mouse.Y <= Thickness;
            bool _Right = mouse.X >= form.ClientRectangle.Width - Thickness;
            bool _Under = mouse.Y >= form.ClientRectangle.Height - Thickness;
            bool _Left = mouse.X <= Thickness;

            Above = _Above && (above_underArea); if (Above) return "a";
            Right = _Right && (right_left_Area); if (Right) return "r";
            Under = _Under && (above_underArea); if (Under) return "u";
            Left = _Left && (right_left_Area); if (Left) return "l";

            Right_above = (_Right && (!right_left_Area)) &&
                (_Above && (!above_underArea)); if (Right_above) return "ra";
            Right_under = ((_Right) && (!right_left_Area)) &&
                (_Under && (!above_underArea)); if (Right_under) return "ru";
            Left_under = ((_Left) && (!right_left_Area)) &&
                (_Under && (!above_underArea)); if (Left_under) return "lu";
            Left_above = ((_Left) && (!right_left_Area)) &&
                (_Above && (!above_underArea)); if (Left_above) return "la";

            return "";
        }
    }
}
