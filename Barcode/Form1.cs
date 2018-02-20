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
using System.Drawing.Imaging;

namespace Barcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string brcode = textBox1.Text;
            Bitmap bitmap = new Bitmap(brcode.Length * 40, 150);
            using(Graphics graphics = Graphics.FromImage(bitmap))
            {            
            Font ofont = new System.Drawing.Font("IDAutomationHC39M", 20);
            PointF point = new PointF(2f, 2f);
            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush white = new SolidBrush(Color.White);
            graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
            graphics.DrawString(brcode , ofont, black, point);

            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                pictureBox1.Image = bitmap;
                pictureBox1.Height = bitmap.Height;
                pictureBox1.Width = bitmap.Width;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
