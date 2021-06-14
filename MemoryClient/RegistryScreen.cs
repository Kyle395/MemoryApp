﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
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
            if (textBoxPass.Text == textBoxPass2.Text && textBoxPass.Text.Length<15)
            {
                write("reg " + texBoxLogin.Text + " " + Hash(texBoxLogin.Text+textBoxPass.Text));
                if (read() == "1")
                {
                    MessageBox.Show("Succesfully registered");
                    this.Hide();
                    LoginScreen loginScreen = new LoginScreen();
                    loginScreen.ShowDialog();
                }
            }
            else MessageBox.Show("Passwords are not identical");
        }
    }
}
