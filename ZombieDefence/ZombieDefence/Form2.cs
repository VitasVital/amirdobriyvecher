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
            System.Windows.Media.MediaPlayer backgroundMusic;
            backgroundMusic = new System.Windows.Media.MediaPlayer();
            backgroundMusic.Open(new Uri(Directory.GetCurrentDirectory() + "\\startMIs.wav"));
            backgroundMusic.Play();
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
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
                //this.Hide();
                form.Show();
            }
        }
    }
}
