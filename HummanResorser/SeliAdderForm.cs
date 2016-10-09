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

    public partial class SeliAdderForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        Scileis Scileis = null;
        public SeliAdderForm(Scileis Scileis = null)
        {
            InitializeComponent();
            this.Scileis = Scileis;

        }

        private void SeliAdderForm_Load(object sender, EventArgs e)
        {
            if ( Scileis == null)
            {
                this.Text = "إضافة";
                buttonX1.Text = "إضافة";
            
            }
            else{
                this.Text = "تعديل";
                buttonX1.Text = "تعديل";
                textBoxX1.Text = Scileis.NameScil;
            
            }

        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {

            if (Scileis == null)
            {
                Scileis = new Scileis(0, textBoxX1.Text);
         if (  await Sqldatabasethrding.SqlSaveVitl(Scileis.adder()))
         {

             MegBox.Show("تم إضافة",this);
             this.Close();
         }

            }
            else
            {
                Scileis = new Scileis(Scileis.id, textBoxX1.Text);
              if (  await Sqldatabasethrding.SqlSaveVitl(Scileis.updata()))
              {
                  MegBox.Show("تم التعديل", this);
                  this.Close();

              }
            }

        }
    }
}