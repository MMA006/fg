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
    public partial class Form12 : Form
    {
        Form1 f1;
        public string s;
        public string signatura;
        public MatchCollection myMatch;
        public string d;
        public Form12()
        {
            InitializeComponent();
        }
        public Form12(Form1 f)
        {
            InitializeComponent();
            f1 = f;
        }
        public DateTime dateTimeFROM = new DateTime();
        public DateTime day = new DateTime();
        public DateTime dateTimeTO = new DateTime();
        public DateTime days1 = new DateTime();
        public DateTime days2 = new DateTime();

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            dateTimeFROM = dateTimePicker1.Value;
            dateTimeFROM.ToShortDateString();
            dateTimeTO = dateTimePicker2.Value;
            dateTimeTO.ToShortDateString();

            s = richTextBox1.Text;
            signatura = comboBox1.Text;

            Regex regex = new Regex(signatura);
            MatchCollection matches = regex.Matches(s);

            myMatch = matches;
            textBox1.Text = "Все вхождения строки " + signatura + " в исходном тексте:" + "\r\n";


            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    textBox1.Text += match.Index + "-ая позиция" + "\t" + match.Value + "\r\n";
            }
            else
            {
                textBox1.Text = "Совпадений не найдено";
            }
            foreach (Match m in myMatch)
            {
                SetSelectionStyle(m.Index, m.Length, FontStyle.Underline);

            }


            ////////
            

        }
        private void SetSelectionStyle(int startIndex, int lenght, FontStyle style)
        {
            Random random = new Random();

            richTextBox1.Select(startIndex, lenght);
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | style);
            richTextBox1.SelectionColor = System.Drawing.Color.FromArgb(random.Next(255), random.Next(255), 255);



        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //if (richTextBox1.Text ==)
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)//добовление слов в комбобокс
        {
            if (e.KeyCode == Keys.Enter)
            {
                var newString = comboBox1.Text;
                if (!comboBox1.Items.Contains(newString))
                {
                    comboBox1.BeginUpdate();
                    comboBox1.Items.Add(newString);
                    comboBox1.EndUpdate();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker1.MaxDate = dateTimePicker2.Value;
        }
      
        private async Task SearchAndHighlightSignatureAsync(string signature)
        {
            richTextBox1.Select(0, richTextBox1.Text.Length);
            richTextBox1.SelectionColor = Color.Black;

            MatchCollection matches = Class1.Find(richTextBox1.Text, signature);

            textBox1.Text = "Все вхождения строки " + signature + " в исходном тексте: " + Environment.NewLine;

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    textBox1.Text += match.Index + "-ая позиция" + "\t" + match.Value + Environment.NewLine;

                    richTextBox1.Select(match.Index, match.Length);
                    richTextBox1.SelectionColor = Color.Green;
                }
            }
            else
            {
                textBox1.Text = "Совпадений не найдено";
            }
        }
       

        private async void button3_Click(object sender, EventArgs e)
        {
            
                string selectedSignature = comboBox1.Text;
                if (!string.IsNullOrEmpty(selectedSignature))
                {
                    textBox1.Text = "";
                    DateTime startTime = DateTime.Now; // Capture the start time.
                    await SearchAndHighlightSignatureAsync(selectedSignature);
                    DateTime endTime = DateTime.Now; // Capture the end time.
                    TimeSpan elapsedTime = endTime - startTime;
                    textBox1.AppendText("Время асинхронного выполнения (" +
                    selectedSignature + "): " + elapsedTime.TotalMilliseconds.ToString("0.00") + " мс" +
                    Environment.NewLine);
                }
                else
                {
                    MessageBox.Show("Выберите сигнатуру в comboBox1.");
                }
            
        }
    }
}
