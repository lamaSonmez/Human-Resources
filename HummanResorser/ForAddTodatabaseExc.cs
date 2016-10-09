using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.IO;

namespace HummanResorser
{
    public partial  class ForAddTodatabaseExc : DevComponents.DotNetBar.RibbonForm
    {

        private List<Vitl> LIstvitl = new List<Vitl>(); 
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        public ForAddTodatabaseExc()
        {
            InitializeComponent();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "*.xlsx | *.xlsx";
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = OpenFileDialog1.FileName;


                string extension = Path.GetExtension(filePath);
                string header = "YES";
                string conStr, sheetName;

                conStr = string.Empty;
                switch (extension)
                {

                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath, header);
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(Excel07ConString, filePath, header);
                        break;
                }

                //Get the name of the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                    }
                }

                //Read Data from the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();

                            //Populate DataGridView.
                            dataGridViewX1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            for (int n =0 ;  dataGridViewX1.Rows.Count-1 >0 ; n++)
            {
                #region Adder
                int id = 0;
                string first_name =ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[1].Value);
                string Last_name = ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[2].Value);
                string Father_name = ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[3].Value);
                string Mather_name = ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[4].Value);
                Int64 natiol_id = ClassConvert.Convint64( dataGridViewX1.Rows[n].Cells[8].Value);
                bool Gender = ClassConvert.ConvBool( dataGridViewX1.Rows[n].Cells[5].Value);
                string where_birth = ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[6].Value);
                DateTime data_barthday = ClassConvert.ConvDateTime(dataGridViewX1.Rows[n].Cells[7].Value);
                string e_mail = ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[18].Value);
                int Phone_Ground = ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[20].Value);
                int Phone_Mobile1 = ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[19].Value);
                string study = ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[9].Value);
                int yearstudy =  ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[10].Value);
                int Id_course = ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[0].Value);
                string Id_course_Ware = ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[21].Value);
                DateTime data_regs = ClassConvert.ConvDateTime(dataGridViewX1.Rows[n].Cells[17].Value);
                int bitd_id =  ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[11].Value);
                string nameEnglish = ClassConvert.ConvString( dataGridViewX1.Rows[n].Cells[12].Value);
                int Z1 =  ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[13].Value);
                int z2 =  ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[14].Value);
                int z3 =  ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[15].Value);
                string Hanei_whare = "";
                string Hanei_whare1 = "";
                string adderas = "";

                int Stutes_Jtma3 = ClassConvert.Convint(dataGridViewX1.Rows[n].Cells[16].Value);
                int Phone_Mobile2 =0;
                string Facebook ="";
                int whatsApp =0;
                int viper =0;
                string Twiter = "";
  
                System.Drawing.Image Image_id_nationl1 = null;
                System.Drawing.Image Image_id_nationl2 = null;
                System.Drawing.Image image =  null;
                System.Drawing.Image Image_font = null;

                string Nkname ="";


                System.Xml.XmlDataDocument XmlHobbies = null; ;
                /*
                string[] liststring = System.IO.Directory.GetFiles(".\\", "Hobbis1.xml", System.IO.SearchOption.AllDirectories);
                XmlHobbies.Load(liststring[0]);*/
                #endregion
              Vitl  vitltemp = new Vitl(id, first_name, Last_name, Father_name, Mather_name, natiol_id, Gender, where_birth, data_barthday, Hanei_whare, Hanei_whare1, adderas, e_mail, Stutes_Jtma3, Phone_Ground, Phone_Mobile1, Phone_Mobile2, Facebook, Twiter, whatsApp, viper, study, yearstudy, Id_course, Id_course_Ware, data_regs, Image_id_nationl1, Image_id_nationl2, image, Image_font, bitd_id, Nkname, nameEnglish, Z1, z2, z3, XmlHobbies);

                Sqldatabasethrding.SqlSaveVitl(vitltemp.adder());
            
            }

            
        }
    }
}