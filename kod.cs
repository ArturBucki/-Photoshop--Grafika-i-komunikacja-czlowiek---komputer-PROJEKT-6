using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_6
{

    public partial class Form1 : Form
    {
        Bitmap bitmap;

        int[] histR = new int[256];
        int[] histG = new int[256];
        int[] histB = new int[256];

        bool read = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Opfile = new OpenFileDialog();
            if (DialogResult.OK == Opfile.ShowDialog())
            {
                this.pictureBox1.Image = new Bitmap(Opfile.FileName);
                bitmap = (Bitmap)this.pictureBox1.Image;

                Array.Clear(histR, 0, histR.Length);
                Array.Clear(histG, 0, histG.Length);
                Array.Clear(histB, 0, histB.Length);


                histogram();
                
                read = true;
                panel1.Invalidate();
                panel2.Invalidate();
                panel3.Invalidate();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();


            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Color cA = bitmapEdited.GetPixel(x, y);

                    int r = cA.R;
                    int g = cA.G;
                    int b = cA.B;


                    // R
                    if (r < 127 + trackBar1.Value)
                    {
                        r = (127 / (127 + trackBar1.Value)) * r;
                    }
                    else if (r > 127 - trackBar1.Value)
                    {
                        r = (127 * r + 255 * trackBar1.Value) / (127 + trackBar1.Value);
                    }
                    else
                    {
                        r = 127;
                    }

                    // G
                    if (g < 127 + trackBar1.Value)
                    {
                        g = (127 / (127 + trackBar1.Value)) * g;
                    }
                    else if (g > 127 - trackBar1.Value)
                    {
                        g = (127 * g + 255 * trackBar1.Value) / (127 + trackBar1.Value);
                    }
                    else
                    {
                        g = 127;
                    }

                    // B
                    if (b < 127 + trackBar1.Value)
                    {
                        b = (127 / (127 + trackBar1.Value)) * b;
                    }
                    else if (b > 127 - trackBar1.Value)
                    {
                        b = (127 * b + 255 * trackBar1.Value) / (127 + trackBar1.Value);
                    }
                    else
                    {
                        b = 127;
                    }

                    bitmapEdited.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = bitmapEdited;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();


            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color cA = bitmapEdited.GetPixel(x, y);

                    int r = cA.R;
                    int g = cA.G;
                    int b = cA.B;


                    r = (127 / (127 - trackBar2.Value)) * (r - trackBar2.Value);
                    g = (127 / (127 - trackBar2.Value)) * (g - trackBar2.Value);
                    b = (127 / (127 - trackBar2.Value)) * (b - trackBar2.Value);

                    if (r < 0)
                    {
                        r = 0;
                    }
                    if (g < 0)
                    {
                        g = 0;
                    }
                    if (b < 0)
                    {
                        b = 0;
                    }
                    if (r > 255)
                    {
                        r = 255;
                    }
                    if (g > 255)
                    {
                        g = 255;
                    }
                    if (b > 255)
                    {
                        b = 255;
                    }


                    bitmapEdited.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = bitmapEdited;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();


            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color cA = bitmapEdited.GetPixel(x, y);

                    double r = (double)cA.R;
                    double g = (double)cA.G;
                    double b = (double)cA.B;

                    double r1, g1, b1;
                    r1 = (127 + trackBar3.Value) * r;
                    r1 = r1 / 127;

                    r1 = r1 - trackBar3.Value;

                    g1 = (127 + trackBar3.Value) * g;
                    g1 = g1 / 127;

                    g1 = g1 - trackBar3.Value;

                    b1 = (127 + trackBar3.Value) * b;
                    b1 = b1 / 127;

                    b1 = b1 - trackBar3.Value;


                    bitmapEdited.SetPixel(x, y, Color.FromArgb((int)r1, (int)g1, (int)b1));
                }
            }

            pictureBox1.Image = bitmapEdited;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();


            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Color cA = bitmapEdited.GetPixel(x, y);

                    int r = cA.R;
                    int g = cA.G;
                    int b = cA.B;


                    // R
                    if (r < 127)
                    {
                        r = ((127 - trackBar4.Value) * r) / 127;
                    }
                    else
                    {
                        r = ((127 - trackBar4.Value) * r) / 127 + 2 * trackBar4.Value;
                    }

                    // G
                    if (g < 127)
                    {
                        g = ((127 - trackBar4.Value) * g) / 127;
                    }
                    else
                    {
                        g = ((127 - trackBar4.Value) * g) / 127 + 2 * trackBar4.Value;
                    }

                    // B
                    if (b < 127)
                    {
                        b = ((127 - trackBar4.Value) * b) / 127;
                    }
                    else
                    {
                        b = ((127 - trackBar4.Value) * b) / 127 + 2 * trackBar4.Value;
                    }

                    bitmapEdited.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = bitmapEdited;
        }


        private void histogram()
        {
            int width = pictureBox1.Image.Width;
            int height = pictureBox1.Image.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color cA = bitmap.GetPixel(x, y);

                    int r = cA.R;
                    int g = cA.G;
                    int b = cA.B;

                    histR[r]++;
                    histG[g]++;
                    histB[b]++;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(read == true)
            {
                Graphics graphR = e.Graphics;
                
                for (int i = 0; i < 256; i++)
                {
                    float r = histR[i];

                    r = r / (pictureBox1.Image.Height * pictureBox1.Image.Width);
                    r *= 6000;

                    graphR.DrawLine(new Pen(Color.Red), i, panel1.Height, i, panel1.Height - r);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (read == true)
            {
                Graphics graphR = e.Graphics;

                for (int i = 0; i < 256; i++)
                {
                    float r = histG[i];

                    r = r / (pictureBox1.Image.Height * pictureBox1.Image.Width);
                    r *= 6000;

                    graphR.DrawLine(new Pen(Color.Green), i, panel1.Height, i, panel1.Height - r);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (read == true)
            {
                Graphics graphR = e.Graphics;

                for (int i = 0; i < 256; i++)
                {
                    float r = histB[i];

                    r = r / (pictureBox1.Image.Height * pictureBox1.Image.Width);
                    r *= 6000;

                    graphR.DrawLine(new Pen(Color.Blue), i, panel1.Height, i, panel1.Height - r);
                }
            }
        }
    }
}
