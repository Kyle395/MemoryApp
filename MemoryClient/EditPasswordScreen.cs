using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClient
{
    using static CommProtocol;
    public partial class EditPasswordScreen : Form
    {
        TcpClient Client;
        NetworkStream stream;
        string username;
        public EditPasswordScreen(TcpClient client, string username)
        {
            this.username = username;
            this.Client = client;
            stream = client.GetStream();
            InitializeComponent();
        }
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text==txtPass2.Text && txtPass1.Text.Length < 15)
            {
                write("chngpass "+ username +" "+ txtPass1.Text);
                string message = read();
                if (message == "ok")
                {
                    MessageBox.Show("Password Succesfuly changed");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("unknown error");
                }
            }
            if(txtPass1.Text != txtPass2.Text)
            {
                MessageBox.Show("Passwords don't match each other");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
