using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClient
{

    using static CommProtocol;
    public partial class LoginScreen : Form
    {
        TcpClient client;
        NetworkStream stream;

        public LoginScreen()
        {
            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1", 8080);
                stream = client.GetStream();
                CommProtocol.init(stream);

                if (client.Connected)
                {
                    sendKey(aes);
                    InitializeComponent();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Couldn't connect to the server. Please try again.");
                this.Close();
            }

        }
        private void LoginScreen_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistryScreen registryScreen = new RegistryScreen(client, this);
            registryScreen.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            write("log " + texBoxLogin.Text+ " "+textBoxPass.Text);
            string msg = read();
            if (msg == "1")
            {
                this.Hide();
                MainScreen mainScreen = new MainScreen(client, texBoxLogin.Text);
                mainScreen.ShowDialog();
            }
            else if (msg == "!")
            {
                MessageBox.Show("Wrong username or password");
            }
            else if(msg == "error already_logged_in")
            {
                MessageBox.Show("this user is already logged in");
            }

        }

        private void discBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            client.Close();
        }
        
        static string Hash(string password)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            write("logout");            
            Application.Exit();
        }
    }
}
