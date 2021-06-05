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
    public partial class MainScreen : Form
    {
        TcpClient Client;
        public MainScreen(TcpClient Client)
        {
            this.Client = Client;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            GameScreen game = new GameScreen();
            game.ShowDialog();
        }
    }
}
