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
            comboBox1.Text = "Super Hero";
        }
        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }
        private static Image[] HolydayImages
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
                    if (comboBox1.Text == "Super Hero")
                    {
                        pictureBoxes[i].Image = HeroImages[gs.board[i]];
                    }
                    if (comboBox1.Text == "Holyday")
                    {
                        pictureBoxes[i].Image = HolydayImages[gs.board[i]];
                    }
                    if (comboBox1.Text == "Fruits")
                    {
                        pictureBoxes[i].Image = FruitsImages[gs.board[i]];
                    }
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


                string winners = "";// = String.Join(", ", gs.winners);
                for (int i = 0; i < gs.winners.Count; i++)
                {
                    winners += gs.winners[i].ToString() + ", ";
                }


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
