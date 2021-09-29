using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClient
{
    public partial class SingleGameScreen : Form
    {

        bool allowClick = false;
        PictureBox firstGuess;
        Random rand = new Random();
        Timer clickTimer = new Timer();
        int time = 60;
        Timer timer = new Timer { Interval = 1000 };
        MainScreen mainScreen;

        public SingleGameScreen(MainScreen mainScreen)
        {
            this.mainScreen = mainScreen;
            InitializeComponent();
        }

        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }
        private static Image[] HolidayImages
        {
            get
            {
                return new Image[]
                {
                Properties.Resources.Vacation1,
                Properties.Resources.Vacation2,
                Properties.Resources.Vacation3,
                Properties.Resources.Vacation4,
                Properties.Resources.Vacation5,
                Properties.Resources.Vacation6,
                Properties.Resources.Vacation7,
                Properties.Resources.Vacation8
                };
            }
        }
        private static Image[] HeroImages
        {
            get
            {
                return new Image[]
                {
                Properties.Resources.SuperHero1,
                Properties.Resources.SuperHero2,
                Properties.Resources.SuperHero3,
                Properties.Resources.SuperHero4,
                Properties.Resources.SuperHero5,
                Properties.Resources.SuperHero6,
                Properties.Resources.SuperHero7,
                Properties.Resources.SuperHero8
                };
            }
        }
        private static Image[] FruitsImages
        {
            get
            {
                return new Image[]
                {
                Properties.Resources.Fruits1,
                Properties.Resources.Fruits2,
                Properties.Resources.Fruits3,
                Properties.Resources.Fruits4,
                Properties.Resources.Fruits5,
                Properties.Resources.Fruits6,
                Properties.Resources.Fruits7,
                Properties.Resources.Fruits8
                };
            }
        }

        private void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    MessageBox.Show("Time is up");
                    ResetImages();
                }
                var ssTime = TimeSpan.FromSeconds(time);
                label1.Text = "00: " + time.ToString();
            };
        }

        private void ResetImages()
        {
            foreach(var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }
            HideImages();
            setRandomImages();
            time = 60;
            timer.Start();
        }

        private void HideImages()
        {
            foreach(var pic in pictureBoxes)
            {
                pic.Image = Properties.Resources.question;
            }
        }

        private PictureBox getFreeSlot()
        {
            int num;
            do
            {
                num = rand.Next(0, pictureBoxes.Count());
            }
            while (pictureBoxes[num].Tag != null);
            return pictureBoxes[num];
        }
        private void setRandomImages()
        {
            if(comboBox1.Text=="Super Hero")
            {
                foreach (var image in HeroImages)
                {
                    getFreeSlot().Tag = image;
                    getFreeSlot().Tag = image;
                }
            }
            if (comboBox1.Text == "Holiday")
            {
                foreach (var image in HolidayImages)
                {
                    getFreeSlot().Tag = image;
                    getFreeSlot().Tag = image;
                }
            }
            if (comboBox1.Text == "Fruits")
            {
                foreach (var image in FruitsImages)
                {
                    getFreeSlot().Tag = image;
                    getFreeSlot().Tag = image;
                }
            }
        }

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            allowClick = true;
            setRandomImages();
            HideImages();
            startGameTimer();
            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;
            btn_start.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Super Hero";
        }

        private void clickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;
            var pic = (PictureBox)sender;
            
            if (firstGuess == null)
            {
                firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }

            pic.Image = (Image)pic.Tag;
             if (pic.Image == firstGuess.Image && pic != firstGuess)
            {
                pic.Visible = firstGuess.Visible = false;
                {
                    firstGuess = pic;
                }
                HideImages();
            }
            else
            {
                allowClick = false;
                clickTimer.Start();
            }
            firstGuess = null;
            if (pictureBoxes.Any(p => p.Visible)) return;
            MessageBox.Show("You won");
            ResetImages();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
            mainScreen.Show();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
