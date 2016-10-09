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
    public partial class ShowAllIteam : DevComponents.DotNetBar.Metro.MetroForm
    {
        public int idVite = 0;
        public WereDelivery Waredelivare = null;

        public ShowAllIteam(WereDelivery Waredelivare)
        {
            InitializeComponent();
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, WereType.WereTypeList);
            this.Waredelivare = Waredelivare;
            if ( Waredelivare == null)
            {
                this.Text = "إضافة أستلام جديد للمتطوع";
                buttonX1.Text = "إضافة أستلام";
            }else
            {
                this.Text = "تعديل أستلام  للمتطوع";
                buttonX1.Text = "تعديل أستلام";
                comboBoxEx1.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(this.Waredelivare.Id_WereType, WereType.WereTypeList);
                if (Waredelivare.dateDeliveryitem != null)
                    checkBoxX1.Checked = true;

                if (Waredelivare.DateBackitem != null)
                    checkBoxX2.Checked = true;
            }
      
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeInput1.Enabled = checkBoxX1.Checked;
            if (checkBoxX1.Checked)
            {
                if (Waredelivare == null)
                    dateTimeInput1.Value = DateTime.Today;
                else if (Waredelivare.dateDeliveryitem == null)
                    dateTimeInput1.Value = DateTime.Today;
                else
                    dateTimeInput1.Value = Waredelivare.dateDeliveryitem.Value;
            }
            else
                dateTimeInput1.Value = new DateTime(0);

        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            dateTimeInput2.Enabled = checkBoxX2.Checked;
            if (checkBoxX2.Checked)
            {
                if (Waredelivare == null)
                    dateTimeInput2.Value = DateTime.Today;
                else if (Waredelivare.DateBackitem == null)
                    dateTimeInput2.Value = DateTime.Today;
                else
                    dateTimeInput2.Value = Waredelivare.DateBackitem.Value;
            }
            else
                dateTimeInput2.Value = new DateTime(0);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
          if (  comboBoxEx1.SelectedIndex ==-1){
              MegBox.Show("إختار أسم المادة");
                  return ;
                 }
            
            if (Waredelivare == null)
            {


                Waredelivare = new WereDelivery(0, WereType.WereTypeList[comboBoxEx1.SelectedIndex].id, ClassConvert.ConvDateTimeNull(dateTimeInput1.Value), this.idVite, ClassConvert.ConvDateTimeNull(dateTimeInput2.Value), textBoxX2.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else
            {
                Waredelivare = new WereDelivery(Waredelivare.id, WereType.WereTypeList[comboBoxEx1.SelectedIndex].id, ClassConvert.ConvDateTimeNull(dateTimeInput1.Value), this.idVite, ClassConvert.ConvDateTimeNull(dateTimeInput2.Value), textBoxX2.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }

        }

        private void ShowAllIteam_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, WereType.WereTypeList);
        }
    }
}