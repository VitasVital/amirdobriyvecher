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
    public partial class Form2 : Form
    {
        public Form2()
        {
            PlayMusic(1);
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            PlayMusic(0);
            //this.Hide();
            form.Show();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form1 form = new Form1();
                PlayMusic(0);
                //this.Hide();
                form.Show();
            }
            if (e.KeyCode == Keys.Escape)
            {
                PlayMusic(0);
                this.Close();
            }
        }

        private void PlayMusic(int a)
        {
            if (a == 1)
            {
                SoundPlayer sndPlayer = new SoundPlayer(Directory.GetCurrentDirectory() + @"\startMIs.wav");
                sndPlayer.Play();
                /*System.Windows.Media.MediaPlayer background;
                background = new System.Windows.Media.MediaPlayer();
                background.Open(new Uri(Directory.GetCurrentDirectory() + "\\startMIs.wav"));
                background.Play();*/
            }
            if (a == 0)
            {
                SoundPlayer sndPlayer = new SoundPlayer(Directory.GetCurrentDirectory() + @"\die.wav");
                sndPlayer.Play();
                /*background.Stop();
                background.Close();*/
            }
        }
    }
}
