using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsOOP3
{
    class MyShape
    {
        Bitmap bmp;
        Pen pen = new Pen(Color.Black);
        Graphics g;
        RectangleF r;

        public MyShape(RectangleF rectangle, Color color)
        {
            int h = 2*(int)rectangle.Height;
            int w = 2*(int)rectangle.Width;

            bmp = new Bitmap(w, h);
            g = Graphics.FromImage(bmp);
            r = rectangle;

            pen.Color = color;

            PointF a = new PointF(rectangle.X + rectangle.Width / 2, rectangle.Y);
            PointF b = new PointF(rectangle.X, rectangle.Y + rectangle.Height);
            PointF c = new PointF(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);

            PointF a1 = new PointF(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height * 2 - 2 * rectangle.Height / 3);
            PointF b1 = new PointF(rectangle.X, rectangle.Y + rectangle.Height - 2 * rectangle.Height / 3);
            PointF c1 = new PointF(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height - 2 * rectangle.Height / 3);

            g.FillPolygon(pen.Brush, new PointF[] { a, b, c });
            g.FillPolygon(pen.Brush, new PointF[] { a1, b1, c1 });
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmp, r.X, r.Y);
        }

    }
}
