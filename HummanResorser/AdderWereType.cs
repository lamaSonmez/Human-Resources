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
    public partial class AdderWereType : DevComponents.DotNetBar.Metro.MetroForm
    {
        bool AdderOrEdit = false;
        public WereType WereType = null;

        public AdderWereType(bool Adder, WereType WereType)
        {
            InitializeComponent();
            this.AdderOrEdit = Adder;
            this.WereType = WereType;
            if (AdderOrEdit)
            {
                this.Text = "اضافة مناصب";
                this.buttonX1.Text = "إضافة";
            }
            else
            {
                this.Text = "تعديل مناصب";
                this.buttonX1.Text = "تعديل";

                textBoxX1.Text = WereType.WareName;
                textBoxX2.Text = WereType.descrption;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text.Trim() != "" && textBoxX2.Text.Trim() != "")
            {
                if (AdderOrEdit)
                {

                    WereType = new WereType(0, textBoxX1.Text, textBoxX2.Text);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    this.Text = "تعديل مناصب";
                    this.buttonX1.Text = "تعديل";
                    WereType = new WereType(WereType.id, textBoxX1.Text, textBoxX2.Text);


                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }

            }
            else
            {
                MegBox.Show("أحد الحقول فارغه");
            }
        }

        private void AdderWereType_Load(object sender, EventArgs e)
        {

        }
    }
}