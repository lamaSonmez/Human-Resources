using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace HummanResorser
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public List<string> listString1 = new List<string>();
        public List<string> listStringNkname1 = new List<string>();
        public List<string> listStringNkname2 = new List<string>();

        DataSet Dat = new DataSet();
        public Form1()
        {
            InitializeComponent();

            listStringNkname2.Add("الأسم الأول");//0
            listStringNkname2.Add("الشهرة");//1
            listStringNkname2.Add("أسم الأب");//2
            listStringNkname2.Add("أسم الأم");//3
            listStringNkname2.Add("رقم الوطني");//4
            listStringNkname2.Add("الجنس");//5
            listStringNkname2.Add("محل الولادة");//6
            listStringNkname2.Add("تاريخ الولادة");//7
            listStringNkname2.Add("الامانة");//8
            listStringNkname2.Add("القيد");//9
            listStringNkname2.Add("العنوان");//10
            listStringNkname2.Add("البريد الألكتروني");//11
            listStringNkname2.Add("الحالة الاجتماعية");//12
            listStringNkname2.Add("رقم هاتف أرضي");//13
            listStringNkname2.Add("رقم هاتف موبايل 1");//14
            listStringNkname2.Add("رقم هاتف موبايل 2");
            listStringNkname2.Add("Facebook");
            listStringNkname2.Add("Twiter");
            listStringNkname2.Add("whatsApp");
            listStringNkname2.Add("viper");
            listStringNkname2.Add("الدراسة");
            listStringNkname2.Add("السنه الدراسة");
            listStringNkname2.Add("ID_Course");
            listStringNkname2.Add("الفرع");
            listStringNkname2.Add("تاريخ التسجيل في هلال");
            listStringNkname2.Add("صورة عن هاوية الأول");
            listStringNkname2.Add("صورة عن هاوية الثاني");
            listStringNkname2.Add("صورة المتطوع");
            listStringNkname2.Add("صورة أمامية ID متطوع");
            listStringNkname2.Add("زمرة الدم");
            listStringNkname2.Add("الأسم المستعار");
            listStringNkname2.Add("الأسم بالإنكليزي");
            listStringNkname2.Add("مقاس الخصر");
            listStringNkname2.Add("مقاس القدم");
            listStringNkname2.Add("مقاس الكتفين");
            listStringNkname2.Add("الهويات");

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //35
            OpenFileDialog S = new OpenFileDialog () ;
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
               
              
                sda.Fill(Dat);
                
                sda.Fill(data);
         
                dataGridViewX1.DataSource = data;
            }
        }
        delegate void buttn();
        delegate void Prosser(int i);
        void NewProsserVaul(int i)
        {
            progressBarX1.Value = i;

        }

        void Endbuttonx2 ()
        {
            buttonX2.Enabled = true;

        }
        private   void buttonX2_Click(object sender, EventArgs e)
        {
            progressBarX1.Maximum = dataGridViewX1.Rows.Count - 1;
            buttonX2.Enabled = false;
            dataGridViewX1.Enabled = false;
           
          foreach(DataColumn Column in   Dat.Tables[0].Columns)
          {
              if (listStringNkname2.IndexOf(Column.ColumnName) != -1)
                  listStringNkname1.Add(listStringNkname2[listStringNkname2.IndexOf(Column.ColumnName)]);


          }
          MessageBoxEx.Show("الرجاء الإنتظار ....");

  //        Task.Run(() => { 
          if (!checkBox2.Checked)
          {
              for (int i = 0; i < dataGridViewX1.Rows.Count - 1; i++)
              {
                  progressBarX1.BeginInvoke(new Prosser(NewProsserVaul), i);

                  if (ClassConvert.Convint64(dataGridViewX1.Rows[i].Cells[listStringNkname2[4]].Value) > 0)
                  {
                      if (Vitl.GetIf(ClassConvert.Convint64(dataGridViewX1.Rows[i].Cells[listStringNkname2[4]].Value)))
                      {
                          SaveMyVitlNew(i);
                          goto end;
                      }
                      else
                          goto end;
                  }

                  if (Convert.ToString(dataGridViewX1.Rows[i].Cells[listStringNkname2[11]].Value) != "")
                  {
                      if (Vitl.GetIfEmail(Convert.ToString(dataGridViewX1.Rows[i].Cells[listStringNkname2[11]].Value)))
                      {
                          SaveMyVitlNew(i);
                          goto end;
                      }
                      else
                          goto end;
                  }

                  if (ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname2[14]].Value) != 0)
                  {
                      if (Vitl.GetIfmobilephon(ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname2[11]].Value)))
                      {
                          SaveMyVitlNew(i);
                          goto end;
                      }
                      else
                          goto end;
                  }

                  SaveMyVitlNew(i);
              end: ;
              }
          }
          else
          {
              for (int i = 0; i < dataGridViewX1.Rows.Count - 1; i++)
              { SaveMyVitlNew(i); }

          }
             //  dataGridViewX1.Enabled = true;
               buttonX2.BeginInvoke(new buttn(Endbuttonx2));
  //        });
         
                }

        private  void SaveMyVitlNew (int i)
        {
            int j = 0;

            int id = 0;
            string first_name = dataGridViewX1.Rows[i].Cells[listStringNkname1[j]].Value.ToString();
            string Last_name = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            string Father_name = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            string Mather_name = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            Int64 natiol_id = ClassConvert.Convint64(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            bool? Gender = ClassConvert.ConvBoolMelaFemalNUll(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            string where_birth = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            DateTime data_barthday = ClassConvert.ConvDateTime(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            string Hanei_whare = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            string Hanei_whare1 = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            string adderas = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            string e_mail = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            int Stutes_Jtma3 = ClassConvert.ConvToStatesF(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            int Phone_Ground = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            int Phone_Mobile1 = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            int Phone_Mobile2 = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            string Facebook = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            int whatsApp = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            int viper = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            string Twiter = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            string study = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            int yearstudy = ClassConvert.ConvToStady(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value); ;
            int Id_course = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            string Id_course_Ware = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            DateTime data_regs = ClassConvert.ConvDateTime(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            System.Drawing.Image Image_id_nationl1 = null;
            System.Drawing.Image Image_id_nationl2 = null;
            System.Drawing.Image image = null;
            System.Drawing.Image Image_font = null;

            int bitd_id = ClassConvert.ConvintBoloed(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            string Nkname = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            string nameEnglish = dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value.ToString();
            int Z1 = ClassConvert.ConvSizeToint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            int z2 = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            int z3 = ClassConvert.ConvSizeToint(dataGridViewX1.Rows[i].Cells[listStringNkname1[++j]].Value);
            System.Xml.XmlDataDocument XmlHobbies = null;



            Vitl vitl1 = new Vitl(id, first_name, Last_name, Father_name, Mather_name, natiol_id, Gender, where_birth, data_barthday, Hanei_whare, Hanei_whare1, adderas, e_mail, Stutes_Jtma3, Phone_Ground, Phone_Mobile1, Phone_Mobile2, Facebook, Twiter, whatsApp, viper, study, yearstudy, Id_course, Id_course_Ware, data_regs, Image_id_nationl1, Image_id_nationl2, image, Image_font, bitd_id, Nkname, nameEnglish, Z1, z2, z3, XmlHobbies);

            Sqldatabasethrding.SqlSaveAdderAndBack(vitl1);
        }
        private void buttonX3_Click(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
          for ( int i = 0 ; i < dataGridViewX1.Rows.Count ; i ++)
          {
             if (string.IsNullOrEmpty( Convert.ToString( dataGridViewX1.Rows[i].Cells[listStringNkname2[1]].Value)) )
             {
                 string Temp = Convert.ToString(dataGridViewX1.Rows[i].Cells[listStringNkname2[0]].Value);
                    Temp =ClassDataGridViewDo.Trimall(Temp);
             string [] StrTemp =    Temp.Split(Convert.ToChar ( Keys.Space));
                 if ( StrTemp.Length == 2 )
                 {
                     dataGridViewX1.Rows[i].Cells[listStringNkname2[0]].Value = StrTemp[0];
                       dataGridViewX1.Rows[i].Cells[listStringNkname2[1]].Value = StrTemp[1];
                 }
             }


          }
        }

        private void buttonX3_Click_1(object sender, EventArgs e)
        {
            if (!dataGridViewX1.Columns.Contains("موجودأم لا"))
                dataGridViewX1.Columns.Add("موجودأم لا", "موجودأم لا");

            for (int i = 0; i < dataGridViewX1.Rows.Count - 1; i++)
            {
                progressBarX1.BeginInvoke(new Prosser(NewProsserVaul), i);

                if (ClassConvert.Convint64(dataGridViewX1.Rows[i].Cells[listStringNkname2[4]].Value) > 0)
                {
                    if (Vitl.GetIf(ClassConvert.Convint64(dataGridViewX1.Rows[i].Cells[listStringNkname2[4]].Value)))
                    {
                        dataGridViewX1.Rows[i].Cells["موجودأم لا"].Value = "غير موجود رقم وطني";
                        goto end;
                    }
                    else
                    {
                        dataGridViewX1.Rows[i].Cells["موجودأم لا"].Value = "موجود رقم وطني";
                        goto end;
                    }
                }

                if (Convert.ToString(dataGridViewX1.Rows[i].Cells[listStringNkname2[11]].Value) != "")
                {
                    if (Vitl.GetIfEmail(Convert.ToString(dataGridViewX1.Rows[i].Cells[listStringNkname2[11]].Value)))
                    {
                        dataGridViewX1.Rows[i].Cells["موجودأم لا"].Value = "غير موجود Email";
                        goto end;
                    }
                    else
                    {
                        dataGridViewX1.Rows[i].Cells["موجودأم لا"].Value = " موجود Email";
                        goto end;
                    }
                }

                if (ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname2[14]].Value) != 0)
                {
                    if (Vitl.GetIfmobilephon(ClassConvert.Convint(dataGridViewX1.Rows[i].Cells[listStringNkname2[11]].Value)))
                    {
                        dataGridViewX1.Rows[i].Cells["موجودأم لا"].Value = " غير موجود رقم هاتف";
                        goto end;
                    }
                    else
                    {
                        dataGridViewX1.Rows[i].Cells["موجودأم لا"].Value = "موجود رقم هاتف";
                        goto end;
                    }
                }

                dataGridViewX1.Rows[i].Cells["موجودأم لا"].Value = "لا يوجد وسيلة تحقق أبدا";
            end: ;
            }
        }
        }
    
}