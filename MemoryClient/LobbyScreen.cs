using MemoryClient.Properties;
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
        string username;
        string RoomId;
        string previousWinnerString = "";
        MainScreen mainScreen;
        public LobbyScreen(MainScreen mainScreen, string username, string RoomId)
        {
            this.RoomId = RoomId;
            this.username = username;
            this.mainScreen = mainScreen;
            InitializeComponent();
            table1.RowHeadersVisible = false;
        }
        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }
        private static Image[] images
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.SuperHeroImg1,
                    Properties.Resources.SuperHeroImg2,
                    Properties.Resources.SuperHeroImg3,
                    Properties.Resources.SuperHeroImg4,
                    Properties.Resources.SuperHeroImg5,
                    Properties.Resources.SuperHeroImg6,
                    Properties.Resources.SuperHeroImg7,
                    Properties.Resources.SuperHeroImg8
                };
            }
        }
        private void SetImages()
        {
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
                    pictureBoxes[i].Image = images[gs.board[i]];
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
            else MessageBox.Show("PullState error");
            RefreshDisplay();
        }
        public void RefreshDisplay()
        {
            if (gs.activePlayer != -1)
            {
                txtNickname.Text = gs.playerOrder[gs.activePlayer];
            }
            if (gs.playerOrder.Count != 0)
            {
                table1.RowCount = gs.playerOrder.Count;
            }
            for (int i = 0; i < gs.playerOrder.Count; i++)
            {
                int j = 0;
                table1.Rows[i].Cells[j++].Value = gs.playerOrder[i];
                table1.Rows[i].Cells[j++].Value = gs.players.ElementAt(i).Value.ready;
                table1.Rows[i].Cells[j++].Value = gs.players.ElementAt(i).Value.connected;
                table1.Rows[i].Cells[j++].Value = gs.players.ElementAt(i).Value.score;
            }
            if (gs.winners.Count > 0)
            {


                string winners = String.Join(",", gs.winners);
                /*for (int i = 0; i < gs.winners.Count; i++)
                {
                    winners += gs.winners[i].ToString() + ", ";
                }*/


                if (winners != previousWinnerString)
                {
                    testowyLabel.Text = "And the winner is: " + winners;
                    previousWinnerString = winners;
                }
            }
            checkBox1.CheckState = gs.players[username].ready ? CheckState.Checked : CheckState.Unchecked;
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
                MessageBox.Show("It doesn't work");
            }

            CommProtocol.write("move " + myID);
            PullState();
        }
        private void leaveBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            CommProtocol.write("lrm");
            this.Close();
            mainScreen.Show();
        }

        private void LobbyScreen_Load(object sender, EventArgs e)
        {
            txtUsername.Text = username;
            txtRoomId.Text = RoomId;
            PullState();
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CommProtocol.write("noop");
            PullState();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                CommProtocol.write("ready true");
            }
            else
            {
                CommProtocol.write("ready false");
            }
            PullState();
        }

        private void table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
