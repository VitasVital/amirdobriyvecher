using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmirTerrorist
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Terrorist terrorist = new Terrorist();
        Image back;
        int delta = 0;
        Bullet bullet = new Bullet();
        public Form1()
        {
            InitializeComponent();
            back = Image.FromFile(Directory.GetCurrentDirectory() + @"\dedust.jpg");
            gr = panel1.CreateGraphics();
            bullet.position.X = -100;
            bullet.position.Y = -100;
            //typeof(Panel).InvokeMember("DoubleBuffered",
            //BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            //null, panel1, new object[] { true });
        }
        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.DrawImage(terrorist.terrorist, terrorist.position);
        //    e.Graphics.DrawImage(back, 0, 0);
        //    e.Graphics.DrawImage(bullet.bullet, bullet.position);
        //}

        private void shoot()
        {
            bullet.position = terrorist.position;
            bullet.position.X = terrorist.position.X + 50;
            while (bullet.position.Y > -20)
            {
                bullet.position.Y -= 1;
                Thread.Sleep(5);
            }
            bullet.position.Y = -100;
            bullet.position.X = -100;
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (bullet.position.X == -100 && bullet.position.Y == -100)
            {
                Thread shooting = new Thread(new ThreadStart(shoot));
                shooting.Start();
            }
        }
        public class Bullet
        {
            public Point position;
            public Image bullet;
            public Bullet()
            {
                position.X = 0;
                position.Y = 0;
                bullet = Image.FromFile(Directory.GetCurrentDirectory() + @"\bullet.jpg");
            }
        }
        public class Terrorist
        {
            public Point position;
            public Image terrorist;
            public Terrorist()
            {
                position.X = 300;
                position.Y = 300;
                terrorist = Image.FromFile(Directory.GetCurrentDirectory() + @"\terrorist.png");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //delta += timer1.Interval;
            //if (delta > 20)
            //{
            //    panel1.Refresh();
            //    delta = 0;
            //}
            gr.DrawImage(terrorist.terrorist, terrorist.position);
            
            gr.DrawImage(bullet.bullet, bullet.position);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            gr.DrawImage(back, 0, 0);
        }
    }
}
