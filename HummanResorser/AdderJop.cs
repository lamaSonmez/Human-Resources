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
    public partial class AdderJop : DevComponents.DotNetBar.Metro.MetroForm
    {
        bool AdderOrEdit = false;
     public   Jop jop = null;
        public AdderJop(bool Adder , Jop jop)
        {
            InitializeComponent();
            this.AdderOrEdit = Adder;
            this.jop = jop;
            if (AdderOrEdit)
            {
                this.Text = "اضافة مناصب";
                this.buttonX1.Text = "إضافة";
            }
            else
            {
                this.Text = "تعديل مناصب";
                this.buttonX1.Text = "تعديل";

                textBoxX1.Text = jop.NvacherWord;
                textBoxX2.Text = jop.NvacherWordEng;
            }
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }
     
        private void buttonX1_Click(object sender, EventArgs e)
        {

            if (textBoxX1.Text.Trim() != "" && textBoxX2.Text.Trim() != "")
            {
                if (AdderOrEdit)
                {

                    jop = new Jop(0, textBoxX1.Text, textBoxX2.Text, false);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    this.Text = "تعديل مناصب";
                    this.buttonX1.Text = "تعديل";
                    jop = new Jop(jop.id, textBoxX1.Text, textBoxX2.Text, false);


                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }

            }
            else
            {
                MegBox.Show("أحد الحقول فارغه");
            }
        }

        private void AdderJop_Load(object sender, EventArgs e)
        {

        }
    }
}