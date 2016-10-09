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
    
    public partial class AdderNameForTeam : DevComponents.DotNetBar.Metro.MetroForm
    {

       public NameTeam NameTeam = null;
       public Team Team = null;
        List<int> intList = new List<int>();
        public AdderNameForTeam()
        {
            InitializeComponent();
        }
        public AdderNameForTeam(NameTeam NameTeam)
        {

            NameTeam = this.NameTeam;
            InitializeComponent();

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (this.comboBoxEx2.SelectedIndex == -1)
            {

                MegBox.Show("عليك إختيار الوضع");
                return;
            }
            if (this.comboBoxEx3.SelectedIndex == -1)
            {

                MegBox.Show("عليك إختيار المنصب");
                return;
            }

            if (Team == null)
            {
                if (RibbonForm1.Combox.IndexOf(textBoxX1.Text) != -1 )
                {
                Team = new Team(0, ClassConvert.ConvDateTimeNull(dateTimeInput1.Value), ClassConvert.ConvDateTimeNull(dateTimeInput2.Value), intList[RibbonForm1.Combox.IndexOf(textBoxX1.Text)], NameTeam.id, EditTame.SerchByComBBox(comboBoxEx3, Jop.JopStatic), comboBoxEx2.SelectedIndex);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {

                    MegBox.Show("الأسم غير موجود");
                }

            }
            else
            {
                if (RibbonForm1.Combox.IndexOf(textBoxX1.Text) != -1)
                {
                    Team.Eidt(ClassConvert.ConvDateTimeNull(dateTimeInput1.Value), ClassConvert.ConvDateTimeNull(dateTimeInput2.Value), intList[RibbonForm1.Combox.IndexOf(textBoxX1.Text)], NameTeam.id, EditTame.SerchByComBBox(comboBoxEx3, Jop.JopStatic), comboBoxEx2.SelectedIndex);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }else
                {
                    MegBox.Show("الأسم غير موجود");
                }
            }

        }

        private void AdderNameForTeam_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx3, Jop.JopStatic);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx2, Team.Setwation);
            intList = RibbonForm1.intList;
            textBoxX1.AutoCompleteCustomSource = RibbonForm1.Combox;
            textBoxX1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxX1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            if (Team == null)
            {
                buttonX1.Text = "إضافة";

            }
            else
            {
                textBoxX1.Text = RibbonForm1.Combox[intList.IndexOf(Team.ID_informtion)];
                comboBoxEx2.SelectedIndex = Team.Setewation ;
                comboBoxEx3.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech( Team.Id_Jop_Ta,   Jop.JopStatic );
                if (ClassConvert.ConvDateTimeNull(Team.date_Start) != null)
                    dateTimeInput1.Value = ClassConvert.ConvDateTime(Team.date_Start);

                if (ClassConvert.ConvDateTimeNull(Team.Date_End) != null)
                    dateTimeInput2.Value = ClassConvert.ConvDateTime(Team.Date_End);

                buttonX1.Text = "تعديل";

            }

        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                SerchNameBynameRetu SerchNameBynameRetu1 = new SerchNameBynameRetu();
                SerchNameBynameRetu1.sech = textBoxX1.Text;
                if (SerchNameBynameRetu1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    textBoxX1.Text = textBoxX1.AutoCompleteCustomSource[intList.IndexOf(SerchNameBynameRetu1.Id)];

            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            SerchNameBynameRetu SerchNameBynameRetu1 = new SerchNameBynameRetu();
            SerchNameBynameRetu1.sech = textBoxX1.Text;
            SerchNameBynameRetu1.ShowDialog();
            textBoxX1.Text = SerchNameBynameRetu1.sech;

        }

    }
}