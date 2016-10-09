using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HummanResorser
{
    partial class AboutBox1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        string fe = "https://www.facebook.com/MANXVW";
        string fe1 = "WhatsApp: 0940267805";
        int index = 0;
        int indexRa = 0;
        int indexmo = 0;
        string StringnameRama = "الكوراني راما";
        string StringMo = "عثمان ملا محمد";
        string All = "<b><font size=\"+10\"><font color=\"#B02B2C\">";
        string All1 = "</font></font></b>";
        string stringraAfter = "";
        string StringMoAfter = "";

        string F1 = "قام بهذا البرنامج";
        string F2 = "فكرة وتنسيق";
        string F3 = "تصميم و برمجة";
        int F1Index = 0;
        int F2Index = 0;
        int F3Index = 0;
        public AboutBox1()
        {
            InitializeComponent();
        }


        private async void AboutBox1_Load(object sender, EventArgs e)
        {
           
            timer7.Enabled = true;
            await Task.Delay(new TimeSpan(0, 0, 2));
            timer1.Enabled = true;
           
            timer3.Enabled = true;

            await Task.Delay(new TimeSpan(0, 0, 1));
            timer4.Enabled = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (index < fe.Length)
                linkLabel1.Text += fe[index++];
            else
            {
               
               index = 0;
                timer1.Enabled = false;
                timer2.Enabled = true;
            }

        }

        private void radialMenu1_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
             
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (index < fe1.Length)
                linkLabel2.Text += fe1[index++];
            else
            {
            
                index = 0;
                timer2.Enabled = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (indexRa < StringnameRama.Length)
            {
                stringraAfter += StringnameRama[indexRa++];
                reflectionLabel1.Text = All + stringraAfter + All1;
            }
            else
            {

                indexRa = 0;
                timer3.Enabled = false;
            }
        }

        private async void reflectionLabel1_Click(object sender, EventArgs e)
        {
    
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (indexmo < StringMo.Length)
            {
                StringMoAfter += StringMo[indexmo++];
                reflectionLabel2.Text = All + StringMoAfter + All1;
            }
            else
            {

                indexmo = 0;
                timer4.Enabled = false;
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (F1Index < F1.Length)
            {

                labelX1.Text += F1[F1Index++];
            }
            if (F2Index < F2.Length)
            {

                labelX3.Text += F2[F2Index++];
            }
            if (F3Index < F3.Length)
            {

                labelX4.Text += F3[F3Index++];
            }

        }
    }
}
