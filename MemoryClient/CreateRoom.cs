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
            if (isPrivate.Checked)
            {
                char[] vs = textBox3.Text.ToCharArray();
                for (int i = 0; i < vs.Length; i++)
                {
                    if (vs[i].ToString() == " ")
                    {
                        MessageBox.Show("Did you remove all spaces in your password? If not, please delete them.");
                        textBox3.Clear();
                        return;
                    }
                }
                write("crm " + isPrivate.Checked.ToString() + " " + textBox3.Text);
            }
            else write("crm " + isPrivate.Checked.ToString() + " ");

            string sData = read();
            string [] logData  = CheckMessage(sData);
            if (logData[0] == "error")
            {
                MessageBox.Show("You can create only 1 room");
            }
            else if(logData[0]=="crm")
            {
                MessageBox.Show("Room created with id: " + logData[1].ToString());
            }
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
