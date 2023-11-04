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
    public partial class Form8 : Form
    {
        Form1 f1;
        int x = 0;
        int H = 0;
        Random rnd = new Random();
        int[] mas;//объявили массив 

        public event System.Windows.Forms.DataGridViewDataErrorEventHandler DataError;

        /*
        public Form8()
        {
            InitializeComponent( );
            
        }*/
        public Form8(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
            this.Load += Form8_Load;
            f1 = f;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;//переход 
            radioButton3.Enabled = false;//переход 
            numericUpDown1.Enabled = false;
            checkBox2.Enabled = false;//переход 

            Form1 sms = this.Owner as Form1;

            try

            {

                string lenhgt = Convert.ToString(textBox1.Text);
                int L_lenhgt = Convert.ToInt32(textBox1.Text);
                dataGridView1.ColumnCount = Convert.ToInt32(lenhgt);
                mas = new int[L_lenhgt];
                for (x = 0; x < dataGridView1.ColumnCount; x++)
                {
                    mas[x] = rnd.Next(1, 10);
                    dataGridView1[x, 0].Value = mas[x];

                    if (x % 2 == 0)
                    {
                        H = Convert.ToInt32(dataGridView1[x, 0].Value) * 2;
                        dataGridView1[x, 1].Value = H;

                    }

                    else
                    {
                        H = Convert.ToInt32(dataGridView1[x, 0].Value) * Convert.ToInt32(dataGridView1[x, 0].Value);
                        dataGridView1[x, 1].Value = H;
                    }

                }


                for (int j = (L_lenhgt - 1); j > 0; j--)
                {

                    if (Convert.ToInt32(dataGridView1[j, 1].Value) > 0)

                    {
                        dataGridView1[j, 1].Value = Convert.ToInt32(dataGridView1[1, 1].Value);
                        break;
                    }

                }


                for (x = 0; x < dataGridView1.ColumnCount; x++)
                {
                    double s = Convert.ToDouble(dataGridView1[x, 1].Value);
                    double s_s = Convert.ToDouble(dataGridView1[0, 1].Value);

                    if (x % 2 != 0)
                    {
                        double L = s / s_s;

                        dataGridView1[x, 2].Value = L;

                    }
                    else
                    {
                        H = Convert.ToInt32(dataGridView1[x, 1].Value);
                        dataGridView1[x, 2].Value = H;
                    }
                }

            }
            catch (System.InvalidOperationException ex)
            {
               // Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();

            }
       catch(System.OverflowException ex)
            {
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Form1 sms = this.Owner as Form1;
            try
            {
                timer1.Enabled = true;
                int s = Convert.ToInt32(numericUpDown1.Value);
                timer1.Interval = 1000 * s;
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }
            catch (System.InvalidOperationException ex)
            {
                Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();

            }
            //finally { timer1.Enabled = !timer1.Enabled; }
            //timer1.Enabled = !timer1.Enabled;

        }
        private void Form8_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnHeadersHeight = 150;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 120f, FontStyle.Regular | FontStyle.Italic); //жирный курсив размера 16
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Pink;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;


            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.RowHeadersWidth = 200;

            dataGridView1.Rows[0].HeaderCell.Value = " Исходный массив ";
            dataGridView1.Rows[1].HeaderCell.Value = " Промежуточный результат ";
            dataGridView1.Rows[2].HeaderCell.Value = " Результирующий массив ";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)// исключения не пашут ИСПРАВИТЬ +кнопка "слуйчанйо с заданной часитотой
                                                                            //"
        {
            checkBox1.Enabled = false;//переход 
            radioButton3.Enabled = false;//переход 
            radioButton1.Enabled = false;//переход 
            checkBox2.Enabled = false;
            timer1.Tick += new System.EventHandler(radioButton1_CheckedChanged);
            try
            {

                if (timer1.Enabled == false && numericUpDown1.Value == 0)
                {
                    throw new Exception(" error ");
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
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {

        }

        void timer1_Tick(object sender, EventArgs e)
        {

            try
            {

                if (timer1.Enabled == false)
                {
                    if (radioButton1.Checked == false)
                    {
                        throw new Exception(" error ");

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
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }
        }

        private void Form8_Load_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (numericUpDown1.Value == 0)
                {
                    throw new Exception(" Не введена переодичность ");

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
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                 + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                 + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;

            numericUpDown1.Enabled = false;
            radioButton1.Enabled = false;//переход 
            radioButton2.Enabled = false;//переход 
            Form1 sms = this.Owner as Form1;
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                dataGridView1.RowCount = 3;
                dataGridView1.ColumnCount = n;

            }
            catch (Exception ex)
            {
               
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Form1 sms = this.Owner as Form1;
            try {
                radioButton3.Enabled = false;
               

                if (dataGridView1.Rows[0].Cells[1].Value != null) ; 
            }
            catch (Exception ex)

            {
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }

          

            try

            {


                int n = Convert.ToInt32(textBox1.Text);
                int j = 0;
                for (x = 0; x < n; x++)
                {


                    if (x % 2 == 0)
                    {
                        H = Convert.ToInt32(dataGridView1[x, 0].Value) * 2;
                        dataGridView1[x, 1].Value = H;

                    }

                    else
                    {
                        H = Convert.ToInt32(dataGridView1[x, 0].Value) * Convert.ToInt32(dataGridView1[x, 0].Value);
                        dataGridView1[x, 1].Value = H;
                    }

                }


                for (x = (n - 1); x > 0; x--)
                {

                    if (Convert.ToInt32(dataGridView1[j, 1].Value) > 0)

                    {
                        dataGridView1[x, 1].Value = Convert.ToInt32(dataGridView1[1, 1].Value);
                        break;
                    }

                }


                for (x = 0; x < dataGridView1.ColumnCount; x++)
                {
                    double s = Convert.ToDouble(dataGridView1[x, 1].Value);
                    double s_s = Convert.ToDouble(dataGridView1[0, 1].Value);

                    if (x % 2 != 0)
                    {
                        double L = s / s_s;

                        dataGridView1[x, 2].Value = L;

                    }
                    else
                    {
                        H = Convert.ToInt32(dataGridView1[x, 1].Value);
                        dataGridView1[x, 2].Value = H;
                    }
                }
            }
            catch (Exception ex)
            {
               
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                string iner = Convert.ToString(ex.InnerException);
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton2.Enabled = false;
            Form1 sms = this.Owner as Form1;

            try
            {
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    int b = dataGridView1.ColumnCount;

                    int[] arr1 = new int[b];
                    arr1[i] = Convert.ToInt32(dataGridView1.Rows[0].Cells[i].Value);

                    if (i % 2 == 0)
                    {
                        int ELEMENT = arr1[i] * 2;
                        dataGridView1[i, 1].Value = ELEMENT;
                    }
                    else
                    {

                        int ELEMENT = arr1[i] * arr1[i];
                        dataGridView1[i, 1].Value = ELEMENT;
                    }

                    int n = Convert.ToInt32(textBox1.Text);
                    for (b = (n - 1); b > 0; b--)
                    {

                        if (Convert.ToInt32(dataGridView1[b, 1].Value) > 0)

                        {
                            dataGridView1[b, 1].Value = Convert.ToInt32(dataGridView1[1, 1].Value);
                            break;
                        }

                    }


                    for (x = 0; x < dataGridView1.ColumnCount; x++)
                    {
                        double s = Convert.ToDouble(dataGridView1[x, 1].Value);
                        double s_s = Convert.ToDouble(dataGridView1[0, 1].Value);

                        if (x % 2 != 0)
                        {
                            double L = s / s_s;

                            dataGridView1[x, 2].Value = L;

                        }
                        else
                        {
                            H = Convert.ToInt32(dataGridView1[x, 1].Value);
                            dataGridView1[x, 2].Value = H;
                        }
                    }

                }
            }
           
            catch (Exception ex)
            {
                string mes = ex.Message;
                string stake = ex.StackTrace;
                string iner = Convert.ToString(ex.InnerException);
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n" + iner + "\r\n";
                Close();
            }
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                Form1 sms = this.Owner as Form1;
                Exception ex = new Exception();
                string mes = ex.Message;
                string iner = Convert.ToString(ex.InnerException);
                string stake = ex.StackTrace;
                string metod = Convert.ToString(ex.TargetSite);
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                sms.richTextBox1.Text += "\r\n" + "\r\n" + "Исключение было вызвано в фоме 8:" + "\r\n" + mes + " " + date + " " + time + "\r\n"
                + "\r\n" + ("СТРОКОВОЕ ПРЕДСТАВЛЕНИЕ СТЕКА ВЫЗОВА") + "\r\n" + stake + "\r\n"
                + "\r\n" + "МЕТОД, В КОТОРОМ БЫЛО ВЫЗВАНО ИСКЛЮЧЕНИЕ" + "\r\n" + metod + "\r\n"+ iner+ "\r\n";
                Close();
            }
            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";

                e.ThrowException = false;
            }
        }
    }
}

        
    
           



