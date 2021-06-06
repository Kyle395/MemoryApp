using System;
using System.Net.Sockets;
using System.Text;
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
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            txtUsername.Text = username;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "is Private";
            dataGridView1.Columns[2].Name = "Players";
            dataGridView1.Columns[3].Name = "Game in progress";

            
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
            s = s.Replace("\0", "");
            return s;
        }

        public void write(string toWrite)
        {
            byte[] buffer = ASCIIEncoding.UTF8.GetBytes(toWrite);
            try
            {
                stream.Write(buffer, 0, buffer.Length);
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
            
            string[] data;
            var index = this.dataGridView1.Rows.Add();
            write("ref\r\n");
            while (true) 
            {
                int j = 0;
                data = checkMessage(read());
                for(int i = 1; i < 5; i++)
                {
                    this.dataGridView1.Rows[index].Cells[j].Value = data[i];
                    j++;
                }
                if(data[5] != "end\r\n") break;
            } 
        }

        private void joinRoomBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["Id"].Value);
            }

        }
    }
}
