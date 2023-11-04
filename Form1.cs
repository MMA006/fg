using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Laba_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void лр1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void часть1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 формирование = new Form2(this);
            формирование.Owner = (this);
            формирование.ShowDialog();
            this.Show();
        }

        private void часть21ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 формирование = new Form3(this);
            формирование.Owner = (this);
            формирование.ShowDialog();
            this.Show();

        }

        private void часть22ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 формирование = new Form4(this);
            формирование.Owner = (this);
            формирование.ShowDialog();
            this.Show();

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.* ";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

        }

        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            Hide();
            Form5 об_Авторе = new Form5(this);
            об_Авторе.Show();*/

            Form5 об_Авторе = new Form5(this);
            об_Авторе.ShowDialog();

        }

        private void часть1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            Form8 формирование = new Form8(this);
            формирование.Owner = (this);
            формирование.ShowDialog();
            this.Show();
            /*Form8 формирование = new Form8(this);
            формирование.ShowDialog();*/
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void часть1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /*Hide();
            Form9 point = new Form9(this);
            point.Owner = (this);
            point.ShowDialog();
            this.Show();
            */
            Form9 point = new Form9(this);
            point.ShowDialog();
        }

        private void часть2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Hide();
            Form10 point = new Form10(this);
            point.Owner = (this);
            point.ShowDialog();
            this.Show();*/
            Form10 point = new Form10(this);
            point.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }
        private void LoadSettings()
        {
            this.richTextBox1.Text = Properties.Settings.Default.mma;
            this.Text = this.richTextBox1.Text;
        }


        private void задание3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Hide();
            Form11 point = new Form11(this);
            point.Owner = (this);
            point.ShowDialog();
            this.Show();*/
            Form11 point = new Form11(this);
            point.ShowDialog();
        }

        private void parssingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide();
            Form12 parssing = new Form12(this);
            parssing.ShowDialog();
            // this.Show();
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            // SaveFile(richTextBox1.Text,"mma.text");
        }
        /* void SaveFile(string what, string where)
         {
             if (what.Count() > 1)
             {
                 if (File.Exists(where))
                     File.Create(where).Close();
                     File.WriteAllText(where, what);
             }

         }*/

        private void logжурналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 parssing = new Form13(this);
            parssing.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.mma = this.richTextBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void лр2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public string s;
        public MatchCollection myMatch;
        public MatchCollection myMatch2;
        public string signaturadata1;
        public string signaturadata2;
        public string signatura;
        Form1 fm1;
        public DateTime dateTimeFROM = new DateTime();
        public DateTime day = new DateTime();
        public DateTime dateTimeTO = new DateTime();
        public DateTime days1 = new DateTime();
        public DateTime days2 = new DateTime();
        public int from, Fy;
        MatchCollection matchesDate1;
        MatchCollection matchesDate2;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
        }
        private void SetSelectionStyle(int startIndex, int length, FontStyle style)
        {

            Random random = new Random();
            richTextBox1.Select(startIndex, length);
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | style);
            richTextBox1.SelectionColor = System.Drawing.Color.FromArgb(random.Next(255), random.Next(0), random.Next(255));


        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            s = richTextBox1.Text;
            signatura = comboBox1.Text;
           dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            dateTimeFROM = dateTimePicker1.Value;
            dateTimeFROM.ToLongDateString();
            dateTimeTO = dateTimePicker2.Value;
            dateTimeTO.ToLongDateString();
            s = richTextBox1.Text;


            for (days1 = dateTimeFROM; days1 <= dateTimeTO; days1 = days1.AddDays(1))
            {
                signaturadata1 = Convert.ToString(days1.ToLongDateString());
                Regex regexdate = new Regex(signaturadata1);
                matchesDate1 = regexdate.Matches(s);
                if (matchesDate1.Count > 0)
                {
                    from = matchesDate1[0].Index;
                    break;
                }
            }

             
            day = dateTimeTO.AddDays(1);
            for (days2 = day; days2 >= dateTimeFROM; days2 = days2.AddDays(-1))
            {
                signaturadata2 =
                Convert.ToString(days2.ToLongDateString());
                Regex regexdate = new Regex(signaturadata2);
                matchesDate2 = regexdate.Matches(s);
                if (matchesDate2.Count > 0)
                {
                    Fy = matchesDate2[0].Index;
                    break;
                }
            }



           
            Regex regexmethod = new Regex(signatura);
            MatchCollection matchesmethod = regexmethod.Matches(s);
           
            if (matchesmethod.Count > 0)
            {
                foreach (Match ma in matchesmethod)
                {
                    if (ma.Index >= from && ma.Index <= Fy)
                    {
                        richTextBox1.Select(ma.Index, ma.Length);
                        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);
                        richTextBox1.SelectionColor = System.Drawing.Color.Red;
                    }

                }

            }
        }

    }
    
}







