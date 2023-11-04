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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        
        public Form6(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Clear();
                string first = textBox1.Text;
                string second = textBox2.Text;

                int first1 = Convert.ToInt32(first);
                int second1 = Convert.ToInt32(second);

                int H;
                if (first1 > second1)
                {
                    H = second1;
                }
                else
                {
                    H = first1;
                }
                int i = H;
                int c = 0;

                while (i > 0 && c == 0)
                {
                    if ((first1 % i == 0) && (second1 % i == 0))
                        c = i;
                    i--;
                }
                textBox3.Text = Convert.ToString(c);
                int v = (first1 * second1) / c;
                textBox4.Text = Convert.ToString(v);
            }
            catch (Exception ex)
            {
                Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();

                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 6:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
+ "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
+ "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n";
                Close();
            }


        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
