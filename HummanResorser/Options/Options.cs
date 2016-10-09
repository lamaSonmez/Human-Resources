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
    public partial class Options : DevComponents.DotNetBar.RibbonForm
    {
       
        public Options()
        {
            InitializeComponent();
        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {
            AdderTameType AdderTameType = new AdderTameType();
            if (AdderTameType.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
          await  Sqldatabasethrding.SqlSaveVitl( AdderTameType.NameTeamType.adder());
            NameTeamType.NameTeamTypeStatic = NameTeamType.GetAll();
            ClassDataGridViewDo.DataGridEnterGridFornameTeamTypeOption(dataGridViewX1, NameTeamType.NameTeamTypeStatic);
            }

        }

        private void Options_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridEnterGridFornameTeamTypeOption(dataGridViewX1, NameTeamType.NameTeamTypeStatic);
             ClassDataGridViewDo.DataGridEnterGridFornameTeamOption(dataGridViewX2, NameTeam.NameTeamStatic);
             ClassDataGridViewDo.DataGridEnterGridForJopOption(dataGridViewX3, Jop.JopStatic);
            ClassDataGridViewDo.DataGridEnterGridForTypeofCouressOption(dataGridViewX4, TypeofCouress.TypeofCouressList);
            ClassDataGridViewDo.DataGridEnterGridForWereTypeOption(dataGridViewX5, WereType.WereTypeList);
            

        }

        private void dataGridViewX2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void buttonItem1_Click(object sender, EventArgs e)
        {
            AdderTeamName AdderTeamName1 = new AdderTeamName(null);
            if ( AdderTeamName1.ShowDialog () == System.Windows.Forms.DialogResult.OK )
            {
              await  Sqldatabasethrding.SqlSaveVitl(AdderTeamName1.NameTeam.adder());
                NameTeam.NameTeamStatic =await  NameTeam.GetAll();
             ClassDataGridViewDo.DataGridEnterGridFornameTeamOption(dataGridViewX2, NameTeam.NameTeamStatic);

            }

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            AdderTypeCoures TypeCoures = new AdderTypeCoures();

            if (TypeCoures.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                TypeofCouress.TypeofCouressList = TypeofCouress.GetAll();
                ClassDataGridViewDo.DataGridEnterGridForTypeofCouressOption(dataGridViewX4, TypeofCouress.TypeofCouressList);
            }
            this.Opacity = 1;
        }

        private async void buttonItem3_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            AdderJop AdderJop = new AdderJop(true, null);

            if (AdderJop.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

              if (await Sqldatabasethrding.SqlSaveVitl(AdderJop.jop.adder()))
              {
                  Jop.JopStatic = Jop.GetAll();
                  ClassDataGridViewDo.DataGridEnterGridForJopOption(dataGridViewX3, Jop.JopStatic);

              }
              else
              {
                  MegBox.Show("خطأ بالإتصال");

              }
           
              
            }
            this.Opacity = 1;
        }

        private  async void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex > -1 )
            {
                AdderJop AdderJop = new AdderJop(false, Jop.JopStatic[e.RowIndex]);

                if (AdderJop.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (await Sqldatabasethrding.SqlSaveVitl(AdderJop.jop.updata()))
                    {
                        Jop.JopStatic = Jop.GetAll();
                        ClassDataGridViewDo.DataGridEnterGridForJopOption(dataGridViewX3, Jop.JopStatic);

                    }
                    else
                    {
                        MegBox.Show("خطأ بالإتصال");

                    }


                }
                this.Opacity = 1;
                 
                 

            }
        }

        private async void buttonItem4_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            AdderWereType AdderWereType = new AdderWereType(true, null);

            if (AdderWereType.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (await Sqldatabasethrding.SqlSaveVitl(AdderWereType.WereType.adder()))
                {
                    WereType.WereTypeList = WereType.GetAll();
                    ClassDataGridViewDo.DataGridEnterGridForWereTypeOption(dataGridViewX5, WereType.WereTypeList);

                }
                else
                {
                    MegBox.Show("خطأ بالإتصال");

                }


            }
            this.Opacity = 1;

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private async void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                AdderTeamName AdderTeamName = new AdderTeamName( NameTeam.NameTeamStatic[ClassDataGridViewDo.RetunIndexByIdSech(Convert.ToInt32(dataGridViewX2.Rows[e.RowIndex].Cells[0].Value),NameTeam.NameTeamStatic)]);

                if (AdderTeamName.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (await Sqldatabasethrding.SqlSaveVitl(AdderTeamName.NameTeam.updata()))
                    {
                        NameTeam.NameTeamStatic =  await NameTeam.GetAll();
                        ClassDataGridViewDo.DataGridEnterGridFornameTeamOption(dataGridViewX2, NameTeam.NameTeamStatic);

                    }
                    else
                    {
                        MegBox.Show("خطأ بالإتصال");

                    }


                }
                this.Opacity = 1;



            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            AssisngTeamVitl AssisngTeamVitl = new AssisngTeamVitl();
            AssisngTeamVitl.ShowDialog();
            this.Visible = true;
        }
    }
}