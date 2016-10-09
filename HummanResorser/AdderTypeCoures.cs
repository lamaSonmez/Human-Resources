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
    public partial class AdderTypeCoures : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AdderTypeCoures()
        {
            InitializeComponent();
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "" && comboBoxEx1.SelectedIndex != -1)
            {

                TypeofCouress Type1 = new TypeofCouress(0, textBoxX1.Text,NameTeam.NameTeamStatic[comboBoxEx1.SelectedIndex].id);

                if (await Sqldatabasethrding.SqlSaveVitl(Type1.adder()))
                {
                    
                
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {


                }


            }
            else
            {
                MegBox.Show("أحد الحقول فارغه");
            }
            
        }

        private void AdderTypeCoures_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, NameTeam.NameTeamStatic);
        }
    }
}