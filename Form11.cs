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
    public partial class Form11 : Form
    {
        public Bitmap bit;
        public Graphics g;
        public Pen pen;
        public Pen pen1;
        public int alpha = 1;
        public int alpha1 = 255;
        public Form11(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
            this.Load += Form11_Load;
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bit);
            
          
        }

        public void Treug(int xa, int ya, int xb, int yb, int xc, int yc, int n)
        {
            Form1 sms = this.Owner as Form1;
            try
            {
                g = Graphics.FromImage(bit);
                pen = new Pen(Color.BurlyWood, 2f);
                pen1 = new Pen(Color.BlueViolet, 4f);
                int alpha = 255;
                int alpha1 = 0;
                pen.Color = Color.FromArgb(alpha--, alpha1++, 255 / 3, 0);
                pen1.Color = Color.FromArgb(alpha--, alpha--, 0, 0);

                int xp, xq, xr, yp, yq, yr;
                // SolidBrush mySolidBrush = new SolidBrush(Color.FromArgb(alpha, alpha--, 0, 0));
                if (n > 0)
                {
                    int c = 100;
                    pen.Width = 5F / (c / 20);
                    xp = (xb + xc) / 2; yp = (yb + yc) / 2;
                    xq = (xa + xc) / 2; yq = (ya + yc) / 2;
                    xr = (xb + xa) / 2; yr = (yb + ya) / 2;

                    g.DrawLine(pen1, (float)xa, (float)ya, (float)xb, (float)yb);
                    g.DrawLine(pen1, (float)xa, (float)ya, (float)xc, (float)yc);
                    g.DrawLine(pen1, (float)xb, (float)yb, (float)xc, (float)yc);

                    g.DrawLine(pen, (float)xp, (float)yp, (float)xq, (float)yq);
                    g.DrawLine(pen, (float)xp, (float)yp, (float)xr, (float)yr);
                    g.DrawLine(pen, (float)xr, (float)yr, (float)xq, (float)yq);


                    //g.DrawLine(pen, (float)xa, (float)ya, (float)xb, (float)yb);


                    Treug(xa, ya, xb, yb, xr, yr, n - 1);
                    Treug(xa, ya, xr, yr, xq, yq, n - 1);
                    Treug(xb, yb, xp, yp, xr, yr, n - 1);
                    Treug(xc, yc, xq, yq, xp, yp, n - 1);

                }
                pictureBox1.Image = bit;
                return;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();

                sms.richTextBox1.Text += mes + " " + date + " " + time + "\r\n";
                Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { if (textBox1.Text != null && Convert.ToInt32(textBox1.Text)<8) {

                    pictureBox1.BackgroundImage = bit;
                    Treug(pictureBox1.Width / 10, pictureBox1.Height - pictureBox1.Height / 10, pictureBox1.Width / 2, pictureBox1.Height / 10,
                        pictureBox1.Width - pictureBox1.Width / 10, pictureBox1.Height - pictureBox1.Height / 10, Convert.ToInt32(textBox1.Text));
                }

                else { throw new Exception(" error "); }
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

    }
}

