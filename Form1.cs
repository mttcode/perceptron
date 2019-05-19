using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;

        List<int> train_x;
        List<int> train_y;
        List<int> train_exp;

        int input_neurons = 2;
        int num_weights;
        double ro = 0.2;
        double[] weights;


        public Form1()
        {
            InitializeComponent();
        }


        double result(int set)
        {
            double res;

            res = ((train_x[set] * weights[0]) + (train_y[set] * weights[1]) + (1.0 * weights[2]));

            if (res > 0.0)
            {
                res = 1.0;
            }
            else
            {
                res = -1.0;
            }

            return res;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(400, 400);
            g = Graphics.FromImage(bmp);

            train_x = new List<int>();
            train_y = new List<int>();
            train_exp = new List<int>();

            num_weights = input_neurons + 1;
            weights = new double[num_weights];

            button1.Enabled = false;

            label2.Text = "w1 = -";
            label3.Text = "w2 = -";
            label4.Text = "w0 = -";
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //Red class
            if (radioButton1.Checked == true)
            {
                if (e.X >= 0 && e.X <= 200)
                {
                    //I.kvadrant
                    if (e.Y >= 0 && e.Y <= 200)
                    {
                        train_x.Add(e.X - 200);
                        train_y.Add(200 - e.Y);
                        train_exp.Add(1);

                        g.DrawEllipse(new Pen(Color.Red, 3), e.X, e.Y, 5, 5);

                        this.Controls.Add(pictureBox1);
                        pictureBox1.Image = bmp;

                    }
                    //III.kvadrant
                    if (e.Y >= 200 && e.Y <= 400)
                    {
                        train_x.Add(e.X - 200);
                        train_y.Add(e.Y - 200);
                        train_exp.Add(1);

                        g.DrawEllipse(new Pen(Color.Red, 3), e.X, e.Y, 5, 5);

                        this.Controls.Add(pictureBox1);
                        pictureBox1.Image = bmp;

                    }
                }

                if (e.X >= 200 && e.X <= 400)
                {
                    //II.kvadrant
                    if (e.Y >= 0 && e.Y <= 200)
                    {
                        train_x.Add(e.X - 200);
                        train_y.Add(200 - e.Y);
                        train_exp.Add(1);

                        g.DrawEllipse(new Pen(Color.Red, 3), e.X, e.Y, 5, 5);

                        this.Controls.Add(pictureBox1);
                        pictureBox1.Image = bmp;

                    }
                    //IV.kvadrant
                    if (e.Y >= 200 && e.Y <= 400)
                    {
                        train_x.Add(e.X - 200);
                        train_y.Add(e.Y - 200);
                        train_exp.Add(1);

                        g.DrawEllipse(new Pen(Color.Red, 3), e.X, e.Y, 5, 5);

                        this.Controls.Add(pictureBox1);
                        pictureBox1.Image = bmp;

                    }
                }
            }

            //Green class
            if (radioButton2.Checked == true)
            {
                if (e.X >= 0 && e.X <= 200)
                {
                    //I.kvadrant
                    if (e.Y >= 0 && e.Y <= 200)
                    {
                        train_x.Add(e.X - 200);
                        train_y.Add(200 - e.Y);
                        train_exp.Add(-1);

                        g.DrawEllipse(new Pen(Color.Green, 3), e.X, e.Y, 5, 5);

                        this.Controls.Add(pictureBox1);
                        pictureBox1.Image = bmp;

                    }
                    //III.kvadrant
                    if (e.Y >= 200 && e.Y <= 400)
                    {
                        train_x.Add(e.X - 200);
                        train_y.Add(e.Y - 200);
                        train_exp.Add(-1);

                        g.DrawEllipse(new Pen(Color.Green, 3), e.X, e.Y, 5, 5);

                        this.Controls.Add(pictureBox1);
                        pictureBox1.Image = bmp;

                    }
                }

                if (e.X >= 200 && e.X <= 400)
                {
                    //II.kvadrant
                    if (e.Y >= 0 && e.Y <= 200)
                    {
                        train_x.Add(e.X - 200);
                        train_y.Add(200 - e.Y);
                        train_exp.Add(-1);

                        g.DrawEllipse(new Pen(Color.Green, 3), e.X, e.Y, 5, 5);

                        this.Controls.Add(pictureBox1);
                        pictureBox1.Image = bmp;

                    }
                    //IV.kvadrant
                    if (e.Y >= 200 && e.Y <= 400)
                    {
                        train_x.Add(e.X - 200);
                        train_y.Add(e.Y - 200);
                        train_exp.Add(-1);

                        g.DrawEllipse(new Pen(Color.Green, 3), e.X, e.Y, 5, 5);

                        this.Controls.Add(pictureBox1);
                        pictureBox1.Image = bmp;
                    }
                }
            }

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Blue, 3);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            button1.Enabled = false;

            float y1 = -((float)weights[0] / (float)weights[1]) * (-200) - ((float)weights[2] / (float)weights[1]);
            float y2 = -((float)weights[0] / (float)weights[1]) * (200) - ((float)weights[2] / (float)weights[1]);

            if (y1 < 0 && y2 < 0)
            {
                g.DrawLine(p, 0, 200 + Math.Abs(y1), 400, 200 + Math.Abs(y2));
            }
            if (y1 < 0 && y2 > 0)
            {
                g.DrawLine(p, 0, 200 + Math.Abs(y1), 400, 200 - y2);
            }
            if (y1 > 0 && y2 < 0)
            {
                g.DrawLine(p, 0, 200 - y1, 400, 200 + Math.Abs(y2));
            }
            if (y1 > 0 && y2 > 0)
            {
                g.DrawLine(p, 0, 200 - y1, 400, 200 - y2);
            }

            this.Controls.Add(pictureBox1);
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double output;
            bool stop = true;

            button2.Enabled = true;

            for (int i = 0; i < num_weights; i++)
            {
                weights[i] = 0.0;
            }

            while (stop)
            {
                stop = false;

                for (int i = 0; i < train_exp.Count; i++)
                {
                    output = result(i);

                    if (train_exp[i] != (int)output)
                    {
                        weights[0] += ro * train_exp[i] * train_x[i];
                        weights[1] += ro * train_exp[i] * train_y[i];
                        weights[2] += ro * train_exp[i];

                        stop = false;
                    }
                }
            }

            label2.Text = "w1 = " + weights[0];
            label3.Text = "w2 = " + weights[1];
            label4.Text = "w0 = " + weights[2];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = false;

            label2.Text = "w1 = -";
            label3.Text = "w2 = -";
            label4.Text = "w0 = -";

            train_x.Clear();
            train_y.Clear();
            train_exp.Clear();

            bmp = new Bitmap(400, 400);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

        }
    }
}
