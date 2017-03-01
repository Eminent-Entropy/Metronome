using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using Metronome.Properties;

namespace Metronome
{
    public partial class Form1 : Form
    {
        //starts form1
        public Form1()
        {
            InitializeComponent();
        }

        public void wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
            Application.DoEvents();
        }

        public int bpm()
        {
            try
            {
                return (60000 / Convert.ToInt32(textBox1.Text)); //determins bpm
            }
            catch
            {
                return (0); //if user didn't input an integer
            }
        }

        public int StartStop()//if user wants to loop or stop click
        {
            try
            {
                return (Convert.ToInt32(textBox1.Tag));
            }
            catch
            {
                return (0);
            }
        }

        public void soundRep()//plays and loops click sound
        {
            int a = 1; //tells when to stop playing click sound
            textBox1.Tag = 1;//makes sure sound will loop
            int b = bpm(); //gets bpm
            if (b != 0)
            {
                while (a == 1)
                {
                    a = StartStop();
                    new SoundPlayer(Resources.Click1).Play();
                    wait(b);
                }
            }
            else
            {
                MessageBox.Show("please type a vaid integer");//if user didn't input an integer
            }
        }



       
        //when start button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            soundRep();
        }

        //when stop button is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Tag = 2;
        }
    }
}
