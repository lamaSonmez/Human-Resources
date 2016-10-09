using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace HummanResorser
{
    public partial class RibbonForm2 : DevComponents.DotNetBar.RibbonForm
    {
        public int idvite = 0;
        public Vitl vitl1 = null;
        public bool needSeaving = false;

        public List<Team> TeamList = new List<Team>();
        public List<Couress> CouressList = new List<Couress>();
        public List<WereDelivery> WereDeliveryList = new List<WereDelivery>();
        public List<Valuation> ValuationList = new List<Valuation>();

        private List<int> IntEditTeam = new List<int>();
        private List<int> IntAdderTeam = new List<int>();
        private List<int> IntDeletTeam = new List<int>();

        private List<int> IntEditCoress = new List<int>();
        private List<int> IntAdderCoress = new List<int>();
        private List<int> IntDeletCoress = new List<int>();

        private List<int> IntAdderWere = new List<int>();
        private List<int> IntEditWere = new List<int>();
        private List<int> IntDeletWere = new List<int>();


        public int CountTempIdTame = 0;

        public RibbonForm2()
        {
            InitializeComponent();

        }

        private async void RibbonForm2_Load(object sender, EventArgs e)
        {

          
            #region تحميل الفريم الأولي
         
            #region تحميل معلومات الأساسية للجدول الفريق
            ClassDataGridViewDo.DataGridAddVuleComBoxEx((DataGridViewComboBoxExColumn)dataGridViewX1.Columns["TeamTeam"], NameTeamType.NameTeamTypeStatic, NameTeam.NameTeamStatic);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx((DataGridViewComboBoxExColumn)dataGridViewX1.Columns["TeamJop"], Jop.JopStatic);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx((DataGridViewComboBoxExColumn)dataGridViewX2.Columns["id_NameOfCouress"],NameOfCouress.NameOfCouresslist);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx((DataGridViewComboBoxExColumn)dataGridViewX1.Columns["TeamStatus"], Team.Setwation);
            
            #endregion

          
            /// في كان ت
            if (idvite != 0)
            {
                #region تحميل المعلومات في حال كان هناك مستخدم للتعديل
                #region معلومات العامة
                vitl1 = new Vitl(idvite);
                first_name.Text = vitl1.first_name;
                Last_name.Text = vitl1.Last_name;
                Father_name.Text = vitl1.Father_name;
                Mather_name.Text = vitl1.Mather_name;
                natiol_id.Text =ClassConvert.ConvToIdNational( vitl1.natiol_id);
                Gender.SelectedIndex = ClassConvert.ConvGenderBoolNull(vitl1.Gender);
                where_birth.Text = vitl1.where_birth;
                data_barthday.Value = vitl1.data_barthday;
                Hanei_whare.Text = vitl1.Hanei_whare;
                Hanei_whare1.Text = vitl1.Hanei_whare1;
                adderas.Text = vitl1.adderas;
                e_mail.Text = vitl1.e_mail;
                Stutes_Jtma3.SelectedIndex = vitl1.Stutes_Jtma3;
                Phone_Ground.Text = vitl1.Phone_Ground.ToString();
                Phone_Mobile1.Text = vitl1.Phone_Mobile1.ToString();
                Phone_Mobile2.Text = vitl1.Phone_Mobile2.ToString();
                Facebook.Text = vitl1.Facebook;
                Twiter.Text = vitl1.Twiter;
                whatsApp.Text = vitl1.whatsApp.ToString();
                viper.Text = vitl1.viper.ToString();
                study.Text = vitl1.study;
                yearstudy.SelectedIndex = vitl1.yearstudy;
                Id_course.Text = vitl1.Id_course.ToString();
                Id_course_Ware.Text = vitl1.Id_course_Ware;
                data_regs.Value = vitl1.data_regs;
                Image_id_nationl1.Image = vitl1.Image_id_nationl1;
                Image_id_nationl2.Image = vitl1.Image_id_nationl2;
                image.Image = vitl1.image;
                image1.Image = vitl1.image;
                Image_font.Image = vitl1.Image_font;
                bitd_id.SelectedIndex = vitl1.Boold_id;
                Nkname.Text = vitl1.Nkname;
                nameEnglish.Text = vitl1.nameEnglish;
                Z1.SelectedIndex = vitl1.Z1;
                z2.Text = vitl1.z2.ToString();
                z3.SelectedIndex = vitl1.z3;
                this.dataGridView7.DataSource = vitl1.XmlHobbies;
                  #endregion
                #region الفريق

                /////إضافة الفريق إلى جدول الفرق
                EditTame.CountOfNew = 0;
                TeamList = await Team.GetByIdVil(idvite);
                ClassDataGridViewDo.DataGridEnterGridToWorkTeam(dataGridViewX1, TeamList);
                #endregion
                #region الدورات
                CoresEditAdder.CountOfNew = 0;
                CouressList = Couress.GetByIdVil(idvite);
                ClassDataGridViewDo.DataGridEnterGridToWorkCorser(dataGridViewX2, CouressList);
                #endregion
                #region المواد
       
                WereDeliveryList = WereDelivery.GetByIdVil(idvite);
                ClassDataGridViewDo.DataGridEnterGridToWorkWereDelivery(dataGridViewX3, WereDeliveryList);

                #endregion

                #region المواد

                ValuationList = Valuation.GetByIdVil(idvite);
                ClassDataGridViewDo.DataGridEnterGridToWorkValuation(dataGridViewX4, ValuationList);

                #endregion
                #endregion
            }
            else
            {

                this.Text = "تسجيل متطوع جديد";

            }
 
            #endregion
            needSeaving = false;
       
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            await SaveNewOrUpdate();
             needSeaving = false;
        
        }

        private async System.Threading.Tasks.Task SaveNewOrUpdate()
        {
            try
            {

                if (idvite == 0)
                {

                    #region تسجيل متطوع جديد

                    #region المتغيرات للكلاس المعلومات الأساسية
                    int id = 0;
                    string first_name = this.first_name.Text;
                    string Last_name = this.Last_name.Text;
                    string Father_name = this.Father_name.Text;
                    string Mather_name = this.Mather_name.Text;
                    Int64 natiol_id = ClassConvert.Convint64(this.natiol_id.Text);
                    bool Gender = ClassConvert.ConvBool(this.Gender.SelectedIndex);
                    string where_birth = this.where_birth.Text;
                    DateTime data_barthday = ClassConvert.ConvDateTime(this.data_barthday.Value);
                    string Hanei_whare = this.Hanei_whare.Text;
                    string Hanei_whare1 = this.Hanei_whare1.Text;
                    string adderas = this.adderas.Text;
                    string e_mail = this.e_mail.Text;
                    int Stutes_Jtma3 = this.Stutes_Jtma3.SelectedIndex;
                    int Phone_Ground = ClassConvert.Convint(this.Phone_Ground.Text);
                    int Phone_Mobile1 = ClassConvert.Convint(this.Phone_Mobile1.Text);
                    int Phone_Mobile2 = ClassConvert.Convint(this.Phone_Mobile2.Text);
                    string Facebook = this.Facebook.Text;
                    int whatsApp = ClassConvert.Convint(this.whatsApp.Text);
                    int viper = ClassConvert.Convint(this.viper.Text);
                    string Twiter = (this.Twiter.Text);
                    string study = this.study.Text;
                    int yearstudy = this.yearstudy.SelectedIndex;
                    int Id_course = ClassConvert.Convint(this.Id_course.Text);
                    string Id_course_Ware = this.Id_course_Ware.Text;
                    DateTime data_regs = ClassConvert.ConvDateTime(this.data_regs.Value);
                    System.Drawing.Image Image_id_nationl1 = ClassConvert.ConvImage(this.Image_id_nationl1.Image);
                    System.Drawing.Image Image_id_nationl2 = ClassConvert.ConvImage(this.Image_id_nationl2.Image);
                    System.Drawing.Image image = ClassConvert.ConvImage(this.image.Image);
                    System.Drawing.Image Image_font = ClassConvert.ConvImage(this.Image_font.Image);
                    int bitd_id = this.bitd_id.SelectedIndex;
                    string Nkname = this.Nkname.Text;
                    string nameEnglish = this.nameEnglish.Text;
                    int Z1 = this.Z1.SelectedIndex;
                    int z2 = ClassConvert.Convint(this.z2.Text);
                    int z3 = this.z3.SelectedIndex;
                    System.Xml.XmlDataDocument XmlHobbies = null;




                    vitl1 = new Vitl(id, first_name, Last_name, Father_name, Mather_name, natiol_id, Gender, where_birth, data_barthday, Hanei_whare, Hanei_whare1, adderas, e_mail, Stutes_Jtma3, Phone_Ground, Phone_Mobile1, Phone_Mobile2, Facebook, Twiter, whatsApp, viper, study, yearstudy, Id_course, Id_course_Ware, data_regs, Image_id_nationl1, Image_id_nationl2, image, Image_font, bitd_id, Nkname, nameEnglish, Z1, z2, z3, XmlHobbies);

                    Sqldatabasethrding.SqlSaveAdderAndBack(vitl1);


                    idvite = vitl1.id;//تاكد من عمل الصحيح للبرنامج

                    #endregion

                    #region إضافة وتعديل الفرق
                    EditTame.CountOfNew = 0;
                    foreach (Team IdInfoAdder in TeamList)
                    {
                        IdInfoAdder.EdidInfoId(idvite);
                    }
               await     Sqldatabasethrding.SqlAddOrUpdateOrDelet(ClassConvert.ConvertListInterfaseToDataBase(TeamList), IntAdderTeam, IntEditTeam, IntDeletTeam);

                    #endregion

                    #region إضافة وتعديل الدورات
                    CoresEditAdder.CountOfNew = 0;
                    foreach (Couress IdInfoAdder in CouressList)
                    {
                        IdInfoAdder.EdidInfoId(idvite);
                    }
                 await   Sqldatabasethrding.SqlAddOrUpdateOrDelet(ClassConvert.ConvertListInterfaseToDataBase(CouressList), IntAdderCoress, IntEditCoress, IntDeletCoress);

                    #endregion

                    #endregion

                }
                else
                {

                    #region تعديلات العلومات العامة

                    #region المتغيرات

                    string first_name = this.first_name.Text;
                    string Last_name = this.Last_name.Text;
                    string Father_name = this.Father_name.Text;
                    string Mather_name = this.Mather_name.Text;
                    Int64 natiol_id = ClassConvert.Convint64(this.natiol_id.Text);
                    bool Gender = ClassConvert.ConvBool(this.Gender.SelectedIndex);
                    string where_birth = this.where_birth.Text;
                    DateTime data_barthday = ClassConvert.ConvDateTime(this.data_barthday.Value);
                    string Hanei_whare = this.Hanei_whare.Text;
                    string Hanei_whare1 = this.Hanei_whare1.Text;
                    string adderas = this.adderas.Text;
                    string e_mail = this.e_mail.Text;
                    int Stutes_Jtma3 = this.Stutes_Jtma3.SelectedIndex;
                    int Phone_Ground = ClassConvert.Convint(this.Phone_Ground.Text);
                    int Phone_Mobile1 = ClassConvert.Convint(this.Phone_Mobile1.Text);
                    int Phone_Mobile2 = ClassConvert.Convint(this.Phone_Mobile2.Text);
                    string Facebook = this.Facebook.Text;
                    int whatsApp = ClassConvert.Convint(this.whatsApp.Text);
                    int viper = ClassConvert.Convint(this.viper.Text);
                    string Twiter = (this.Twiter.Text);
                    string study = this.study.Text;
                    int yearstudy = this.yearstudy.SelectedIndex;
                    int Id_course = ClassConvert.Convint(this.Id_course.Text);
                    string Id_course_Ware = this.Id_course_Ware.Text;
                    DateTime data_regs = ClassConvert.ConvDateTime(this.data_regs.Value);
                    System.Drawing.Image Image_id_nationl1 = ClassConvert.ConvImage(this.Image_id_nationl1.Image);
                    System.Drawing.Image Image_id_nationl2 = ClassConvert.ConvImage(this.Image_id_nationl2.Image);
                    System.Drawing.Image image = ClassConvert.ConvImage(this.image.Image);
                    System.Drawing.Image Image_font = ClassConvert.ConvImage(this.Image_font.Image);
                    int bitd_id = this.bitd_id.SelectedIndex;
                    string Nkname = this.Nkname.Text;
                    string nameEnglish = this.nameEnglish.Text;
                    int Z1 = this.Z1.SelectedIndex;
                    int z2 = ClassConvert.Convint(this.z2.Text);
                    int z3 = this.z3.SelectedIndex;
                    System.Xml.XmlDataDocument XmlHobbies = null;

                    #endregion

                    vitl1.UpdateOUtid(first_name, Last_name, Father_name, Mather_name, natiol_id, Gender, where_birth, data_barthday, Hanei_whare, Hanei_whare1, adderas, e_mail, Stutes_Jtma3, Phone_Ground, Phone_Mobile1, Phone_Mobile2, Facebook, Twiter, whatsApp, viper, study, yearstudy, Id_course, Id_course_Ware, data_regs, Image_id_nationl1, Image_id_nationl2, image, Image_font, bitd_id, Nkname, nameEnglish, Z1, z2, z3, XmlHobbies);

                    await Sqldatabasethrding.SqlupdataVitl(vitl1.updata());
                    #endregion


                    #region إضافة وتعديل الفرق
                    await Sqldatabasethrding.SqlAddOrUpdateOrDelet(ClassConvert.ConvertListInterfaseToDataBase(TeamList), IntAdderTeam, IntEditTeam, IntDeletTeam);

                    #endregion


                    #region إضافة وتعديل الدورات
                    await Sqldatabasethrding.SqlAddOrUpdateOrDelet(ClassConvert.ConvertListInterfaseToDataBase(CouressList), IntAdderCoress, IntEditCoress, IntDeletCoress);

                    #endregion


                    #region إضافة وتعديل وحذف الأستلامات
                    await Sqldatabasethrding.SqlAddOrUpdateOrDelet(ClassConvert.ConvertListInterfaseToDataBase(WereDeliveryList), IntAdderWere, IntEditWere, IntDeletWere);

                    #endregion
               
                }

                /////Loed Team Grid
                EditTame.CountOfNew = 0;
                TeamList = await Team.GetByIdVil(idvite);
                ClassDataGridViewDo.DataGridEnterGridToWorkTeam(dataGridViewX1, TeamList);
                ////Loed Coures Grid
                CoresEditAdder.CountOfNew = 0;
                CouressList = Couress.GetByIdVil(idvite);
                ClassDataGridViewDo.DataGridEnterGridToWorkCorser(dataGridViewX2, CouressList);
                #region التقيم


                ValuationList = Valuation.GetByIdVil(idvite);
                ClassDataGridViewDo.DataGridEnterGridToWorkValuation(dataGridViewX4, ValuationList);

                #endregion



                MegBox.Show("تم التعديل", this);


            }
            catch (Exception xv)
            { MessageBox.Show(xv.ToString()); }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
         
            OpenFileDialog SavefileDialog = new OpenFileDialog();
            SavefileDialog.Filter = "image | *.Png;*.jpg;*.jpge ";
            if (SavefileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.Image_font.Image = Image.FromFile(SavefileDialog.FileName);

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            OpenFileDialog SavefileDialog = new OpenFileDialog();
            SavefileDialog.Filter = "image | *.Png;*.jpg;*.jpge ";
            if (SavefileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Image_id_nationl1.Image = Image.FromFile(SavefileDialog.FileName);
                needSeaving = true;
            }
            SavefileDialog.Dispose();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            OpenFileDialog SavefileDialog = new OpenFileDialog();
            SavefileDialog.Filter = "image | *.Png;*.jpg;*.jpge ";
            if (SavefileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Image_id_nationl2.Image = Image.FromFile(SavefileDialog.FileName);
                needSeaving = true;
            }
            SavefileDialog.Dispose();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            OpenFileDialog SavefileDialog = new OpenFileDialog();
            SavefileDialog.Filter = "image | *.Png;*.jpg;*.jpge ";
            if (SavefileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.image.Image = Image.FromFile(SavefileDialog.FileName);
                this.image1.Image = this.image.Image;
                needSeaving = true;

            }
            SavefileDialog.Dispose();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            EditTame EditTame = new EditTame();
            EditTame.idVite = idvite; 
            if (EditTame.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    TeamList.Add(EditTame.TeamEdit);
                    IntAdderTeam.Add(TeamList.Count - 1);
                    needSeaving = true;
                }
            ClassDataGridViewDo.DataGridEnterGridToWorkTeam(dataGridViewX1, TeamList);

        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Convert.ToInt32(e.Row.Cells["IdTeam"].Value) <= 0)
            {
                e.Cancel = true;
            }
            
            else
            {
                IntDeletTeam.Add(ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(e.Row.Cells["IdTeam"].Value), TeamList));
            }



        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            CoresEditAdder CoresEditAdder = new CoresEditAdder();
            CoresEditAdder.idVite = idvite;
            if (CoresEditAdder.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                CouressList.Add(CoresEditAdder.CouressEdit);
                IntAdderCoress.Add(CouressList.Count - 1);
                needSeaving = true;
            }
            ClassDataGridViewDo.DataGridEnterGridToWorkCorser(dataGridViewX2, CouressList);

        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CoresEditAdder Detalis1 = new CoresEditAdder();
                Detalis1.idVite = idvite;
                this.Opacity = 0.5;
                Detalis1.CouressEdit = CouressList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX2.Rows[e.RowIndex].Cells[0].Value), CouressList)];
                if (Detalis1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {


                    CouressList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX2.Rows[e.RowIndex].Cells[0].Value), CouressList)] = Detalis1.CouressEdit;

                    if (ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value) > 0)
                        IntEditCoress.Add(ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX2.Rows[e.RowIndex].Cells[0].Value), CouressList));
                    needSeaving = true;
                }

                ClassDataGridViewDo.DataGridEnterGridToWorkCorser(dataGridViewX2, CouressList);
                this.Opacity = 1;

            }
        }

        private void dataGridViewX2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Convert.ToInt32(e.Row.Cells["IdCores"].Value) <= 0)
            {
                e.Cancel = true;
            }

            else
            {
                IntDeletCoress.Add(ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(e.Row.Cells["IdCores"].Value),CouressList));
            }



        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            image.Image = null;
            image1.Image = null;
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            image.Image = null;
            image1.Image = null;
        }

        private void Image_id_nationl1_Click(object sender, EventArgs e)
        {
        
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            Image_id_nationl1.Image = null;
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            Image_id_nationl2.Image = null;
        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            Image_font.Image = null;
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditTame Detalis1 = new EditTame();
                Detalis1.idVite = idvite;
                this.Opacity = 0.5;
                Detalis1.TeamEdit = TeamList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), TeamList)];
                if (Detalis1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {


                    TeamList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), TeamList)] = Detalis1.TeamEdit;

                    if (ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value) > 0)
                        IntEditTeam.Add(ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), TeamList));
                    needSeaving = true;
                }

                ClassDataGridViewDo.DataGridEnterGridToWorkTeam(dataGridViewX1, TeamList);
                this.Opacity = 1;
            }
        }

        private void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
        

       
        }

        private async void buttonX13_Click(object sender, EventArgs e)
        {

            if (MessageBoxEx.Show(this, "هل أنت متأكد من حذف المتطوع من قاعدة البيانات نهائياً ؟؟", "حذف", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                if (vitl1 != null)
                {
                    await Sqldatabasethrding.SqlSaveVitl(vitl1.Delete());
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;

                }
        }

        private void buttonX13_Click_1(object sender, EventArgs e)
        {
            ShowAllIteam  ShowAllIteam1 = new ShowAllIteam(null);
            ShowAllIteam1.idVite = idvite;
            if (ShowAllIteam1.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                WereDeliveryList.Add(ShowAllIteam1.Waredelivare);
                IntAdderWere.Add(WereDeliveryList.Count - 1);
                needSeaving = true;
            }
            ClassDataGridViewDo.DataGridEnterGridToWorkWereDelivery(dataGridViewX3, WereDeliveryList);
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            IDPrinter idpreinter = new IDPrinter(vitl1);
            idpreinter.ShowDialog();

        }

        private void Any_TextChanged(object sender, EventArgs e)
        {
            needSeaving = true;

        }

        private async void RibbonForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( needSeaving )
            {

               if ( DevComponents.DotNetBar.MessageBoxEx.Show(this, "هل تريد حفظ التغيرات قبل الخروج؟", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes )
               {
                   await SaveNewOrUpdate();

               }


            }
        }

  

        private  void Gender_SelectedIndexChanged_1(object sender, EventArgs e)
        {

          
                needSeaving = true;



        }

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowAllIteam ShowAllIteam1 = new ShowAllIteam(WereDeliveryList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX3.Rows[e.RowIndex].Cells[0].Value), WereDeliveryList)]);
                ShowAllIteam1.idVite = idvite;
                this.Opacity = 0.5;
                if (ShowAllIteam1.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {


                    WereDeliveryList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX3.Rows[e.RowIndex].Cells[0].Value), WereDeliveryList)] = ShowAllIteam1.Waredelivare;

                    if (ClassConvert.Convint(dataGridViewX3.Rows[e.RowIndex].Cells[0].Value) > 0)
                        IntEditWere.Add(ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX3.Rows[e.RowIndex].Cells[0].Value), WereDeliveryList));
                    needSeaving = true;
                }

                ClassDataGridViewDo.DataGridEnterGridToWorkWereDelivery(dataGridViewX3, WereDeliveryList);
                this.Opacity = 1;
            }
        }

       

        private void buttonX15_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog ShowWhereSaveYouPhoto = new FolderBrowserDialog())
            {

                if ( ShowWhereSaveYouPhoto.ShowDialog()== DialogResult.OK)
                {

                    if (image != null)
                        image.Image.Save(ShowWhereSaveYouPhoto.SelectedPath + "\\"+vitl1.first_name + " " + vitl1.Last_name + "1"+".jpg");
                    if (Image_id_nationl1 != null)
                        Image_id_nationl1.Image.Save(ShowWhereSaveYouPhoto.SelectedPath + "\\" + vitl1.first_name + " " + vitl1.Last_name + "2" + ".jpg");
                    if (Image_id_nationl2 != null)
                        Image_id_nationl2.Image.Save(ShowWhereSaveYouPhoto.SelectedPath + "\\" + vitl1.first_name + " " + vitl1.Last_name + "3" + ".jpg");
                }



            }
        }
    }
}