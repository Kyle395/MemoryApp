using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClient
{
    public partial class MultiGameScreen : Form
    {
        public MultiGameScreen()
        {
            InitializeComponent();
        }

        private void MultiGameScreen_Load(object sender, EventArgs e)
        {
            pictureBox_player1.Image = Properties.Resources.default_picturer;
        }
    }
}
