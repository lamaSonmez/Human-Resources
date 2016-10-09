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
    public partial class Test : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Test()
        {
            InitializeComponent();
        }

        private async void Test_Load(object sender, EventArgs e)
        {
            ParamterrMakeSql Parm = new ParamterrMakeSql();
            Parm.AdderParmtaer(Vitl.vitl.data_barthday, new DateTime(2000,1,1) , ParamterrMakeSql.Condtion.lessThen , ParamterrMakeSql.Between.And);
            Parm.AdderinnerJoin(new EnumInnder(Sqldatabasethrding.DataBaseTabName.Couress_ta, Sqldatabasethrding.DataBaseTabName.Information_Ta, Vitl.vitl.id, Sqldatabasethrding.DataBaseTabName.Couress_ta, Couress.EnumCouress.Id_Information));

            Parm.AdderinnerJoin(new EnumInnder(Sqldatabasethrding.DataBaseTabName.Team_ta, Sqldatabasethrding.DataBaseTabName.Information_Ta, Vitl.vitl.id, Sqldatabasethrding.DataBaseTabName.Team_ta, Team.EnumTeam.ID_informtion));

            Parm.AdderOutPut(Vitl.vitl.id ,Sqldatabasethrding.DataBaseTabName.Information_Ta);
            Parm.AdderOutPut(Vitl.vitl.Gender);
            Parm.AdderOutPut(Vitl.vitl.first_name);
            Parm.AdderOutPut(Vitl.vitl.Last_name);
       

 //    List<List<object>> list = await    Sqldatabasethrding.GetSql( Vitl.SqlFildRetunFormList(Parm));
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand fe = new System.Data.SqlClient.SqlCommand("  SELECT  [HR_SARC].[dbo].[Information_Ta].[Id] ,[HR_SARC].[dbo].[Information_Ta].[first_name]+ N' '+ [HR_SARC].[dbo].[Information_Ta].[Last_name] as fullname  , study , yearstudy,data_regs FROM [HR_SARC].[dbo].[Information_Ta]  where  [HR_SARC].[dbo].[Information_Ta].study like @study and [Delete] = 0 ");

            System.Data.SqlClient.SqlCommand fce = new System.Data.SqlClient.SqlCommand("  SELECT  [HR_SARC].[dbo].[Information_Ta].[Id] FROM [HR_SARC].[dbo].[Information_Ta] INNER JOIN  [HR_SARC].[dbo].[Couress_ta] ON  [HR_SARC].[dbo].[Information_Ta].[Id] =  [HR_SARC].[dbo].[Couress_ta].[Id_Information] where  [HR_SARC].[dbo].[Couress_ta].[id_NameOfCouress] = 1003 and [HR_SARC].[dbo].[Information_Ta].[Delete] = 0 ");
 
            string       stringx = ClassDataGridViewDo.LograthemChangEverAleffToAll("تصاد", true);

            fce.Parameters.AddWithValue("@study", "%" + stringx + "%");
            fe.Parameters.AddWithValue("@study", "%" + stringx + "%");

     List<List<object>> ef = await Sqldatabasethrding.GetSql(fe);

     List<List<object>> ef1 = await Sqldatabasethrding.GetSql(fce);

            for (int i = 0; i < ef.Count; i++)
			{
                dataGridViewX1.Rows.Add(ef[i][0].ToString(), ef[i][1].ToString(), ef[i][2].ToString(), ef[i][3].ToString(), "", Convert.ToDateTime(ef[i][4]).ToShortDateString(), Convert.ToDateTime(ef[i][4]).ToLongDateString());
			}
            for (int i = 0; i < ef1.Count; i++)
            {
                for (int  j = 0; j < dataGridViewX1.Rows.Count; j++)
                {
                    if (ef1[i][0].ToString() == dataGridViewX1.Rows[j].Cells[0].Value.ToString())
                    {
                        dataGridViewX1.Rows[j].Cells[4].Value = "كوارث"; break;
                    }
                }
                
            }
        }
    }
}