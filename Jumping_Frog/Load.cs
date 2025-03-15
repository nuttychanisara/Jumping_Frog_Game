using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jumping_Frog
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
            timerLoad.Start();
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            progressLoad.Value = progressLoad.Value + 1;
            if(progressLoad.Value >= 100)
            {
                timerLoad.Stop();
                Menu mn = new Menu();
                mn.Show();
            }
            labelLoad.Text = progressLoad.Value.ToString() + "%";
        }
    }
}
