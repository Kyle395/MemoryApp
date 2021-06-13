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
                        MessageBox.Show("o ty zlosliwa swinko, usun spacje w hasle");
                        textBox3.Clear();
                        return;
                    }
                }
                write("crm " + isPrivate.Checked.ToString() + " " + textBox3.Text);
            }
            else write("crm " + isPrivate.Checked.ToString() + " ");


            MessageBox.Show("Room created with id: " + read());
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
