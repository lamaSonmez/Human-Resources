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
    public partial class CVadderStudy : DevComponents.DotNetBar.Metro.MetroForm
    {
        CV_Study CV_Study = null;
        public CVadderStudy(CV_Study CV_Study = null)
        {
            InitializeComponent();
            this.CV_Study = CV_Study;

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void CVadderStudy_Load(object sender, EventArgs e)
        {
            
                    if ( CV_Study == null)
             {
            this.Text = "إضافة";
            buttonX1.Text = "إضافة";


             }else
            {
                textBoxX1.Text = CV_Study.Sutdy;
                textBoxX2.Text = CV_Study.Sampl;

            }

        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            if (CV_Study == null)
            {

                if ( await CV_Study.CV_studyID(textBoxX2.Text.Trim()) ==-1)
                {
                    CV_Study = new CV_Study(0, textBoxX1.Text, textBoxX2.Text.Trim());


                    if (await Sqldatabasethrding.SqlSaveVitl(CV_Study.adder()))
                        MegBox.Show("تم الإضافة", this);
                    else
                        MegBox.Show("خطأ ", this);
                }
                else
                {
                    MegBox.Show("الرمز موجود!");
                }

            }
            else
            {
                CV_Study = new CV_Study(CV_Study.id, textBoxX1.Text, textBoxX2.Text);


                if (await Sqldatabasethrding.SqlSaveVitl(CV_Study.updata()))
                    MegBox.Show("تم الإضافة", this);
                else
                    MegBox.Show("خطأ ", this);
            }

        }
    }
}