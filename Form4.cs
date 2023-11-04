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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try//проверка на символы 
            {
                listBox1.Items.Clear();
            decimal second = 0;
            decimal first = 0;
            decimal third = 0;
            string t = textBox1.Text;// вводим число А  (по условию )
                                     // Console.WriteLine("Ведите число а=");

                

                    decimal x = Convert.ToDecimal(textBox1.Text);
                }
                
                catch (System.FormatException ex)
                {
                    Form1 sms = this.Owner as Form1;
                    string mes = ex.Message;
                    string stake = ex.StackTrace;
                    string metod = Convert.ToString(ex.TargetSite);
                    string date = DateTime.Now.ToLongDateString();
                    string time = DateTime.Now.ToLongTimeString();

                    sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 4:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
    + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
    + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n";
                    Close();
                }
                try
            {
                decimal second = 0;
                decimal first = 0;
                decimal third = 0;
                string t = textBox1.Text;
                decimal a = Convert.ToDecimal(t);
                if (a < 25 && a > 2)
                {


                    for (first = 1; first <= 9; first++)
                    {
                        for (second = 0; second <= 9; second++)
                        {
                            for (third = 0; third <= 9; third++)
                            {
                                decimal sum = first + second + third;
                                if (first != second && first != third && second != third && sum == a)
                                {
                                    string first_1 = Convert.ToString(first);
                                    string second_1 = Convert.ToString(second);
                                    string third_1 = Convert.ToString(third);

                                    listBox1.Items.Add("   " + first.ToString() + second.ToString() + third.ToString());



                                }
                            }
                        }
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

                    sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 4:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
    + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
    + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n";


                    Close();
                }
            }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
    }