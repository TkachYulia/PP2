using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    enum Tool
    {
        Line, Pencil, Rectangle, Elipse, Fill, Eraser, Triangle, Pentagon, 
    }
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 5);
        Pen pene = new Pen(Color.White, 5);
        Tool activeTool = Tool.Pencil;
        Point fpoint;
        Point spoint;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);          
            pictureBox1.Image = bmp;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
      
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            fpoint = e.Location;
            if (activeTool == Tool.Fill)
            {
                DummyFill dummyFill = new DummyFill();
                dummyFill.Fill(bmp, e.Location, pen.Color);
                pictureBox1.Refresh();
            }
            
            /* if(activeTool == Tool.Fill)
             {
                 DummyFill dummyFill = new DummyFill();
             }*/
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            spoint = e.Location;

            switch (activeTool)
            {
                case Tool.Pencil:
                    graphics.DrawLine(pen, fpoint, spoint);
                    fpoint = spoint;
                    break;
                case Tool.Line:
                    graphics.DrawLine(pen, fpoint, spoint);
                    break;
                case Tool.Triangle:
                    graphics.DrawPolygon(pen, GetTriangle(fpoint, spoint));
                    break;
                case Tool.Elipse:
                    graphics.DrawEllipse(pen, GetRectangle(fpoint, spoint));
                    break;
                case Tool.Rectangle:
                    graphics.DrawRectangle(pen, GetRectangle(fpoint, spoint));
                    break;
                case Tool.Pentagon:
                    graphics.DrawPolygon(pen, GetStar(spoint, fpoint));
                    break;
                case Tool.Fill:
                    break;
                default:
                    break;
              
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                spoint = e.Location;
                switch (activeTool)
                {
                    case Tool.Pencil:
                        graphics.DrawLine(pen, fpoint, spoint);
                        fpoint = spoint;
                        break;
                    case Tool.Eraser:
                        graphics.DrawLine(pene, fpoint, spoint);
                        fpoint = spoint;
                        break;
                    case Tool.Line:
                        break;
                    case Tool.Triangle:
                        break;
                    case Tool.Elipse:
                        break;
                    case Tool.Rectangle:
                        break;
                    case Tool.Pentagon:
                        break;
                    case Tool.Fill:
                        break;
                    default:
                        break;
                }
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            switch (activeTool)
            {
                case Tool.Pencil:
                    break;
                case Tool.Line:
                    e.Graphics.DrawLine(pen, fpoint, spoint);
                    break;
                case Tool.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(fpoint, spoint));
                    break;
                case Tool.Triangle:
                    e.Graphics.DrawPolygon(pen, GetTriangle(fpoint, spoint));
                    break;
                case Tool.Elipse:
                    e.Graphics.DrawEllipse(pen, GetRectangle(fpoint, spoint));
                    break;
                case Tool.Pentagon:
                    e.Graphics.DrawPolygon(pen, GetStar(spoint, fpoint));
                    break;
                case Tool.Eraser:
                    break;
                case Tool.Fill:
                    break;
                default:
                    break;
            }
        }
        PointF[] GetStar(Point p1, Point p2)
        {
            PointF[] points =
            {
                new PointF((p1.X + p2.X)/2, p1.Y),
                new PointF(p2.X, p2.Y),
                new PointF(p1.X, (p1.Y+p2.Y)/2),
                new PointF(p2.X, (p1.Y+p2.Y)/2),
                new PointF(p1.X, p2.Y),
                new PointF((p1.X + p2.X)/2, p1.Y)
            };
            return points;
        }
       
        PointF[] GetFigure(Point p1, Point p2, int n)
        {
            PointF[] points = new PointF[n];
            float deg = 360 / n;
            for(int i = 0; i<n; i++)
            {
                float xi = p1.X + (float)(Math.Cos(i * deg * Math.PI / 180f));
                float yi = p1.Y + (float)(Math.Sin(i * deg * Math.PI / 180f));
                points[i] = new PointF(xi, yi);
            }
            return points;
        }

        private Point[] GetTriangle(Point p1, Point p2)
        {
            Point[] points = 
            {
             new Point(p1.X, p2.Y),
             new Point((p1.X + p2.X) / 2, p1.Y),
            new Point(p2.X, p2.Y)
            };
          return points;
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            Rectangle res = new Rectangle();
            res.X = Math.Min(p1.X, p2.Y);
            res.Y = Math.Min(p1.Y, p2.X);
            res.Width = Math.Abs(p1.X - p2.X);
            res.Height = Math.Abs(p1.Y - p2.Y);
            return res;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Pencil;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Line;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Rectangle;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Eraser;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Elipse;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Triangle;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = Thickness.Value;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Pentagon;
        }
        

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Fill; 
        }
    }
}
