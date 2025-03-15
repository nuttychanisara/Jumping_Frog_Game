using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Jumping_Frog
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Application.OpenForms["Load"].Hide();
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Game gm = new Game();
            gm.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
