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
    public partial class CoresEditAdder : DevComponents.DotNetBar.Metro.MetroForm
    {
        public int idVite = 0;
        public bool ToAddInCores = false;
        public static int CountOfNew;
        private List<int> intList = new List<int>();
        public Couress CouressEdit = null;



        public CoresEditAdder()
        {
            InitializeComponent();
        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void CoresEditAdder_Load(object sender, EventArgs e)
        {
            if (ToAddInCores == false)
            {
                comboBoxEx1.Visible = false;
                labelX1.Visible = false;

                comboBoxEx2.Visible = true;
                labelX2.Visible = true;
                EditTame.AdderComvbox(comboBoxEx2, NameOfCouress.NameOfCouresslist);
               
            }
            else
            {
                comboBoxEx1.Visible = true;
                labelX1.Visible = true;

                comboBoxEx2.Visible = false;
                labelX2.Visible = false;
              comboBoxEx1.AutoCompleteCustomSource=  RibbonForm1.Combox;
              comboBoxEx1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                intList = RibbonForm1.intList;
   
            }


            if (CouressEdit != null && ToAddInCores == false)
            {
                idVite = CouressEdit.Id_Information;
                comboBoxEx2.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(CouressEdit.id_NameOfCouress, NameOfCouress.NameOfCouresslist);
                NumberOfdayregest.Text = CouressEdit.NumberOfdayregest.ToString();
                Result.Text = CouressEdit.Result.ToString();
                buttonX1.Text = "تعديل";


            }
                
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (CouressEdit == null && ToAddInCores == false)
            {

                CouressEdit = new Couress(CountOfNew,EditTame.SerchByComBBox(comboBoxEx2, NameOfCouress.NameOfCouresslist) ,this.idVite,ClassConvert.Convint(NumberOfdayregest.Text),Convert.ToSingle(Result.Text));
                CountOfNew--;
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }

            else if (CouressEdit == null && ToAddInCores && comboBoxEx1.AutoCompleteCustomSource.IndexOf(comboBoxEx1.Text) != -1 )
            {

                CouressEdit = new Couress(CountOfNew,  this.idVite,intList[comboBoxEx1.AutoCompleteCustomSource.IndexOf(comboBoxEx1.Text)], ClassConvert.Convint(NumberOfdayregest.Text), Convert.ToSingle(Result.Text));
                CountOfNew--;
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else if (ToAddInCores == false)
            {
                CouressEdit.Eidt(EditTame.SerchByComBBox(comboBoxEx2, NameOfCouress.NameOfCouresslist), this.idVite, ClassConvert.Convint(NumberOfdayregest.Text), Convert.ToSingle(Result.Text));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            else if (ToAddInCores && comboBoxEx1.AutoCompleteCustomSource.IndexOf(comboBoxEx1.Text) != -1)
            {
                CouressEdit.Eidt(intList[comboBoxEx1.SelectedIndex], this.idVite, ClassConvert.Convint(NumberOfdayregest.Text), Convert.ToSingle(Result.Text));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }

            this.Close();

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            SerchNameBynameRetu SerchNameBynameRetu1 = new SerchNameBynameRetu();
            SerchNameBynameRetu1.ShowDialog();

        }

        private void comboBoxEx1_KeyDown(object sender, KeyEventArgs e)
        {
           if ( e.Control && e.KeyCode == Keys.F)
           {
               SerchNameBynameRetu SerchNameBynameRetu1 = new SerchNameBynameRetu();
               SerchNameBynameRetu1.sech = comboBoxEx1.Text;
               if (SerchNameBynameRetu1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                   comboBoxEx1.Text =comboBoxEx1.AutoCompleteCustomSource[ intList.IndexOf(SerchNameBynameRetu1.Id)];
           }
        }
    }
}