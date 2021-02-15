using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace Rammendo.Helpers
    {
    class Geometry
        {
        public GraphicsPath RoundedRectanglePath(Rectangle bounds, int rad)
            {
            var diameter = rad * 2;
            var size = new Size(diameter, diameter);
            var arc = new Rectangle(bounds.Location, size);
            var path = new GraphicsPath();

            if (rad == 0)
                {
                path.AddRectangle(bounds);
                return path;
                }

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();

            return path;
            }
        }
    }
