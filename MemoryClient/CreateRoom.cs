using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClient
{
    using static CommProtocol;
    public partial class CreateRoom : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public CreateRoom(TcpClient client)
        {
            this.Client = client;
            stream = client.GetStream();
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (isPrivate.Checked) {
                if (textBox3.Text.Length!=0)
                {
                  write("crm " + isPrivate.Checked.ToString() + " " + textBox3.Text + "\r\n");
                }
                else MessageBox.Show("Write your password you moron");
            }
            else write("crm " + isPrivate.Checked.ToString()+"\r\n");


            MessageBox.Show("Room created with id: " + read());
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region dataTransmission
        
        public string[] checkMessage(string s)
        {
            return s.Split(' ');
        }
        #endregion
    }
}
