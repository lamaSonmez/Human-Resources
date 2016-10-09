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
    public partial class AdderCouresFor : DevComponents.DotNetBar.Metro.MetroForm
    {
       public NameOfCouress NameOfCouress1 = null;


        public AdderCouresFor()
        {
            InitializeComponent();
        }

        private void AdderCouresFor_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, TypeofCouress.TypeofCouressList);


            if (NameOfCouress1 == null)
            {

               
                buttonX1.Text = "إضافة";

            }
            else
            {

                dateTimeInput1.Value = NameOfCouress1.dataStart;
                dateTimeInput2.Value = NameOfCouress1.DataENd;
                checkBoxX1.Checked = NameOfCouress1.Suport;
                integerInput1.Value = NameOfCouress1.IntCoures;
                textBoxX1.Text = NameOfCouress1.Decrption;
                comboBoxEx1.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(NameOfCouress1.Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList);
                comboBoxEx2.SelectedIndex = NameOfCouress1.WhereIS;
                buttonX1.Text = "تعديل";

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (NameOfCouress1 == null)
            NameOfCouress1 = new NameOfCouress(0, dateTimeInput1.Value, dateTimeInput2.Value, checkBoxX1.Checked, TypeofCouress.TypeofCouressList[comboBoxEx1.SelectedIndex].id, textBoxX1.Text, integerInput1.Value, comboBoxEx2.SelectedIndex);
            else
                NameOfCouress1.Edit( dateTimeInput1.Value, dateTimeInput2.Value, checkBoxX1.Checked, TypeofCouress.TypeofCouressList[comboBoxEx1.SelectedIndex].id, textBoxX1.Text, integerInput1.Value, comboBoxEx2.SelectedIndex);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
    }
}