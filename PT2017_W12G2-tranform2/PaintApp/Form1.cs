using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    public partial class Paint : Form
    {
        string state="Pencil";
        public Paint()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        Point prevPoint;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        Graphics g;
        Point curPoint;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (state == "Pencil")
            {
                if (e.Button == MouseButtons.Left)
                {
                    curPoint = e.Location;
                    g.DrawLine(new Pen(color), prevPoint, curPoint);
                    prevPoint = curPoint;
                }
            }
            else if (state == "Line")
            {
                if (e.Button == MouseButtons.Left)
                {
                    curPoint = e.Location;
                }
                else { g.DrawLine(new Pen(color), prevPoint, curPoint); }

            }
            else if (state == "Rectangle")
            {
                if (e.Button == MouseButtons.Left)
                {
                    curPoint = e.Location;
                }
                else
                {
                    float w = curPoint.X - prevPoint.X;
                    float h = curPoint.Y - prevPoint.Y;
                    if (w < 0 && h > 0)
                    {
                        float k = w;
                        w = h;
                        h = k;
                    }
                    g.DrawRectangle(new Pen(color), prevPoint.X, prevPoint.Y, Math.Abs(w), Math.Abs(h));

                }
               
            } 
            mouseLocationLabel.Text = string.Format("X:{0},Y:{1}", e.X, e.Y);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        Color color = Color.Red;
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                color = dlg.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (state == "Pencil") state = "Line";
            else if (state == "Line") state = "Pencil";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            state = "Rectangle";
        }

   
    }
}
