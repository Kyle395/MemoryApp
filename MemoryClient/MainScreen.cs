using System;
using System.Net.Sockets;
using System.Text;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Threading;

namespace MemoryClient
{
    using static CommProtocol;
    public partial class MainScreen : Form
    {
        TcpClient Client;
        NetworkStream stream;
        string username;
        public MainScreen(TcpClient Client, string username)
        {
            this.Client = Client;
            stream = Client.GetStream();
            this.username = username;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SingleGameScreen game = new SingleGameScreen();
            game.ShowDialog();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            txtUsername.Text = username;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 4;
        }
        #region dataTransmission
           

        public string[] checkMessage(string s)
        {
            return s.Split(' ');
        }
        #endregion

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string[] data;
            var index = 0; 
            write("ref");            
            data = checkMessage(read());

            int j = 0;
            if (data.Length > 1)
            {
                int numberOfRows = int.Parse(data[0]);
                this.dataGridView1.RowCount = numberOfRows;
            }
            
            for (int i = 1; i < data.Length; i++)
            {
                
                if (data[i] == "/")
                {
                    index++;
                    j = 0;
                }
                else if(data[i]=="~")
                {
                    MessageBox.Show("No rooms found");
                }               
                else
                {
                    this.dataGridView1.Rows[index].Cells[j].Value = data[i];
                    j++;
                }
            }
        }

        private void joinRoomBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string isPrivate = Convert.ToString(selectedRow.Cells[1].Value);
                string cellValue = Convert.ToString(selectedRow.Cells["Id"].Value);
                if (isPrivate=="True")
                {
                    string content = Interaction.InputBox("Enter Password: ", "Password","password", 500, 300);
                    if (content != "")
                    {
                        write("jrm " + cellValue + " " + username + " " + content);
                        if (read() == "ok")
                        {
                            this.Hide();
                            LobbyScreen lobbyScreen = new LobbyScreen();
                            lobbyScreen.ShowDialog();
                        }
                    }
                    else MessageBox.Show("write password");
                }
            }

        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            CreateRoom createRoom = new CreateRoom(Client);
            createRoom.ShowDialog();
        }

        private void clsBtn_Click(object sender, EventArgs e)
        {
            write("logout");
            this.Close();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            write("logout");
            this.Hide();

        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            write("logout");
            Application.Exit();
        }
    }
}
