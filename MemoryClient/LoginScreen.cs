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

                if (client.Connected)
                {
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
            RegistryScreen registryScreen = new RegistryScreen(client);
            registryScreen.ShowDialog();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            write("log " + texBoxLogin.Text+ " "+Hash(texBoxLogin.Text+textBoxPass.Text)+"\r\n");
            if (read() == "1\r\n")
            {
                this.Hide();
                MainScreen mainScreen = new MainScreen(client, texBoxLogin.Text);
                mainScreen.ShowDialog();
            }
            else if (read() == "!\r\n")
            {
                MessageBox.Show("Wrong username or password");
            }

        }

        private void discBtn_Click(object sender, EventArgs e)
        {
            client.Close();
            this.Close();
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
        #endregion

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            write("logout");            
            Application.Exit();
        }
    }
}
