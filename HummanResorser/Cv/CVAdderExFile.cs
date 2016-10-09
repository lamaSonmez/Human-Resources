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
    public partial class CVAdderExFile : DevComponents.DotNetBar.Metro.MetroForm
    {
        string[] NameCol = { "الاسم", "تاريخ تقديم الطلب", "السنة", "رقم الهاتف", "ملاحظات", "رقم", "رمز", "id_team"};

        public CVAdderExFile()
        {
            InitializeComponent();
        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {
    
          ClassDataGridViewDo.ClumChekArray(NameCol, dataGridViewX1);
            /*
                try{
              for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
              {
                  string fullname =Convert.ToString(  dataGridViewX1.Rows[i].Cells[NameCol[0]].Value);
                  DateTime? date = ClassConvert.ConvDateTimeNull(dataGridViewX1.Rows[i].Cells[NameCol[1]].Value);
                  int year_sf  =ClassConvert.ConvToStady(  dataGridViewX1.Rows[i].Cells[NameCol[2]].Value);
                  int phone = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[NameCol[3]].Value);
                  string notes  =Convert.ToString(  dataGridViewX1.Rows[i].Cells[NameCol[4]].Value);
                  int nameArchev = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[NameCol[5]].Value);
                  int Id_Study =await CV_Study.CV_studyID(Convert.ToString(dataGridViewX1.Rows[i].Cells[NameCol[6]].Value));
                  int id_team = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[NameCol[7]].Value);


                  CV_Info CV_Info = new CV_Info(0, fullname, notes, nameArchev, Id_Study, year_sf, phone, date, id_team, false , );
                  await Sqldatabasethrding.SqlSaveVitl( CV_Info.adder());

              }    
            }catch(NoColumnsException ec ) {
                MegBox.Show(ec.Message);
            }*/
        }

        private void CVAdderExFile_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
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