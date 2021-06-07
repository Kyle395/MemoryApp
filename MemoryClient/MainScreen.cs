using System;
using System.Net.Sockets;
using System.Text;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace MemoryClient
{
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
            this.Close();
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
            public string read()
        {
            byte[] buffer = new byte[1024];
            try
            {
                int message_size = stream.Read(buffer, 0, 1024);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            string s = System.Text.Encoding.UTF8.GetString(buffer);
            stream.Flush();
            s = s.Replace("\0", "");
            return s;
        }

        public void write(string toWrite)
        {
            byte[] buffer = ASCIIEncoding.UTF8.GetBytes(toWrite);
            try
            {
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            catch (Exception e)
            {

            }

        }

        public string[] checkMessage(string s)
        {
            return s.Split(' ');
        }
        #endregion

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string[] data;
            var index = this.dataGridView1.Rows.Add();
            write("ref\r\n");
            data = checkMessage(read());

            int j = 0;

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] == "/")
                {
                    index = this.dataGridView1.Rows.Add();
                    j = 0;
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
                string isPrivate = Convert.ToString(selectedRow.Cells[2].Value);
                string cellValue = Convert.ToString(selectedRow.Cells["Id"].Value);
                if (isPrivate=="True")
                {
                    object pass = Interaction.InputBox("Password");
                    write(pass.ToString());
                    if (read() == "!\r\n")
                    {
                        Microsoft.VisualBasic.Interaction.MsgBox("Wrong password", MsgBoxStyle.OkOnly);
                    }
                    else Microsoft.VisualBasic.Interaction.MsgBox("Correct", MsgBoxStyle.OkOnly);
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
            write("logout\r\n");
            this.Close();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            write("logout\r\n");
            this.Hide();

        }
    }
}
