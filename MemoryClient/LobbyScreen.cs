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
    public partial class LobbyScreen : Form
    {
        GameState gs = new GameState();
        public LobbyScreen()
        {
            InitializeComponent();
        }
        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.img1,
                    Properties.Resources.img2,
                    Properties.Resources.img3,
                    Properties.Resources.img4,
                    Properties.Resources.img5,
                    Properties.Resources.img6,
                    Properties.Resources.img7,
                    Properties.Resources.img8
                };
            }
        }
        private void SetImages()
        {
            Image[] array = images.ToArray();
            for (int i = 0; i < 16; i++)
            {
                pictureBoxes[i].Visible = true;
                if (gs.board[i] == -1)
                {
                    pictureBoxes[i].Image = Properties.Resources.question;
                }
                else if (gs.board[i] == -2)
                {
                    pictureBoxes[i].Visible = false;
                }
                else
                {
                    pictureBoxes[i].Image = array[gs.board[i]];
                }
            }
        }
        public void PullState()
        {        
            string sData = CommProtocol.read();
            string[] logData = CommProtocol.CheckMessage(sData);
            if (logData[0] == "game")
            {
                gs.Decode(logData.Skip(1).ToArray());
            }
            else MessageBox.Show("error");
            RefreshDisplay();
        }
        public void RefreshDisplay()
        {
            table1.Rows.Clear();
            int n = table1.Rows.Add();
            int j;
            for (int i = 0; i < gs.playerOrder.Count; i++)
            {
                j = 0;
                table1.Rows[n].Cells[j++].Value = gs.playerOrder[i];
                table1.Rows[n].Cells[j++].Value = gs.players.ElementAt(i).Value.ready;
                table1.Rows[n].Cells[j++].Value = gs.players.ElementAt(i).Value.connected;
                table1.Rows[n].Cells[j++].Value = gs.players.ElementAt(i).Value.score;
                n++;
            }
            SetImages();
        }

        private void clickImage(object sender, EventArgs e)
        {
            int myID = -1;
            for (int i = 0; i < 16; i++)
            {
                if (pictureBoxes[i] == sender)
                {
                    myID = i;
                    break;
                }
            }
            if (myID == -1) 
            { 
                MessageBox.Show("to nie dziala"); 
            }

            CommProtocol.write("move " + myID);
            PullState();
        }

        private void rdyBtn_Click(object sender, EventArgs e)
        {
            CommProtocol.write("ready true");
            PullState();
        }

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            CommProtocol.write("lrm");
            PullState();
            this.Close();
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void LobbyScreen_Load(object sender, EventArgs e)
        {
            PullState();
        }
    }
}
