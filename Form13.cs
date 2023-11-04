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
using MyLib;

namespace Laba_1
{
    public partial class Form13 : Form
    {
        Form1 f1;
        public string s;
        public string si,si2, si12, si4;
        public string di1,di2,di3,di4,di8;
        public MatchCollection mi2,mi3;
        //public string sig;
       // public string sig;
        public Form13()
        {
            InitializeComponent();
        }
        public Form13(Form1 f)
        {
            InitializeComponent();
            f1 = f;
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = f1.richTextBox1.Text;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void SetSelectionStyle(int startIndex, int lenght, FontStyle style)
        {
           
           
        }
        private void SetSelectionStyle1(int startIndex, int lenght, FontStyle style)
        {

            Color randColor = Color.Black;
            richTextBox1.SelectionColor = randColor;

        }
      
        private void button2_Click(object sender, EventArgs e)
        {
           
           

            try
            {  if (numericUpDown1.Value != 0)
                {
                    string text = richTextBox1.Text;
                  // sig = ;
                    Regex newReg = new Regex(MLIB.sig, RegexOptions.IgnoreCase);
                    MatchCollection matches = newReg.Matches(text);

                    int f = matches[Convert.ToInt32(numericUpDown1.Value)-1].Index;

                    if (matches.Count > numericUpDown1.Value)
                    {
                        textBox1.Text = "Kоличество вхождений" + Convert.ToString(matches.Count) + " \r\n" + "Все вхождения строки " + 
                            MLIB.sig + " в исходном тексте:" + "\r\n";
                        foreach (Match match in matches)
                        {
                            textBox1.Text += match.Index + "-ая позиция" + "\t" + match.Value + "\r\n";
                         
                            if (match.Index>=f)
                            {
                                Color randColor = Color.Red;
                                richTextBox1.Select(match.Index, match.Length);
                                richTextBox1.SelectionColor = randColor;
                         }
                        }
                        
                    }
                    if (matches.Count < numericUpDown1.Value)
                    {
                        textBox1.Text = "Kоличество вхождений" + Convert.ToString(matches.Count) + " \r\n" + "Все вхождения строки " + MLIB.sig + " в исходном тексте:" + "\r\n";
                        foreach (Match match in matches)
                        {
                            textBox1.Text += match.Index + "-ая позиция" + "\t" + match.Value + "\r\n";
                            SetSelectionStyle1(match.Index, match.Length, FontStyle.Underline);
                        }


                    }
                    if (matches.Count == 0)
                    {
                        textBox1.Text = "Совпадений не найдено";
                    }
                }
            }
           

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
           

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            si = richTextBox1.Text;
            if (numericUpDown2.Value == 1)
            {
                di1 = "Исключение было вызвано в фоме 1";
                Regex reg4 = new Regex(di1);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.Gainsboro;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 1=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value== 2)
            {
                
                di2 = "Исключение было вызвано в фоме 2:";
                Regex reg2 = new Regex(di2);
                MatchCollection mi2 = reg2.Matches(si);
                textBox1.Text = " Kоличество исключений в форме 2 = " + Convert.ToString(mi2.Count);

                foreach (Match match2 in mi2)
                {
                    Color randColor = Color.AliceBlue;
                    richTextBox1.Select(match2.Index, match2.Length);
                    richTextBox1.SelectionColor = randColor;
                }
            }
            if (numericUpDown2.Value == 3)
            {
                di3 = "Исключение было вызвано в фоме 3:";
                Regex reg3 = new Regex(di3);
                MatchCollection mi3 = reg3.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.Red;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 3= " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 4)
            {
                di4 = "Исключение было вызвано в фоме 4:";
                Regex reg4 = new Regex(di4);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.Purple;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 4 = " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 5)
            {
                di8 = "Исключение было вызвано в фоме 5";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.Pink;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 5=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 6)
            {
                di8 = "Исключение было вызвано в фоме 6";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.GreenYellow;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 6=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 7)
            {
                di8 = "Исключение было вызвано в фоме 7";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.Peru;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 7=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 8)
            {
                di8 = "Исключение было вызвано в фоме 8";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.Yellow;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 8=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 9)
            {
                di8 = "Исключение было вызвано в фоме 9";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.DarkRed;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 9=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 10)
            {
                di8 = "Исключение было вызвано в фоме 10";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.Beige;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 10=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 11)
            {
                di8 = "Исключение было вызвано в фоме 11";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.DarkMagenta;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 11=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 12)
            {
                di8 = "Исключение было вызвано в фоме 12";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.IndianRed;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 12=  " + Convert.ToString(mi3.Count);

            }
            if (numericUpDown2.Value == 13)
            {
                di8 = "Исключение было вызвано в фоме 13";
                Regex reg4 = new Regex(di8);
                MatchCollection mi3 = reg4.Matches(si);
                foreach (Match match3 in mi3)
                {
                    Color randColor = Color.FloralWhite;
                    richTextBox1.Select(match3.Index, match3.Length);
                    richTextBox1.SelectionColor = randColor;
                }
                textBox1.Text = " Kоличество исключений в форме 13=  " + Convert.ToString(mi3.Count);

            }
            if(numericUpDown2.Value>13 && numericUpDown2.Value == 0)
            {
                textBox1.Text = "Выбранная форма не найдена";

            }






        }
    }
}
