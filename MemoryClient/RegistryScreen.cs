using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClient
{
    using static CommProtocol;
    public partial class RegistryScreen : Form
    {
        LoginScreen LoginScreen;
        TcpClient client;
        NetworkStream stream;
        public RegistryScreen(TcpClient Client, LoginScreen loginScreen)
        {
            this.LoginScreen = loginScreen;
            this.client = Client;
            stream = Client.GetStream();
            InitializeComponent();
        }

        private void cnlBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginScreen.ShowDialog();
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            if (textBoxPass.Text == textBoxPass2.Text && textBoxPass.Text.Length < 15 && textBoxPass.Text.Length >= 5 && texBoxLogin.Text.Length >= 3 && texBoxLogin.Text.Length < 15)
            {
                write("reg " + texBoxLogin.Text + " " + textBoxPass.Text);
                string msg = read();
                if (msg == "reg ok")
                {
                    MessageBox.Show("Succesfully registered");
                    this.Hide();
                    LoginScreen loginScreen = new LoginScreen();
                    loginScreen.ShowDialog();
                }
                if (msg == "error login_already_used")
                {
                    MessageBox.Show("Login already registered");
                }
            }
            else if (textBoxPass.Text != textBoxPass2.Text) 
            {
                MessageBox.Show("Passwords don't match"); 
            }
            else if (textBoxPass.Text.Length >= 15)
            {
                MessageBox.Show("Password is too long");
            }
            else if (textBoxPass.Text.Length < 5)
            {
                MessageBox.Show("Password is too short");
            }
            else if (texBoxLogin.Text.Length < 3)
            {
                MessageBox.Show("Login is too short");
            }
            else if (texBoxLogin.Text.Length >= 15)
            {
                MessageBox.Show("Login is too long");
            }
        }
    }
}
