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
using System.Media;

namespace ZombieDefence
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Player player = new Player();
        Zombie zombie1 = new Zombie();
        Zombie zombie2 = new Zombie();
        Zombie zombie3 = new Zombie();
        Shot shot = new Shot();
        Random rnd = new Random();
        int score = 0;
        Image back;
        bool startshoot = false;
        bool vistrel = false;

        public Form1()
        {
            InitializeComponent();
            back = Image.FromFile(Directory.GetCurrentDirectory() + @"\back.jpg");
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            gr = panel1.CreateGraphics();
            PlayMusic(1);
            player.position = new Point(150, 500);
            zombie1.position = new Point(100, -100);
            zombie2.position = new Point(300, -100);
            zombie3.position = new Point(500, -100);
            shot.position = new Point(-100, -100);
        }


        int v = 1;
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                player.player = Image.FromFile(Directory.GetCurrentDirectory() + @"\player.png");
                v = 1;
            }
            if (e.KeyCode == Keys.Left)
            {
                player.player = Image.FromFile(Directory.GetCurrentDirectory() + @"\player.png");
                v = 1;
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                PlayMusic(0);
                this.Close();
            }
            if (e.KeyCode == Keys.Right && player.position.X < 900)
            {
                player.player = Image.FromFile(Directory.GetCurrentDirectory() + @"\right.png");
                player.position.X += v;
                v++;
            }
            if (e.KeyCode == Keys.Left && player.position.X > 0)
            {
                player.player = Image.FromFile(Directory.GetCurrentDirectory() + @"\left.png");
                player.position.X -= v;
                v++;
            }
            if (e.KeyCode == Keys.Space)
            {
                startshoot = true;
                timer3.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gr.DrawImage(back, 0, 0);
            gr.DrawImage(player.player, player.position);
            gr.DrawImage(shot.shot, shot.position);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            score +=1;

        }


        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PlayMusic(0);
            this.Close();
        }


        private void PlayMusic(int a)
        {
            System.Windows.Media.MediaPlayer backgroundMusic;
            backgroundMusic = new System.Windows.Media.MediaPlayer();
            backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\Harppen.wav"));
            backgroundMusic.Play();
            if (a == 0)
            {
                backgroundMusic.Stop();
                backgroundMusic.Close();
            }
        }

        
        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (startshoot == true && vistrel == false)
            {
                System.Windows.Media.MediaPlayer backgroundMusic;
                backgroundMusic = new System.Windows.Media.MediaPlayer();
                backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\shot.wav"));
                backgroundMusic.Play();
                shot.position.Y = player.position.Y + 30;
                shot.position.X = player.position.X + 35;
                startshoot = false;
                vistrel = true;
            }
            if (vistrel == true)
            {
                shot.position.Y -= 40;
            }
            if (shot.position.Y < 20 && vistrel == true)
            {
                shot.position.X = -100;
                shot.position.Y = -100;
                vistrel = false;
                timer3.Enabled = false;
            }
        }

        bool gameover = false;
        private void Timer4_Tick(object sender, EventArgs e)
        {
            if (player.alive == false && gameover==false)
            {
                gameover = true;
                MessageBox.Show("You are dead");
                this.Close();
            }
            Zomb1();
            Zomb2();
            Zomb3();
        }

        int timeZ1 = 0;
        public void Zomb1()
        {
            if (zombie1.alive == true)
            {
                zombie1.position.Y += 5;
            }
            if (shot.position.X > zombie1.position.X && shot.position.X < zombie1.position.X + 200
                && zombie1.alive == true)
            {
                if (zombie1.position.X > 0 && zombie1.position.X < 500)
                {
                    zombie1.position.X += 10;
                }
                if (zombie1.position.X > 500 && zombie1.position.X < 800)
                {
                    zombie1.position.X -= 10;
                }
            }
            if (shot.position.X > zombie1.position.X && shot.position.X < zombie1.position.X+200
                && shot.position.Y > zombie1.position.Y && shot.position.Y < zombie1.position.Y + 200
                && zombie1.alive == true)
            {
                zombie1.alive = false;
                System.Windows.Media.MediaPlayer backgroundMusic;
                backgroundMusic = new System.Windows.Media.MediaPlayer();
                backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\die.wav"));
                backgroundMusic.Play();
                shot.position.X = -100;
                shot.position.Y = -100;
                vistrel = false;
                timer3.Enabled = false;
            }
            if (zombie1.alive == true)
            {
                gr.DrawImage(zombie1.zombie, zombie1.position);
            }
            if (zombie1.alive == false)
            {
                timeZ1++;
                gr.DrawImage(zombie1.died, zombie1.position);
                if (timeZ1 == 20)
                {
                    timeZ1 = 0;
                    zombie1.alive = true;
                    zombie1.position.X = rnd.Next(0, 800);
                    zombie1.position.Y = -200;
                }
            }
            if (zombie1.position.Y > 600)
            {
                zombie1.position.X = rnd.Next(0, 800);
                zombie1.position.Y = -200;
            }
            if (zombie1.position.X + 100 > player.position.X && zombie1.position.X - 50 < player.position.X
            && zombie1.position.Y + 50 > player.position.Y && zombie1.position.Y < player.position.Y
            && zombie1.alive == true && player.alive == true)
            {
                player.alive = false;
            }
        }

        int timeZ2 = 0;
        private void Zomb2()
        {
            if (zombie2.alive == true)
            {
                zombie2.position.Y += 3;
            }
            if (shot.position.X > zombie2.position.X && shot.position.X < zombie2.position.X + 200
                && zombie2.alive == true)
            {
                if (zombie2.position.X > 0 && zombie2.position.X < 500)
                {
                    zombie2.position.X += 10;
                }
                if (zombie2.position.X > 500 && zombie2.position.X < 800)
                {
                    zombie2.position.X -= 10;
                }
            }
            if (shot.position.X > zombie2.position.X && shot.position.X < zombie2.position.X + 200
                && shot.position.Y > zombie2.position.Y && shot.position.Y < zombie2.position.Y + 200
                && zombie2.alive == true)
            {
                zombie2.alive = false;
                System.Windows.Media.MediaPlayer backgroundMusic;
                backgroundMusic = new System.Windows.Media.MediaPlayer();
                backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\die.wav"));
                backgroundMusic.Play();
                shot.position.X = -100;
                shot.position.Y = -100;
                vistrel = false;
                timer3.Enabled = false;
            }
            if (zombie2.alive == true)
            {
                gr.DrawImage(zombie2.zombie, zombie2.position);
            }
            if (zombie2.alive == false)
            {
                timeZ2++;
                gr.DrawImage(zombie2.died, zombie2.position);
                if (timeZ1 == 20)
                {
                    timeZ2 = 0;
                    zombie2.alive = true;
                    zombie2.position.X = rnd.Next(0, 800);
                    zombie2.position.Y = -200;
                }
            }
            if (zombie2.position.Y > 600)
            {
                zombie2.position.X = rnd.Next(0, 800);
                zombie2.position.Y = -200;
            }
            if (zombie2.position.X + 100 > player.position.X && zombie2.position.X -50 < player.position.X
            && zombie2.position.Y + 50 > player.position.Y && zombie3.position.Y < player.position.Y
            && zombie2.alive == true && player.alive == true)
            {
                player.alive = false;
            }
        }

        int timeZ3 = 0;
        private void Zomb3()
        {
            if (zombie3.alive == true)
            {
                zombie3.position.Y += 4;
            }
            if (shot.position.X > zombie3.position.X && shot.position.X < zombie3.position.X + 200
                && zombie3.alive == true)
            {
                if (zombie3.position.X > 0 && zombie3.position.X < 500)
                {
                    zombie3.position.X += 10;
                }
                if (zombie3.position.X > 500 && zombie3.position.X < 800)
                {
                    zombie3.position.X -= 10;
                }
            }
            if (shot.position.X > zombie3.position.X && shot.position.X < zombie3.position.X + 200
                && shot.position.Y > zombie3.position.Y && shot.position.Y < zombie3.position.Y + 200
                && zombie3.alive == true)
            {
                zombie3.alive = false;
                System.Windows.Media.MediaPlayer backgroundMusic;
                backgroundMusic = new System.Windows.Media.MediaPlayer();
                backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\die.wav"));
                backgroundMusic.Play();
                shot.position.X = -100;
                shot.position.Y = -100;
                vistrel = false;
                timer3.Enabled = false;
            }
            if (zombie3.alive == true)
            {
                gr.DrawImage(zombie3.zombie, zombie3.position);
            }
            if (zombie3.alive == false)
            {
                timeZ3++;
                gr.DrawImage(zombie3.died, zombie3.position);
                if (timeZ3 == 20)
                {
                    timeZ3 = 0;
                    zombie3.alive = true;
                    zombie3.position.X = rnd.Next(0, 800);
                    zombie3.position.Y = -200;
                }
            }
            if (zombie3.position.Y>600)
            {
                zombie3.position.X = rnd.Next(0, 800);
                zombie3.position.Y = -200;
            }
            if (zombie3.position.X + 100 > player.position.X && zombie3.position.X - 50 < player.position.X
            && zombie3.position.Y + 50 > player.position.Y && zombie3.position.Y < player.position.Y
            && zombie3.alive == true && player.alive == true)
            {
                player.alive = false;
            }
        }

        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            startshoot = true;
            timer3.Enabled = true;
        }
    }

    public class Player
    {
        public Point position;
        public Image player;
        public bool alive;
        public Player()
        {
            player = Image.FromFile(Directory.GetCurrentDirectory() + @"\player.png");
            alive = true;
        }
    }
    public class Zombie
    {
        public Point position;
        public Image zombie;
        public Image died;
        public bool alive;
        public Zombie()
        {
            zombie = Image.FromFile(Directory.GetCurrentDirectory() + @"\zombie.png");
            died = Image.FromFile(Directory.GetCurrentDirectory() + @"\died.png");
            alive = true;
        }
    }

    class Shot
    {
        public Point position;
        public Image shot;
        public Shot()
        {
            shot = Image.FromFile(Directory.GetCurrentDirectory() + @"\bullet.png");
        }
    }
}
