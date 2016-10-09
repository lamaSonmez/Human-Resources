using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.Diagnostics;

namespace HummanResorser
{
    public partial class CoureesExcl : DevComponents.DotNetBar.Metro.MetroForm
    {
        bool Workin = false;

        string[] NameCol = { "id", "رقم الدورة", "عدد الأيام", "النتيجة" };
        public CoureesExcl()
        {
            InitializeComponent();
        }

        private void CoureesExcl_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, TypeofCouress.TypeofCouressList);
            
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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (!dataGridViewX1.Columns.Contains("id"))
            dataGridViewX1.Columns.Add("Id", "id");

            progressBarX1.Maximum = dataGridViewX1.Rows.Count;
            for ( int i  = 0 ; i < dataGridViewX1.Rows.Count  ; i ++)
            {
                progressBarX1.Value = i;
                if (ClassConvert.Convint (dataGridViewX1.Rows[i].Cells["id"].Value) <= 0)
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
                      DialogResult t=  SerchNameBynameRetu.ShowDialog();
                        if (t == System.Windows.Forms.DialogResult.OK)
                            dataGridViewX1.Rows[i].Cells["id"].Value = SerchNameBynameRetu.Id;

                       else if ( t ==System.Windows.Forms.DialogResult.No)
                            break;

                    }
                }
            }

        }

        private  void buttonX3_Click(object sender, EventArgs e)
        {
            //من أجل إيقاف العمل في خلفية
            Workin = true;

            buttonX3.Enabled = false;
            if (comboBoxEx1.SelectedIndex == -1 )
            {
                MessageBox.Show("لم يتم تحديد النوع");
                return;
            }
            ForRunThrading();
        
          
        }

        public async void ForRunThrading()
        {
            try
            {


                        dataGridViewX1.Enabled = false;

                ClassDataGridViewDo.ClumChekArray(NameCol, dataGridViewX1);
            progressBarX1.Maximum = dataGridViewX1.Rows.Count;
            int IndexCombox = comboBoxEx1.SelectedIndex;
                Stopwatch stopwatch = new Stopwatch();
      
                stopwatch.Start();
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    
                    stopwatch.Restart();
                    // إيقاف العمل في خلفية التزامن
                    if (!Workin)
                        break;
                    //العداد
                    progressBarX1.Value = i; 
                    // إنتظار بين الأمر والثاني
                         await System.Threading.Tasks.Task.Delay(100);
                


                  

                    int id = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells["id"].Value);
                    int NumberOfCoures = ClassConvert.Convint(dataGridViewX1.Rows[i].Cells["رقم الدورة"].Value);
                    int? NuberOfDayes = ClassConvert.ConvintNull(dataGridViewX1.Rows[i].Cells["عدد الأيام"].Value);
                    float? float1 = ClassConvert.ConvFloatNull(dataGridViewX1.Rows[i].Cells["النتيجة"].Value);
                    //أختبار هل الدورة مسجل عند الشخص + أنه تأكد من وجود ID
                    if (!await Couress.GetIsItHaveCouresByIdInformation(id, IndexCombox))
                    {

                        if (id > 0 && NumberOfCoures > 0 && NuberOfDayes != null && float1 != null)
                        {
                            int IdTheNameOfcoures = NameOfCouress.SerchByListStaticRetId(TypeofCouress.TypeofCouressList[IndexCombox].id, NumberOfCoures);
                            if (IdTheNameOfcoures == -1)
                            {
                                DevComponents.DotNetBar.MessageBoxEx.Show("رقم الدورة غير مضاف:" + NumberOfCoures);
                                break;
                            }


                            Couress CouresNew = new Couress(0, IdTheNameOfcoures, id, (int)NuberOfDayes,(float) float1);
                          await  Sqldatabasethrding.SqlSaveVitl(CouresNew.adder());
                
                            dataGridViewX1.Rows[i].DefaultCellStyle.BackColor = Color.Green;

                        
                        }
                        else
                        {   
                            dataGridViewX1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                 
                        }

                    }
                    else
                    {
                          
               
                        dataGridViewX1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                 
                    }

                    labelX2.Text = ((stopwatch.ElapsedMilliseconds * (dataGridViewX1.Rows.Count - i))/1000).ToString() ;
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
            Workin = false;
            dataGridViewX1.Enabled = true;

        }

        private void CoureesExcl_Leave(object sender, EventArgs e)
        {
          
        }

        private void CoureesExcl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Workin)
                if (DevComponents.DotNetBar.MessageBoxEx.Show(this, "هل إيقاف عملية أستراد الدورات ؟؟", "إستراد الدورات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, true) == System.Windows.Forms.DialogResult.Yes)
                {
                    Workin = false;
                }
                else
                    e.Cancel = true;
        }
    }
}