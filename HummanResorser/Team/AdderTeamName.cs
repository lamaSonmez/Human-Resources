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

    
    public partial class AdderTeamName : DevComponents.DotNetBar.Metro.MetroForm
    {


        public NameTeam NameTeam = null;

        public AdderTeamName(NameTeam NameTeam )
        {
           
            InitializeComponent();
            this.NameTeam = NameTeam;
            

        }

        private void AdderTeamName_Load(object sender, EventArgs e)
        {

          ClassDataGridViewDo.DataGridAddVuleComBoxEx (comboBoxEx1,NameTeamType.NameTeamTypeStatic);

            if (NameTeam == null)
            {
                buttonX1.Text = "إضافة";
                this.Text = "إضافة الفريق";
            }
            else
            {
                textBoxX1.Text = NameTeam.nameOftame;
                comboBoxEx1.SelectedIndex =ClassDataGridViewDo.RetunIndexByIdSech(NameTeam.NameTeamType_Id, NameTeamType.NameTeamTypeStatic);
                buttonX1.Text = "تعديل";
                this.Text = "تعديل الفريق";
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (NameTeam == null)
            {
                if (comboBoxEx1.SelectedIndex != -1)
                {
                    NameTeam = new NameTeam(0, textBoxX1.Text, NameTeamType.NameTeamTypeStatic[Convert.ToInt32(comboBoxEx1.SelectedIndex)].id);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MegBox.Show("يجب إختيار نوع الفريق من القائمة", this);
                }
            }else
            {
                if (comboBoxEx1.SelectedIndex != -1)
                {
                    NameTeam = new NameTeam(NameTeam.id, textBoxX1.Text, NameTeamType.NameTeamTypeStatic[Convert.ToInt32(comboBoxEx1.SelectedIndex)].id);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MegBox.Show("يجب إختيار نوع الفريق من القائمة", this);
                }

            }
        }
    }
}