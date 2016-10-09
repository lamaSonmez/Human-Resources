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
    public partial class CVadderTeam : DevComponents.DotNetBar.Metro.MetroForm
    {
        CvTeamNeed CvTeamNeed = null;
        public CVadderTeam(CvTeamNeed CvTeamNeed = null)
        {
            InitializeComponent();
            this.CvTeamNeed = CvTeamNeed;

        }

        private void CVadderTeam_Load(object sender, EventArgs e)
        {
            if ( CvTeamNeed == null)
            {
                this.Text = "إضافة";
                buttonX1.Text = "إضافة";


            }else
            {
                this.Text = "تعديل";
                buttonX1.Text = "تعديل";
                textBoxX1.Text = this.CvTeamNeed.FullName;


            }

        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            if (CvTeamNeed == null)
            {

                CvTeamNeed = new CvTeamNeed(0, textBoxX1.Text);
                if (await Sqldatabasethrding.SqlSaveVitl(CvTeamNeed.adder()))
                {
                    MegBox.Show("تم الإضافة", this);
                    this.Close();

                }
                else
                {
                    MegBox.Show("هناك خطأ!", this);
                }
            }
            else
            {
                CvTeamNeed = new CvTeamNeed(CvTeamNeed.id, textBoxX1.Text);

                if (await Sqldatabasethrding.SqlSaveVitl(CvTeamNeed.updata()))
                {
                    MegBox.Show("تم تعديل", this);
                    this.Close();

                }
                else
                {
                    MegBox.Show("هناك خطأ!", this);
                }

            }

        }
    }
}