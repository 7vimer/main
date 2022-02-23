using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПингПонг
{
    public partial class Form1 : Form
    {
        Ball ball;
        static Sprite pl1;
        static Sprite pl2;
        public Form1()
        {

            InitializeComponent();
            this.Game.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
            DoubleBuffered = true;
            pl1 = new Sprite(30, Game.Height / 2, 3, 40);
            pl2 = new Sprite(Game.Width - 35, Game.Height / 2, 3, 40);
            ball = new Ball(Game);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int keys);
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (GetAsyncKeyState((int)Keys.W) != 0) pl1.u = true;
            else pl1.u = false;
            if (GetAsyncKeyState((int)Keys.S) != 0) pl1.d = true;
            else pl1.d = false;
            if (GetAsyncKeyState((int)Keys.Up) != 0) pl2.u = true;
            else pl2.u = false;
            if (GetAsyncKeyState((int)Keys.Down) != 0) pl2.d = true;
            else pl2.d = false;
            ball.collis(Game);
            ball.update();
            ball.print(g, Game);
            pl1.collis(Game);
            pl1.update();
            pl1.print(g);
            pl2.collis(Game);
            pl2.update();
            pl2.print(g);
            
            Game.Invalidate();
        }
        class Ball
        {
            public double x, y, vx = 0.1, vy = 0.1, h, w, speed = 0.1, jumpforce = 1;
            double cx, cy;
            public Ball(PictureBox pb) 
            {
                x = pb.Height / 2;
                y = pb.Height / 2;
            }
            public void print(Graphics g,PictureBox pa)
            {
                Pen p = new Pen(Color.Red, 2);
                g.DrawEllipse(p, (float)x, (float)y, (float)10, (float)10);

            }
            public void update()
            {
                x += vx + 0.001;
                y += vy + 0.0010;
                cx = x + 5;
                cy = y + 5;
            }
            public void collis(PictureBox ga)
            {
                
                if (y <= ga.Top - 65)
                {
                    vy = -vy;
                }
                if (x >= ga.Right - 15)
                {
                    vx = -vx;
                }
                if (y >= ga.Bottom - 75)
                {
                    vy = -vy;
                }
                if (x <= ga.Left)
                {
                    vx = -vx;
                }
               if (cx - 5 <= pl1.x + pl1.w && cy <= pl1.y + pl1.h && cy >= pl1.y)
                {
                    vx = -vx;
                }
                if (cx + 5 >= pl2.x + pl2.w && cy <= pl2.y + pl2.h && cy >= pl2.y)
                {
                    vx = -vx;
                }
            }
        }



        class Sprite
        {
            public double x = 0, y = 0, vx = 0, vy = 0.001, h, w, speed = 0.1, jumpforce = 1;
            public bool u = false, d = false;
            public Sprite(double x, double y, double w, double h)
            {
                this.x = x;
                this.y = y;
                this.w = w;
                this.h = h;
            }
            public void update()
            {
                if (u == true) up();
                else stopy();
                if (d == true) down();
                x += vx;
                y += vy;
            }
            public void print(Graphics g)
            {
                Pen p = new Pen(Color.Red, 2);
                g.DrawRectangle(p, (float)x, (float)y, (float)w, (float)h);

            }
            public void up()
            {
                vy = -speed;
            }
            public void down()
            {
                vy = speed;
            }
            public void stopy()
            {
                vy = 0;
            }
            public void collis(PictureBox pb)
            {
                if (y <= pb.Top - 65)
                {
                    u = false;
                    vy = 0;
                }
                if (y + h >= pb.Bottom - 70)
                {
                    d = false;
                    vy = 0;
                }
                //if ((y <= sp.y + h + 1 && y >= sp.y) && (Math.Abs(x - sp.x) < sp.w)) u = false;
                //if ((y + h >= sp.y - 1 && y <= sp.y + h) && (Math.Abs(x - sp.x) < sp.w))
                //{
                //    d = false;
                //    vy = 0;
                //}
            }
        }

    }
}

