﻿using System;
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
    public partial class RegistryScreen : Form
    {
        TcpClient Client;
        NetworkStream stream;
        public RegistryScreen(TcpClient Client)
        {
            this.Client = Client;
            InitializeComponent();
        }
    }
}
