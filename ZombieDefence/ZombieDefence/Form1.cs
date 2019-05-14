using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieDefence
{
    public partial class Form1 : Form
    {
        int moveLeft = 0;
        int enemyMove = 3;

        Random rnd = new Random();

        int bulletSpeed = 8;
        bool shooting = false;
        int score = 0;



        public Form1()
        {
            InitializeComponent();

            System.Windows.Media.MediaPlayer backgroundMusic;
            backgroundMusic = new System.Windows.Media.MediaPlayer();
            backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\Harppen.wav"));
            backgroundMusic.Play();
            enemy1.Top = -600;
            enemy2.Top = -1000;
            enemy3.Top = -1300;
            bullet.Top = -100;
            bullet.Left = -100;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                
                player.Image = ZombieDefence.Properties.Resources.upper;
                moveLeft = 0;
            }
            else if(e.KeyCode == Keys.Right)
            {
                player.Image = ZombieDefence.Properties.Resources.upper;
                moveLeft = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (player.Location.X < 0)
                {
                    moveLeft = 0;
                }
                else
                {
                    player.Image = ZombieDefence.Properties.Resources.left;
                    moveLeft = -5;
                }
            }
             if(e.KeyCode == Keys.Right)
            {
                if (player.Location.X > 750)
                {
                    moveLeft = 0;
                    
                }
                else
                {
                    
                    player.Image = ZombieDefence.Properties.Resources.right;
                    
                    moveLeft = 6;
                }
            }
             if(e.KeyCode == Keys.Space)
 {
               

                if (shooting == false)
                {
                    System.Windows.Media.MediaPlayer backgroundMusic;
                    backgroundMusic = new System.Windows.Media.MediaPlayer();
                    backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\shot.wav"));
                    backgroundMusic.Play();
                    bulletSpeed = 8;
                    bullet.Left = player.Left + 50;
                    bullet.Top = player.Top;
                    shooting = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.Left += moveLeft;
            bullet.Top -= bulletSpeed;
            enemy1.Top += enemyMove;
            enemy2.Top += enemyMove;
            enemy3.Top += enemyMove;
            scoretext.Text = "" + score;
            if (enemy1.Top == 660 || enemy2.Top == 660 || enemy3.Top == 660)
            {
                gameOver();
            }
            enemyHit();
           

            if (bullet.Bounds.IntersectsWith(enemy1.Bounds))
            {
                System.Windows.Media.MediaPlayer backgroundMusic;
                backgroundMusic = new System.Windows.Media.MediaPlayer();
                backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\die.wav"));
                backgroundMusic.Play();
                score += 10;
                enemy1.Top = -500;
                int ranP = rnd.Next(1, 300);
                enemy1.Left = ranP;
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }
            else if(bullet.Bounds.IntersectsWith(enemy2.Bounds))
 {
                System.Windows.Media.MediaPlayer backgroundMusic;
                backgroundMusic = new System.Windows.Media.MediaPlayer();
                backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\die.wav"));
                backgroundMusic.Play();
                score += 10;
                enemy2.Top = -900;
                int ranP = rnd.Next(1, 400);
                enemy2.Left = ranP;
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }
            else if(bullet.Bounds.IntersectsWith(enemy3.Bounds))
 {
                System.Windows.Media.MediaPlayer backgroundMusic;
                backgroundMusic = new System.Windows.Media.MediaPlayer();
                backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\die.wav"));
                backgroundMusic.Play();
                score += 10;
                enemy3.Top = -1300;
                int ranP = rnd.Next(1, 500);
                enemy3.Left = ranP;
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }
            if ((enemy1.Bounds.IntersectsWith(player.Bounds)) || (enemy2.Bounds.IntersectsWith(player.Bounds)) || (enemy3.Bounds.IntersectsWith(player.Bounds)))
            {
                System.Windows.Media.MediaPlayer backgroundMusic;
                backgroundMusic = new System.Windows.Media.MediaPlayer();
                backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\mandie.wav"));
                backgroundMusic.Play();
                gameOver();
            }
        }
        private void enemyHit()
        {
            if (shooting && bullet.Top < 0)
            {
                shooting = false;
                bulletSpeed = 0;
                bullet.Top = -100;
                bullet.Left = -100;
            }
        }
        private void gameOver()
        {
            /*  timer1.Enabled = false;
              MessageBox.Show("Your Score = " + score +);
              score = 0;
              scoretext.Text = "0";
              enemy1.Top = -500;
              enemy2.Top = -900;
              enemy3.Top = -1300;
              bullet.Top = -100;
              bullet.Left = -100;
              timer1.Enabled = true;*/
            timer1.Enabled = false;
            MessageBox.Show("Your Score = " + score );
            score = 0;
            scoretext.Text = "0";
            enemy1.Top = -500;
            enemy2.Top = -900;
            enemy3.Top = -1300;
            bullet.Top = -100;
            bullet.Left = -100;
            this.Hide();
            //Form2 fr = new Form2();
            //fr.Show();
            this.Close();
        }
    
            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            score +=1;

        }
    }
   
}
