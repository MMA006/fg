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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
               // int number = Convert.ToInt32(textBox1.Text);
              string number = textBox1.Text;
                char numberN = Convert.ToChar(number[0]);
                int u = Int32.Parse(number);
                if (numberN != '0') ;
                if (number.Length > 2) ;
            }
            catch (Exception ex)
            
            
            {
                Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();

                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 3:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
+ "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
+ "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n";

                Close();
            }

            try
            {
                string number = textBox1.Text;
                for (int i = 0; i < number.Length; i++)
                {
                    char s = char.Parse(Convert.ToString(number[i]));

                    if (char.IsDigit(s))
                    {
                        // decimal a = Convert.ToDecimal(Console.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {

                Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();

                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 3:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
+ "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
+ "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n";


                Close();
            }
            try {
                string number = textBox1.Text;
                char numberN = number[0];
                if (number.Length != 0) ;
                //  decimal x= Convert.ToDecimal(textBox1.Text);
                char x = number[0];
                char y = number[1];
                string x_x = Convert.ToString(x);
                string y_y = Convert.ToString(y);
                textBox3.Text = x_x + "" + y_y;
                // string chislo = number.Remove(2);
                numberN = number[0];
                if (numberN % 2 == 0)

                {
                    textBox2.Text = Convert.ToString(numberN) + ("---->число   четное");


                }
                else
                {
                    textBox2.Text = Convert.ToString(numberN) + (" ---->число   нечетное");

                }
            } 
            catch (Exception ex) 
            {
                Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();

                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 3:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
+ "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
+ "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n";
                Close();
            }

        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form6 доп = new Form6();
            доп.Owner = (this);
            доп.ShowDialog();
            this.Show();
        }


    }
}