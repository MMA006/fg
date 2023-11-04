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
    public partial class Form10 : Form
    {
        public Bitmap bit ;
        public Graphics g;
        public Pen pen;
        public double k = 0.5;
        public int alpha = 1;
        public int alpha1 = 255;
        public Form10(Form1 f)
        {
            InitializeComponent();
        }
        
        private void Form10_Load(object sender, EventArgs e)
        {
           // int o = Convert.ToInt32(numericUpDown1.Value);
            
            bit = new Bitmap(500, 458);
            g = Graphics.FromImage(bit);
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Green, (float)(numericUpDown1.Value));
            
        }

        public int Pifagor(double x, double y, double ang,double lenght,int N)
        {
            double x1 = x + lenght * Math.Cos(ang),
                    y1 = y - lenght * Math.Sin(ang);

            g.DrawLine(new Pen(Color.Green,  (float)(lenght *N *k/10)), (float)x, (float)y, (float)(x1), (float)(y1));

            if (N > 0)
            {
          
                Pifagor(x1, y1, ang + Math.PI / 6, lenght/2, N-1);
                Pifagor(x1, y1, ang - Math.PI / 3, lenght /2, N-1);
                Pifagor(x1, y1, ang + Math.PI / 3, lenght /2, N - 1);
                Pifagor(x1, y1, ang - Math.PI / 6, lenght/2 ,N - 1);
                N--;

            }
            pictureBox1.Image = bit;
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown2.Value < 10)
                {
                    // pictureBox1.BackgroundImage = bit;
                     Pifagor(320, 420, Math.PI / 2, 200, (int)numericUpDown2.Value);

                    // Pifagor(pictureBox1.Width / 2, pictureBox1.Height, Math.PI / 2, pictureBox1.Height- (pictureBox1.Height/2.4), (int)numericUpDown2.Value);
                }
                else
                {
                    throw new Exception(" большое число уровней  ");
                }
                    
            }
            catch(Exception ex)
            {
                Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                sms.richTextBox1.Text += mes + " " + date + " " + time + "\r\n";
                Close();
            }
           
            

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        // Pifagor(this.Width / 2, this.Height - 2 * pictureBox1.Height, Math.PI / 2, 200,10, e);

        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            this.button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            pictureBox1.Image = null;
            bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //  Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown2.Value <10)
                {
                    serpinsk(pictureBox1.Width / 3.5, pictureBox1.Height / 3.5, 100, (int)numericUpDown2.Value);
                }//  pictureBox1.BackgroundImage = bit;
                else
                {
                    throw new Exception(" большое число уровней ");

                }
            }
            catch (Exception ex)
            {
                Form1 sms = this.Owner as Form1;
                string mes = ex.Message;
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();
                sms.richTextBox1.Text += mes + " " + date + " " + time + "\r\n";
                Close();
            }
           


        }
        private void  i( int alpha)
        {
            while( alpha< (int)numericUpDown2.Value)
            {
                alpha++;

            }
        }

        public int serpinsk(double x,double y, double dlina,int N)
        {
                                                   //   Graphics g = Graphics.FromImage(bit);
            if (N > 0)
            {
                double x1, y1;
                x1 = (x -dlina *0.225) ;
                y1 = (y - dlina * 0.255);

                    double X0 = x1;
                    double Y0 = y1;
      
                double x2, y2;
                x2 = (x + dlina * 0.775);
                y2 = (y + dlina * 0.775);

                double x3, y3;
                x3 = (x - dlina * 0.225);
                y3 = (y + dlina * 0.775);

                double x4, y4;
                x4 = (x + dlina * 0.775);
                y4 = (y - dlina * 0.225);
                //Random r=new Random();
                SolidBrush mySolidBrush = new SolidBrush(Color.FromArgb(alpha, alpha, 0, 0));
                pen.Width = (float)(numericUpDown1.Value * N / 2);
                g.DrawRectangle(pen,  (float)x, (float)y, (float)dlina, (float)dlina);
                
                g.FillRectangle(mySolidBrush, new Rectangle((int)x, (int)y, (int)dlina, (int)dlina));

                // g.DrawRectangle(pen, (float)X0, (float)Y0, (float)dlina, (float)dlina);
                // x = x1;
                //y = y1;
                //  serpinsk(x,y,dlina,N);
                //  g.DrawRectangle(Pens.Red, (float)x1, (float)y1, (float)dlina, (float)dlina);
                // x1 = x2;
                // y1 = y2;
                for (int i = 1; i < 1; i++)
                {
                    serpinsk(X0, Y0, dlina / N, N - 1);
                }

                // serpinsk(x,y,dlina,N-1);
              
                serpinsk(x1, y1, dlina*0.45, N-1);
                serpinsk(x2, y2, dlina*0.45, N-1);
                serpinsk(x3, y3, dlina*0.45, N-1);
                serpinsk(x4, y4, dlina*0.45, N-1);

            }

           // g.Dispose();
            pictureBox1.Image = bit;
            return 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
