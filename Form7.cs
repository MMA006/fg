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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public Form7(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox3.Clear();
            textBox5.Clear();
            //ФАМИЛИЯ ИМЯ 
            int z = 0;
            int i = 0;
            int j = 0;
            int sum;

            char[] itogi = new char[50];
            char[] tail = new char[50];
            //List<int> termsList = new List<int>();

            // Console.WriteLine("ВЕДИТЕ ИМЯ");
            string name = textBox1.Text;//string name = Console.ReadLine();
            string name_1 = name.Replace(' ', '-');
            
            // Console.WriteLine("ВЕДИТЕ ФАМИЛИЮ");
            string surname = textBox2.Text;  // string surname = Console.ReadLine();
           string  surname_1 = surname.Replace(' ', '-');
            
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
                textBox3.Text += name_i + " + " + surname_i + " = " + sum + "         ";//  Console.WriteLine(name_i + "+" + surname_i + "" + "=" + sum + "-------->" + itogi[i]);
                i++;
            }

            string sum_st = new string(itogi);
            textBox5.Text = sum_st;

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
           // string tail__1 = tail_ch.Replace(' ', '-');
           
            textBox1.Text = name_1;
            textBox2.Text = surname_1;
            textBox4.Text = tail_ch;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
