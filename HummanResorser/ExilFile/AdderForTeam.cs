using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;

namespace HummanResorser
{
    public partial class AdderForTeam : DevComponents.DotNetBar.Metro.MetroForm
    {

        string[] NameCol = { "id" ,"تاريخ تكليفه بالعمل", "الاسم" };
        public AdderForTeam()
        {
            InitializeComponent();
        }

        private void AdderForTeam_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, NameTeam.NameTeamStatic);


        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (!dataGridViewX1.Columns.Contains("id"))
                dataGridViewX1.Columns.Add("Id", "id");

      
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
              
                if (ClassConvert.Convint(dataGridViewX1.Rows[i].Cells["id"].Value) <= 0)
                {
                    string name = Convert.ToString(dataGridViewX1.Rows[i].Cells["الاسم"].Value);

                    SerchNameBynameRetu SerchNameBynameRetu = new SerchNameBynameRetu();

                    SerchNameBynameRetu.sech = name;
                    SerchNameBynameRetu.DoWorkOff();

                    if (SerchNameBynameRetu.Id > 0)
                    {
                        dataGridViewX1.Rows[i].Cells["id"].Value = SerchNameBynameRetu.Id;

                    }
                    else
                    {
                        SerchNameBynameRetu.Text = name;
                        DialogResult t = SerchNameBynameRetu.ShowDialog();
                        if (t == System.Windows.Forms.DialogResult.OK)
                            dataGridViewX1.Rows[i].Cells["id"].Value = SerchNameBynameRetu.Id;

                        else if (t == System.Windows.Forms.DialogResult.No)
                            break;

                    }
                }
            }
        }

        private async void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {


                dataGridViewX1.Enabled = false;

                ClassDataGridViewDo.ClumChekArray(NameCol, dataGridViewX1);

               
                   int IdTheNameOfcoures = NameTeam.NameTeamStatic[comboBoxEx1.SelectedIndex].id;

         
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    int id = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells["id"].Value);
                    DateTime? NuberOfDayes = ClassConvert.ConvDateTimeNull(dataGridViewX1.Rows[i].Cells["تاريخ تكليفه بالعمل"].Value);

                    //أختبار هل الدورة مسجل عند الشخص + أنه تأكد من وجود ID


                        if (id > 0 )
                        {

                            Team CouresNew = new Team(0 ,NuberOfDayes ,null , id , IdTheNameOfcoures , 1 , 1  );

                      if (  await Sqldatabasethrding.SqlSaveVitl(CouresNew.adder()))
                            dataGridViewX1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            else
                            dataGridViewX1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            dataGridViewX1.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                        }

                    }


            
                

            }
            catch (NoColumnsException ex)
            {
                ErrorClass.SaveErrorFile(ex);
                MessageBox.Show(string.Format(" لا يوجد عامود {0} ", ex.Message));
            }
            catch (Exception ex)
            {
                ErrorClass.SaveErrorFile(ex);

            }

            buttonX3.Enabled = true;

            dataGridViewX1.Enabled = true;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //35
            OpenFileDialog S = new OpenFileDialog();
            S.Filter = " Excel | *.xlsx";
            if (S.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                @S.FileName +
                                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                OleDbConnection con = new OleDbConnection(constr);

                con.Open();
                DataTable Dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                String name = Dt.Rows[0]["TABLE_NAME"].ToString();
                OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "]", con);
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);

                DataTable data = new DataTable();

                sda.Fill(data);

                dataGridViewX1.DataSource = data;

            }
        }
    }
}