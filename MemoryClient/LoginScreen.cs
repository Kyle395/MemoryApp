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
    public partial class LoginScreen : Form
    {
        TcpClient Client = new TcpClient();
        public LoginScreen()
        {
            Client = new TcpClient();

            try
            {
                Client.Connect("127.0.0.1", 1111);

                if (Client.Connected)
                {
                    InitializeComponent();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Couldn't connect to the server. Please try again.");
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistryScreen screen = new RegistryScreen(Client);
            screen.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen main = new MainScreen(Client);
            main.ShowDialog();
        }
    }
}
