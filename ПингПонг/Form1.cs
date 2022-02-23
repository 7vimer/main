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
        static Form1 thisForm;
        Ball ball;
        static Sprite pl1;
        static Sprite pl2;
        static int Score1;
        static int Score2;
        static bool Started = false;

        public Form1()
        {

            InitializeComponent();
            this.Game.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
            DoubleBuffered = true;
            pl1 = new Sprite(30, Game.Height / 2, 3, 40);
            pl2 = new Sprite(Game.Width - 35, Game.Height / 2, 3, 40);
            ball = new Ball(Game);
            thisForm = this;
            thisForm.Update();
        }

        public void StartGame ( ) 
        {
         Score1 = 0;
         Score2 = 0;
         Random rnd = new Random();
            int var = rnd.Next(1, 5);
            switch (var)
            {
               case 1:
                  ball.vy = 0.1;
                  ball.vx = 0.1;
                  break;
               case 2:
                  ball.vy = -0.1;
                  ball.vx = 0.1;
                  break;
               case 3:
                  ball.vy = 0.1;
                  ball.vx = -0.1;
                  break;
               case 4:
                  ball.vy = -0.1;
                  ball.vx = -0.1;
                  break;
            }
            thisForm.Spl1.Text = "0";
            thisForm.Spl2.Text = "0";
            ball.x = Game.Width / 2;
            ball.y = Game.Height / 2;
            Started = true;
            thisForm.Update();
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
            bool d = false, u = false;
            double cx, cy;
            public Ball(PictureBox pb) 
            {
                x = pb.Width / 2;
                y = pb.Height / 2;
                vy = 0;
                vx = 0;
            }
            public void print(Graphics g,PictureBox pa)
            {
                Pen p = new Pen(Color.Black, 2);
                g.FillEllipse(p.Brush, (float)x, (float)y, (float)10, (float)10);
            }

            public void update ( )
            {
               if (Started)
               {
                  if (u == true) up();
                  if (d == true) down();
                  if (vx < 0) vx -= 0.00001;
                  else vx += 0.00001;
                  x += vx;
                   y += vy + 0;
                   cx = x + 5;
                   cy = y + 5;
               }
            }
            public void up ()
            {
               speed += 0.000001;
               vy = -speed;
         }
            public void down ()
            {
               speed += 0.000001;
               vy = speed;
            }
         public void collis(PictureBox ga)
            {
                
                if (y <= ga.Top - 65)
                {
                  u = false;
                  d = true;
                }
                if (x >= ga.Right - 15)
                {
                  Score1++;
                  thisForm.Spl1.Text = Score1.ToString();
                  x = thisForm.Game.Width / 2;
                  y = thisForm.Game.Height / 2;
                  vx = vy = 0.1; //speed = 0.1;
                  thisForm.Update();
                }
                if (y >= ga.Bottom - 75)
                {
                     d = false;
                     u = true;
                }
                if (x <= ga.Left)
                {
                    Score2++;
                    thisForm.Spl2.Text = Score2.ToString();
                    x = thisForm.Game.Width / 2;
                    y = thisForm.Game.Height / 2;
                    vx = vy = 0.1;//speed = 0.1;
                    thisForm.Update();
            }


				if (cx - 5 <= pl1.x + w && cx + 5 >= pl1.x && cy - 5 <= pl1.y + pl1.h && cy + 5 >= pl1.y)
				{
					vx = -vx;
				}
				if (cx + 5 >= pl2.x && cx - 5 <= pl2.x + pl2.w && cy - 5 <= pl2.y + pl2.h && cy + 5 >= pl2.y)
				{
					vx = -vx;
				}

            if ((cy + 5 >= pl1.y || cy - 5 <= pl1.y + pl2.h) && cx >= pl1.x + pl1.w && cx <= pl1.x)
            {
               vx = -vx;
               vy = -vy;
            }

            if ((cy + 5 >= pl2.y || cy - 5 <= pl2.y + pl2.h) && cx >= pl2.x + pl2.w && cx <= pl2.x)
				{
					vx = -vx;
					vy = -vy;
				}

			}
        }

        class Sprite
        {
            public double x = 0, y = 0, vx = 0, vy = 0.001, h, w, speed = 0.2, jumpforce = 1;
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
            }
        }

		private void button2_Click ( object sender, EventArgs e )
		{
         StartGame();
		}

		private void Form1_Shown ( object sender, EventArgs e )
		{
         thisForm.Update();
		}

		private void button1_Click ( object sender, EventArgs e )
		{
         StartGame();
      }
	}
}

