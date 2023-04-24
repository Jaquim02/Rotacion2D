using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba3Screen
{
   
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        static Graphics g;
        Point a, b, c, d;


        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            

            pictureBox1.Image = bmp;
            Draw();
            Render();  
        }
        public void Draw()
        {


            a = new Point(-50, -50);
            b = new Point(50, -50);
            c = new Point(50, 50);
            d = new Point(-50, 50);
            g.DrawLine(Pens.Purple, new Point(0, pictureBox1.Height / 2), new Point(pictureBox1.Width, pictureBox1.Height / 2));
            g.DrawLine(Pens.Orange, new Point(pictureBox1.Width / 2, 0), new Point(pictureBox1.Width / 2, pictureBox1.Height));
            g.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    
                    Traslacion(10, 0);
                    
                    break;

                case Keys.A:
                    Traslacion(-10, 0);
                    break;

                case Keys.W:
                    Traslacion(0, -10);
                    break;

                case Keys.S:
                    Traslacion(0, 10);
                    break;

                case Keys.R:
                    Rotacion(10);
                    break;

                case Keys.Q:
                    Rotacion(-10);
                    break;
            }
        }

        
        public void Traslacion(int dx, int dy)
        {
            g.Clear(Color.Green);

            a = new Point(a.X + dx, a.Y + dy);
            c = new Point(c.X + dx, c.Y + dy);
            b = new Point(b.X + dx, b.Y + dy);
            d = new Point(d.X + dx, d.Y + dy);
            Render();


        }

        public void Rotacion(float angulo)
        {
            g.Clear(Color.Black);

            // conversion de angulo a radianes    
            float convrad = (float)(Math.PI * angulo) / 180;

            //  se convierten las nuevas coordenadas en base al angulo
            float ax = a.X;
            float ay = a.Y;
            a.X = (int)(ax * Math.Cos(convrad) - ay * Math.Sin(convrad));
            a.Y = (int)(ax * Math.Sin(convrad) + ay * Math.Cos(convrad));

            float bx = b.X;
            float by = b.Y;
            b.X = (int)(bx * Math.Cos(convrad) - by * Math.Sin(convrad));
            b.Y = (int)(bx * Math.Sin(convrad) + by * Math.Cos(convrad));

            float cx = c.X;
            float cy = c.Y;
            c.X = (int)(cx * Math.Cos(convrad) - cy * Math.Sin(convrad));
            c.Y = (int)(cx * Math.Sin(convrad) + cy * Math.Cos(convrad));

            float dx = d.X;
            float dy = d.Y;
            d.X = (int)(dx * Math.Cos(convrad) - dy * Math.Sin(convrad));
            d.Y = (int)(dx * Math.Sin(convrad) + dy * Math.Cos(convrad));

            
            Render();

        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Render()
        {
            g.DrawLine(Pens.White, a, b);
            g.DrawLine(Pens.Orange, b, c);
            g.DrawLine(Pens.Red, c, d);
            g.DrawLine(Pens.Yellow, d, a);

            
            pictureBox1.Invalidate();
        }


        
    }
}
