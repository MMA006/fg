using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Laba_1
{
    public partial class Form2 : Form
    {
        Form1 sms;
        public MatchCollection match;

        public Form2(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
            sms = f;

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 sms = this.Owner as Form1;
            try

            {
                if (char.IsDigit(Convert.ToChar(textBox1.Text)))
                    textBox5.Clear();
                
                    //ФАМИЛИЯ ИМЯ 
                int z = 0;
                int i = 0;
                int j = 0;
                int sum;

                char[] itogi = new char[50];
                char[] tail = new char[50];
                string name = textBox1.Text;//string name = Console.ReadLine();

                string surname = textBox2.Text;  // string surname = Console.ReadLine();

                char[] name_char = name.ToCharArray();
                char[] surname_char = surname.ToCharArray();




                int name_lenght = name.Length;
                int surname_lenght = surname.Length;

                if (name_lenght < surname_lenght)
                {
                    z = name_lenght;
                }
                else
                {
                    z = surname_lenght;
                }

                while (i != z)
                {
                    int name_i = name_char[i];
                    int surname_i = surname_char[i];
                    sum = name_i | surname_i;
                    itogi[i] = (char)sum;
                    textBox5.Text += name_i + " + " + surname_i + " = " + sum + "      ";//  Console.WriteLine(name_i + "+" + surname_i + "" + "=" + sum + "-------->" + itogi[i]);
                    i++;
                }
                string sum_st = new string(itogi);
                textBox4.Text = sum_st;


                if (name_lenght < surname_lenght)
                {
                    z = surname_lenght;
                    while (i != z)
                    {
                        tail[j] = surname_char[i];
                        j++;
                        i++;
                    }
                }
                else
                {
                    z = name_lenght;
                    while (i != z)
                    {
                        tail[j] = name_char[i];
                        j++; //  Console.Write( tail);
                        i++;
                    }
                }
                string tail_ch = new string(tail);
                textBox3.Text = tail_ch;

            }
           
            catch (Exception ex)
            {

                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();

                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 2:" + "\r\n" + mes + " " + date +
                    " " + time + "\r\n" + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                    + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n";
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form7 Доп_з = new Form7();
            Доп_з.ShowDialog();
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            Hide();
            Form7 Доп_з = new Form7();
            Доп_з.ShowDialog();
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            
        }
        }
    }



