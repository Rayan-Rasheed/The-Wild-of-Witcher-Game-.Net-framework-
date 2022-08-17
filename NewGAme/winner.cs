using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGAme
{
    public partial class winner : Form
    {
        public winner()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlvl2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Level2 frm = new Level2();
            frm.Show();
        }

        private void btnStarting_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartingGame frm = new StartingGame();
            frm.Show();
        }
    }
}
