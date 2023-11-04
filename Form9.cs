using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;


namespace Laba_1
{
    public partial class Form9 : Form
    {
        private int mode;
        private Point movePt;
        private Point nullPt=new Point(int.MaxValue);

        private SolidBrush brush = new SolidBrush(Color.Black);
        private Pen pen=new Pen(Color.Black);
        private Point startPt;

        int A ;
        int F ;
        int nterms ;
        public Form9(Form1 f)
        {
            InitializeComponent();
            //AddOwnedForm();
            
            openFileDialog1.InitialDirectory = saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            f.BackColor = Color.White;
            this.Load += Form9_Load;
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;


        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
        private void ReversibleDraw()
        {
            Point p1=pictureBox1.PointToScreen(startPt),
            p2 = pictureBox1.PointToScreen(movePt);
            if (mode == 1)
                ControlPaint.DrawReversibleLine(p1, p2, Color.Black);
            else
                ControlPaint.DrawReversibleFrame(PtToRect(p1, p2), Color.Black,FrameStyle.Thick);


        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
           

        
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

            
                string s = openFileDialog1.FileName;
                try
                {
                    Image im = new Bitmap(s);
                    Graphics g=Graphics.FromImage(im);
                    g.Dispose();
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    pictureBox1.Image = im;

                    throw new Exception(" error ");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Файл" + s + "недопустимый формат", "ошибка");
                    Form1 sms = this.Owner as Form1;
                    string mes = ex.Message;
                    string date = DateTime.Now.ToLongDateString();
                    string time = DateTime.Now.ToLongTimeString();
                    sms.richTextBox1.Text += mes + " " + date + " " + time + "\r\n";
                    Close();


                }
                try
                {
                    pictureBox1.Image = new Bitmap(s);
                    Text = "Редактор изображений" + s;
                    saveFileDialog1.FileName = Path.ChangeExtension(s, "png");
                    openFileDialog1.FileName = "";

                    throw new Exception(" error ");
                }
                catch( Exception ex)

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string s0 = saveFileDialog1.FileName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string s = saveFileDialog1.FileName;
                    if (s.ToUpper() == s0.ToUpper())
                    {
                        s0 = Path.GetDirectoryName(s0) + "\\($$##$$.png";
                        pictureBox1.Image.Save(s0);
                        pictureBox1.Image.Dispose();

                        File.Delete(s);
                        File.Move(s0, s);
                        pictureBox1.Image = new Bitmap(s);

                    }
                    else
                    {
                        pictureBox1.Image.Save(s);
                        Text = "Редактор изображений" + s;

                    }
                    throw new Exception(" error ");
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

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g=Graphics.FromImage(pictureBox1.Image);
            g.Clear(BackColor);
            g.Dispose();
            pictureBox1.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           try {
                if (numericUpDown1.Value != 0)
                {
                    pen.Width = (int)numericUpDown1.Value;
                }
                else
                {
                    throw new Exception(" error ");
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           /* RadioButton rb=sender as RadioButton;
            if (!rb.Checked) return;
            mode = rb.TabIndex;*/
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            movePt = startPt = e.Location;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPt == nullPt) return;
            if(e.Button == MouseButtons.Left)
            {
                switch (mode)
                {
                    case 0:
                        Graphics g = Graphics.FromImage(pictureBox1.Image);
                        g.DrawLine(pen, startPt, e.Location);
                        g.Dispose();
                        startPt = e.Location;
                        pictureBox1.Invalidate();
                        pictureBox1.Update();
                        break;
                    case 1:
                        ReversibleDraw();
                        movePt = e.Location;
                        ReversibleDraw();
                        break;
                    case 2:
                        ReversibleDraw();
                        movePt = e.Location;
                        ReversibleDraw();
                        break;


                }
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        pen.DashStyle = DashStyle.Solid;
                        break;
                    case 1:
                        pen.DashCap = DashCap.Round;
                        pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                        pen.DashStyle = DashStyle.Dot;
                        break;
                    case 2:
                        pen.DashCap = DashCap.Round;
                        pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                        pen.DashStyle = DashStyle.DashDot;
                        break;
                    case 3:
                        pen.DashCap = DashCap.Round;
                        pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                        pen.DashStyle = DashStyle.DashDotDot;
                        break;
                }
            }
        }
       
         /////
        
        
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(startPt == nullPt) return;
            if (mode >= 1)
            {
                ReversibleDraw();
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                switch(mode)
                {
                    case 0:
                        g.DrawLine(pen, startPt, movePt);
                        break;
                    case 1:
                        g.DrawLine(pen, startPt, movePt);
                        break ;
                    case 2:
                        DrawFigure(PtToRect(startPt, movePt), g);
                        this.Invalidate();
                        break;

                }
                g.Dispose();
                pictureBox1.Invalidate();
            }
        }
        private void DrawFigure(Rectangle r, Graphics g)
        {
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, r);    

        }
        private Rectangle PtToRect( Point p1, Point p2)
        {
            int x=Math.Min(p1.X, p2.X), y=Math.Min(p1.Y, p2.Y);
            int w=Math.Abs(p2.X-p1.X), h=Math.Abs(p2.Y-p1.Y);   
            return new Rectangle(x, y, w, h);   
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
               
                    if (checkBox3.Checked == Enabled) { redrawFourier(); }
                    if (checkBox1.Checked == Enabled) { PILO(); }
                    if (checkBox2.Checked == Enabled) { TR(); }
                
              

        }

        private void redrawFourier()
        {
            Form1 sms = this.Owner as Form1;
            try
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                g.Clear(button6.BackColor);

                g.DrawLine(pen, 0, pictureBox1.Height / 2,
                    pictureBox1.Width, pictureBox1.Height / 2);
                g.DrawLine(pen, pictureBox1.Width / 2, 0,
                   pictureBox1.Width / 2, pictureBox1.Height);

                pen.Width = Convert.ToInt32(numericUpDown1.Value);
                pen.Color = Color.Red;
                int Interval = pictureBox1.Width;

                double yp = 0;
                double yy1 = 0;
                double yy2 = 0;
                int angle = 0;

                int xtemp = 0;
                int ytemp = pictureBox1.Height / 2;
                for (int i = 0; i < Interval; i++)
                {
                    for (int j = 1; j < nterms; j++)
                    {
                        yy1 = A / ((2 * j) - 1);
                        double arg = ((j * 2) - 1) * F * 0.01397 * angle;
                        yy2 = Math.Sin(arg);
                        yp = yp + yy1 * yy2;
                    }
                    g.DrawLine(pen, xtemp, ytemp, i, pictureBox1.Height / 2 + (int)Math.Truncate(yp));//

                    xtemp = i;
                    ytemp = pictureBox1.Height / 2 + (int)Math.Truncate(yp);

                    yp = 0;
                    angle = angle + 1;

                }
                pen.Color = Color.Black;
                g.Dispose();
                pictureBox1.Invalidate();
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        pen.DashStyle = DashStyle.Solid;
                        break;
                    case 1:
                        pen.DashCap = DashCap.Round;
                        pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                        pen.DashStyle = DashStyle.Dot;
                        break;
                    case 2:
                        pen.DashCap = DashCap.Round;
                        pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                        pen.DashStyle = DashStyle.DashDot;
                        break;
                    case 3:
                        pen.DashCap = DashCap.Round;
                        pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                        pen.DashStyle = DashStyle.DashDotDot;
                        break;

                }
                throw new Exception(" error ");
            }
            catch (Exception ex)
            {
               
                string mes = ex.Message;
                string date = DateTime.Now.ToLongDateString();
                string time = DateTime.Now.ToLongTimeString();

                sms.richTextBox1.Text += mes + "" + date + " " + time + "\r\n";
                Close();

            }
            finally
            {
                Dispose();
            }
           
        }//прямоугольные

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) 
        {

            nterms = (int)numericUpDown2.Value;//число гармоник 
           // redrawFourier();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            A=(int)numericUpDown3.Value; //значение амплитуды
           /// redrawFourier();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            F=(int)numericUpDown4.Value; ///значение частоты
           // redrawFourier();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // pictureBox1.Size = pictureBox1.Image.Size;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
            pen.Color = Color.FromArgb(trackBar1.Value * 255 / 10, Color.Red);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
            pen.Color = Color.FromArgb(trackBar2.Value * 255 / 10, Color.Green);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
            pen.Color = Color.FromArgb(trackBar3.Value * 255 / 10, Color.Blue);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }
        private void TR()//ТРЕУГОЛЬНОЕ

        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(button6.BackColor);

            g.DrawLine(pen, 0, pictureBox1.Height / 2,
                pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(pen, pictureBox1.Width/2, 0,
                pictureBox1.Width/2, pictureBox1.Height );

            pen.Width = Convert.ToInt32(numericUpDown1.Value);
            pen.Color = Color.Red;
            int Interval = pictureBox1.Width;

            double yp = 0;
            double yy1 = 0;
            double yy2 = 0;
            int angle = 0;

            int xtemp = 0;
            int ytemp = pictureBox1.Height / 2;
            for (int i = 0; i < Interval; i++)
            {
                for (int j = 1; j < nterms; j++)
                {
                    yy1 = A / (((2 * j) - 1) * ((2 * j) - 1));
                    double arg = ((j * 2) - 1) * F * 0.01397 * angle;
                    yy2 = Math.Cos(arg);
                    yp = yp + yy1 * yy2;
                }
                g.DrawLine(pen, xtemp, ytemp, i, pictureBox1.Height / 2 + (int)Math.Truncate(yp));//

                xtemp = i;
                ytemp = pictureBox1.Height / 2 + (int)Math.Truncate(yp);

                yp = 0;
                angle = angle + 1;

            }
            pen.Color = Color.Black;
            g.Dispose();
            pictureBox1.Invalidate();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case 1:
                    pen.DashCap = DashCap.Round;
                    pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case 2:
                    pen.DashCap = DashCap.Round;
                    pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case 3:
                    pen.DashCap = DashCap.Round;
                    pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
            }
        }
        private void PILO()//ПИЛООБРАЗНЫЕ
        {
          //  DravGrid();
              Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(button6.BackColor);

            g.DrawLine(pen, 0, pictureBox1.Height / 2,
                pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(pen, pictureBox1.Width / 2, 0,
               pictureBox1.Width / 2, pictureBox1.Height);

            pen.Width = Convert.ToInt32(numericUpDown1.Value);
            pen.Color = Color.Red;
            int Interval = pictureBox1.Width;

            double yp = 1;
            double yy1 = 0;
            double yy2 = 0;
            int angle = 0;

            int xtemp = 0;
            int ytemp = pictureBox1.Height / 2;
            for (int i = 0; i < Interval; i++)
            {
                for (int j = 1; j < nterms; j++)
                {
                    yy1 = 2 * A / (j ); ;
                    double arg = (2*j ) * F * 0.01397 * angle;
                    yy2 = Math.Pow(-1,j-1)*Math.Sin(arg);
                    yp = yp + yy1 * yy2;
                }
                g.DrawLine(pen, xtemp, ytemp, i, pictureBox1.Height / 2 + (int)Math.Truncate(yp));//

                xtemp = i;
                ytemp = pictureBox1.Height / 2 + (int)Math.Truncate(yp);

                yp = 0;
                angle = angle + 1;

            }
            pen.Color = Color.Black;
            g.Dispose();
            pictureBox1.Invalidate();


            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case 1:
                    pen.DashCap = DashCap.Round;
                    pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                    pen.DashStyle = DashStyle.Dot;
                    break;
                case 2:
                    pen.DashCap = DashCap.Round;
                    pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                case 3:
                    pen.DashCap = DashCap.Round;
                    pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };
                    pen.DashStyle = DashStyle.DashDotDot;
                    break;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
         /*  RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return;
            mode = rb.TabIndex;*/

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
