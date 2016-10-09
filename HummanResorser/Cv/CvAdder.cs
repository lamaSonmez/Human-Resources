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
    public partial class CvAdder : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CV_Info CV_i = null;
        List<int> IntAddeHavescilr = new List<int>();
        List<int> InteditHavescil = new List<int>();
        List<int> IntDelHavescil = new List<int>();

        public Int32 NumberAdderId = 0;

        public List<HaveScil> listHavescil = new List<HaveScil>();

        public CvAdder(CV_Info CV_i = null)
        {
            InitializeComponent();
            this.CV_i = CV_i;
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            DateTime? DateTimenull = ClassConvert.ConvDateTimeNull( dateTimeInput1.Value);
            if (CV_i == null)
            {
              if ( comboBoxEx1.SelectedIndex ==-1)
                {
                MegBox.Show("لا يمكن ترك حقل دراسه فارغ");
                return;
                }
              else if ( textBoxX1.Text.Trim() =="")
              {
                  MegBox.Show("لا يمكن ترك حقل الأسم فارغ");
                  return;
              }
              else if (integerInput1.Value == 0)
              {
                  MegBox.Show("لا يمكن ترك حقل رقم الهاتف فارغ");
                  return;
              }
              else if (!ClassConvert.IsNumberPhoneMobileOrGrund (integerInput1.Value  ))
              {
                  MegBox.Show("لا يمكن ترك حقل رقم الهاتف فارغ");
                  return;
              }
                  
                  
              
               

                 int Idc = CV_Study.CV_StudyList[comboBoxEx1.SelectedIndex].id;

                 int Idc1 = -1;
                 int Idc2 = -1;
                if (comboBoxEx3.SelectedIndex != -1)
                 Idc1 = CvTeamNeed.CvTeamNeedList[comboBoxEx3.SelectedIndex].id;

                if (comboBoxEx4.SelectedIndex != -1)
                    Idc2 = CvTeamNeed.CvTeamNeedList[comboBoxEx4.SelectedIndex].id;

                CV_i = new CV_Info(0, textBoxX1.Text, textBoxX2.Text, await CV.GetTheNumberArchev(Idc), Idc, comboBoxEx2.SelectedIndex, integerInput1.Value, dateTimeInput1.Value, Idc1, checkBoxX1.Checked, comboBoxEx4.SelectedIndex ,ClassConvert.ConvDateTimeNull( dateTimeInput2.Value) , textBoxX3.Text );
             int idc = await Sqldatabasethrding.SqlSaveAdderAndBack(CV_i.adder()) ;
             if (idc > 0)
                {
                
                    MegBox.Show( "تم التسجيل" , this);
                    labelX4.Text = CV_i.GetCodeArch();
                    CV_i = new CV_Info(idc, textBoxX1.Text, textBoxX2.Text, await CV.GetTheNumberArchev(Idc), Idc, comboBoxEx2.SelectedIndex, integerInput1.Value, dateTimeInput1.Value, Idc1, checkBoxX1.Checked, Idc2, ClassConvert.ConvDateTimeNull(dateTimeInput2.Value), textBoxX3.Text);
                    foreach (HaveScil item in listHavescil)
                    {
                        item.EditCV_Info_ID(CV_i.id);
                        
                    }
                    Sqldatabasethrding.SqlAddOrUpdateOrDelet(ClassConvert.ConvertListInterfaseToDataBase(this.listHavescil), IntAddeHavescilr, InteditHavescil, IntDelHavescil);
                }
                else
                {
                    MegBox.Show("هناك خطأ في الاتصال",this);

                }
            }
            else
            {
                CV_i = new CV_Info(CV_i.id, textBoxX1.Text, textBoxX2.Text, (CV_i.Id_Study == CV_Study.CV_StudyList[comboBoxEx1.SelectedIndex].id ? CV_i.NmuberOfArchev: await CV.GetTheNumberArchev(CV_Study.CV_StudyList[comboBoxEx1.SelectedIndex].id) ) ,
                    CV_Study.CV_StudyList[comboBoxEx1.SelectedIndex].id,
                    comboBoxEx2.SelectedIndex,
                    integerInput1.Value,
                  DateTimenull,
                 comboBoxEx3.SelectedIndex != -1 ?    CvTeamNeed.CvTeamNeedList[comboBoxEx3.SelectedIndex].id : -1,
                    checkBoxX1.Checked,
                            comboBoxEx4.SelectedIndex != -1 ? CvTeamNeed.CvTeamNeedList[comboBoxEx4.SelectedIndex].id : -1, ClassConvert.ConvDateTimeNull(dateTimeInput2.Value), textBoxX3.Text
                    );
                if (await Sqldatabasethrding.SqlSaveVitl(CV_i.updata()))
                {


                    labelX4.Text = CV_i.GetCodeArch();
                    MegBox.Show("تم التعديل", this);
                    Sqldatabasethrding.SqlAddOrUpdateOrDelet(ClassConvert.ConvertListInterfaseToDataBase(this.listHavescil), IntAddeHavescilr, InteditHavescil, IntDelHavescil);
                }
                else
                {
                    MegBox.Show("هناك خطأ في الاتصال", this);

                }

            }
        }

        private async void CvAdder_Load(object sender, EventArgs e)
        {
           
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, CV_Study.CV_StudyList);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx3, CvTeamNeed.CvTeamNeedList);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx4, CvTeamNeed.CvTeamNeedList);
            if (CV_i != null)
            {
               
                labelX4.Text = CV_i.GetCodeArch();
                textBoxX1.Text = CV_i.FullName;
                textBoxX2.Text = CV_i.Notes;
                comboBoxEx1.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(CV_i.Id_Study, CV_Study.CV_StudyList);
                comboBoxEx2.SelectedIndex = CV_i.Year_sutr;
                comboBoxEx3.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(CV_i.ID_TemaNeed, CvTeamNeed.CvTeamNeedList);
                checkBoxX1.Checked = CV_i.Bit;
                integerInput1.Value = CV_i.Numberphone;

                /////
                comboBoxEx4.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(CV_i.ToOutTeam, CvTeamNeed.CvTeamNeedList);

                if (CV_i.Date != null)
                    dateTimeInput2.Value = Convert.ToDateTime(CV_i.ToOutDate);
                textBoxX3.Text = CV_i.Notesout;
                /////////
                if (CV_i.Date != null)
                    dateTimeInput1.Value = Convert.ToDateTime(CV_i.Date);

                listHavescil = await HaveScil.GetByidInfoCV(CV_i.id);


                ClassDataGridViewDo.DataGridEnterGridHaveSsciles(dataGridViewX1, listHavescil);
                  

            }
            else
                dateTimeInput1.Value = DateTime.Now;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            if (CV_i != null)
            {
                AdderHaveSciles AdderHaveSciles1 = new AdderHaveSciles(null, CV_i.id);
                AdderHaveSciles1.NumberAdderId = NumberAdderId;
                if (AdderHaveSciles1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    listHavescil.Add(AdderHaveSciles1.HaveScil);

                    IntAddeHavescilr.Add(listHavescil.Count - 1);

                    NumberAdderId--;

                    ClassDataGridViewDo.DataGridEnterGridHaveSsciles(dataGridViewX1, listHavescil);

                }
            }
            else
            {
                AdderHaveSciles AdderHaveSciles1 = new AdderHaveSciles();
                AdderHaveSciles1.NumberAdderId = NumberAdderId;

              if (  AdderHaveSciles1.ShowDialog()==System.Windows.Forms.DialogResult.OK) 
              {
                  listHavescil.Add(AdderHaveSciles1.HaveScil);

                  IntAddeHavescilr.Add(listHavescil.Count - 1);

                  NumberAdderId--;

                  ClassDataGridViewDo.DataGridEnterGridHaveSsciles(dataGridViewX1, listHavescil);
              }


            }


        }

        private async void buttonX3_Click(object sender, EventArgs e)
        {
            if (CV_i != null)
                if (MessageBoxEx.Show("هل متأكد من حذف","تأكيد الحذف", MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                 if ( await      Sqldatabasethrding.SqlSaveVitl( CV_i.Delete()))
                          MegBox.Show("تم الحذف", this);
        }
    }
}