using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Threading.Tasks;

namespace HummanResorser
{
    public partial class RibbonForm1 : DevComponents.DotNetBar.RibbonForm
    {

        public static List<Vitl> vitelList = new List<Vitl>();
        public static List<int> intList = new List<int>();
        public static System.Windows.Forms.AutoCompleteStringCollection  Combox  = new AutoCompleteStringCollection(); 
        public RibbonForm1()
        {
            InitializeComponent();
           

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {

        }

        private async void RibbonForm1_Load(object sender, EventArgs e)
        {
            

            #region setup1
            Vitl.SetUpNameDataBase();



            #endregion
     //      Sqldatabasethrding.SqlConnection1.ConnectionString = Sqldatabasethrding.sqlconction;
      //      Sqldatabasethrding.SqlConnection1.Open();
            

            #region SetUpCLassis
            CvTeamNeed.CvTeamNeedList = await CvTeamNeed.GetAll();
            CV_Study.CV_StudyList = await CV_Study.GetAll();

            NameTeamType.NameTeamTypeStatic = NameTeamType.GetAll();
            NameTeam.NameTeamStatic = await NameTeam.GetAll();
            Jop.JopStatic = Jop.GetAll();

            TypeofCouress.TypeofCouressList = TypeofCouress.GetAll();
            NameOfCouress.NameOfCouresslist = NameOfCouress.GetAll();
            WereType.WereTypeList = WereType.GetAll();
            Valuationname.Valuationnamelist = Valuationname.GetAll();

            Scileis.ScileislList = await  Scileis.GetAll();


            Qustiones.Qustioneslist = Qustiones.GetAll();


            //من أجل عم بحث على أنهم غير فعالين
            Team.ListNotAllAtive.Add(4);
            Team.ListNotAllAtive.Add(5);
            //من أجل عم بحث على أنهم غير فعالين
           ////

             Team.Setwation.Add("رديف");
             Team.Setwation.Add("أساسي");
             Team.Setwation.Add("دوار");
             Team.Setwation.Add("موظف");
             Team.Setwation.Add("مسافر");
             Team.Setwation.Add("منقطع");
             Team.Setwation.Add("تطوعي غير مؤجور");
            ///
            Valuationname.ValuationnameTypeInt.Add("دائمين");
            Valuationname.ValuationnameTypeInt.Add("تجربين");
            Valuationname.ValuationnameTypeInt.Add("شامل لكل المتطوعين");
            Valuationname.ValuationnameTypeInt.Add( "مخصص");
            //
             Vitl.Bransh.Add("حلب");
             Vitl.Bransh.Add("حلب-سفيرة");
            //
            #endregion
         
            #region interFace
     
            ClassDataGridViewDo.DataGridAddVuleComBoxEx((DataGridViewComboBoxExColumn)dataGridViewX3.Columns["Id_TypeofCouress_ta"], TypeofCouress.TypeofCouressList);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx((DataGridViewComboBoxExColumn)dataGridViewX9.Columns["NameTeamType_Id"], NameTeamType.NameTeamTypeStatic);
            ClassDataGridViewDo.DataGridEnterGridToWorkNameOfCouress_ta(dataGridViewX3, NameOfCouress.NameOfCouresslist);
            //dataGridViewX9
            ClassDataGridViewDo.DataGridEnterGridToWorkNameTeam_Ta(dataGridViewX9, NameTeam.NameTeamStatic);
            await Sqldatabasethrding.GetNameForRibbonForm1Combox(intList);

            #endregion
            comboBoxEx1.AutoCompleteCustomSource = Combox;

 
        }

        private void superTabControl1_TabMoved(object sender, SuperTabStripTabMovedEventArgs e)
        {
         
        }

        private void Column1_DrawItem(object sender, DrawItemEventArgs e)
        {
            MessageBox.Show("awdw");
        }

        private void Column1_DrawItem(object sender, MeasureItemEventArgs e)
        {
           
        }

        private void Column1_DrawItem(object sender, EventArgs e)
        {
            MessageBox.Show("awdw");
            
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Serch(object sender, KeyPressEventArgs e)
        {
           if ( e.KeyChar == Convert.ToChar(13))
            {

                MessageBox.Show("Serch" + sender.ToString());
            }
            
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        
        }



        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RibbonForm2 Detalis1 = new RibbonForm2();
                this.Opacity = 0.5;
                Detalis1.idvite = ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value);
                Detalis1.ShowDialog();
                this.Opacity = 1;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            
            
            Int64 NUmber = 0;
            if ( textBoxForInationlNumber1.Text != "")
             NUmber = Convert.ToInt64(textBoxForInationlNumber1.Text);
         

                Sqldatabasethrding.WaitSqlsersh(comboBoxEx1.Text, NUmber, idVitel1.Text, dateTimeInput2.Value, dateTimeInput1.Value, progressBarX1, dataGridViewX1);
                

            
            
        }

        private void dataGridViewX3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Corser Corser = new Corser();
                this.Opacity = 0.5;

                Corser.NameOfCouress = NameOfCouress.NameOfCouresslist[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX3.Rows[e.RowIndex].Cells[0].Value), NameOfCouress.NameOfCouresslist)];
                Corser.ShowDialog();
                this.Opacity = 1;


            }
        }

        private void dataGridViewX4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EngerseMissin EngerseMissin1 = new EngerseMissin();
           
            this.Hide();
            EngerseMissin1.ShowDialog();
            this.Show();
        }

        private void dataGridViewX5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewX7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Premision Premision1 = new Premision();
            this.Hide();
            Premision1.ShowDialog();
            this.Show();
        }

        private void dataGridViewX8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            order order1 = new order();
            this.Hide();
            order1.ShowDialog();
            this.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Options Options1 = new Options();
            Options1.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            RibbonForm2 Detalis1 = new RibbonForm2();
            this.Opacity = 0.5;
            Detalis1.idvite = 0;
            Detalis1.ShowDialog();
            this.Opacity = 1;
        }

        private void dataGridViewX9_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TeamShowAll TeamShowAll = new TeamShowAll();
                this.Opacity = 0.5;

                TeamShowAll.NameTeam = NameTeam.NameTeamStatic[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX9.Rows[e.RowIndex].Cells[0].Value), NameTeam.NameTeamStatic)];
                TeamShowAll.ShowDialog();
                this.Opacity = 1;


            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();

            form.ShowDialog();
        }

        private  async void buttonItem3_Click(object sender, EventArgs e)
        {
            AdderCouresFor AdderCouresFor1 = new AdderCouresFor();
           if (  AdderCouresFor1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
               await Sqldatabasethrding.SqlSaveVitl(AdderCouresFor1.NameOfCouress1.adder());
              NameOfCouress.NameOfCouresslist = NameOfCouress.GetAll();
              ClassDataGridViewDo.DataGridEnterGridToWorkNameOfCouress_ta(dataGridViewX3, NameOfCouress.NameOfCouresslist);

           }
        }

        private void dataGridViewX1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            labelX7.Text = dataGridViewX1.Rows.Count.ToString();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            CoureesExcl CoureesExcl1 = new CoureesExcl();
            this.Opacity = 0.5;

            CoureesExcl1.ShowDialog();
            this.Opacity = 1;
        }

        private void comboBoxEx1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void comboBoxEx1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                buttonX1_Click(null, null);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            DeplcatNameShow DeplcatNameShow1 = new DeplcatNameShow();
            DeplcatNameShow1.ShowDialog();

            this.Opacity = 1;
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            SerchAdva SerchAdva1 = new SerchAdva();
            SerchAdva1.ShowDialog(); 

        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            SelectInfoByNameSerch SelectInfoByNameSerch1 = new SelectInfoByNameSerch();
            SelectInfoByNameSerch1.ShowDialog();
            this.Opacity = 1;
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            TAMEditingForDate TAMEditingForDate1 = new TAMEditingForDate();
            TAMEditingForDate1.ShowDialog();
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            Test Test1 = new Test ( ) ;


            Test1.ShowDialog();

        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            this.Hide();
            CV Cv = new CV();
            Cv.ShowDialog();

            this.Show();

        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            GetDateByID GetDateByID = new GetDateByID();
            GetDateByID.ShowDialog();
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            FixErorrNational FixErorrNational1 = new FixErorrNational();
            FixErorrNational1.ShowDialog();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            AdderForTeam AdderForTeam1 = new AdderForTeam();
            this.Opacity = 0.5;
            AdderForTeam1.ShowDialog();
            this.Opacity = 1;

        }

        private async void buttonX13_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            List<int> sfe= new List<int> ();

            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
			{
			 sfe.Add(Convert.ToInt32( dataGridViewX1.Rows[i].Cells[0].Value));
			}
            GetDateByID GetDateByID = null;
       await     Task.Run(() =>
            {
                 GetDateByID = new GetDateByID(sfe);
            }
           );
            GetDateByID.ShowDialog();
            this.Enabled = true;
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            importAllItems importAllItems1 = new importAllItems();
            importAllItems1.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox12 = new AboutBox1();
            this.Opacity = 0.5;

            aboutbox12.ShowDialog();
            this.Opacity =1;
        }
    }
}