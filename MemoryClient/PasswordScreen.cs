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
    public partial class PasswordScreen : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public PasswordScreen(TcpClient client)
        {
            this.Client = client;
            stream = client.GetStream();
            InitializeComponent();
        }
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            write(txtPass.Text);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
