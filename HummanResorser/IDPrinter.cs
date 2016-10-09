using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace HummanResorser
{
    public partial class IDPrinter : DevComponents.DotNetBar.Metro.MetroForm
    {

        Vitl vitle;

        public IDPrinter( Vitl vitle)
        {
            this.vitle = vitle;
            InitializeComponent();
            pictureBox1.ImageLocation = @"C:\Users\sarc-12\Desktop\ID-Card.jpg";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
           
           if (  vitle.image != null)
           {
               var bitmap = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);

               using (var canvas = Graphics.FromImage(bitmap))
               {


                   canvas.DrawImage(pictureBox1.Image, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height));
                   canvas.DrawImage(vitle.image, new Rectangle(150, 150, 200, 250));
                   canvas.DrawString(vitle.first_name, new Font("Bold Italic Art", 16), new SolidBrush(Color.Red ), new PointF(200f, 400f));
            
                   canvas.Save();
                   pictureBox1.Image = bitmap;
               }
           }

        }
    }
}