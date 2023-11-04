using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
