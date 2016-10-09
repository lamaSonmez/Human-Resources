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
    public partial class WereDeliveryEditAdder : DevComponents.DotNetBar.Metro.MetroForm
    {
        public int idVite = 0;
        public static int CountOfNew;
        private List<int> intList = new List<int>();
        public WereDelivery WereDeliveryEdit = null;

        public WereDeliveryEditAdder()
        {
            InitializeComponent();
        }

        private void WereDeliveryEditAdder_Load(object sender, EventArgs e)
        {
            EditTame.AdderComvbox(comboBoxEx1, WereType.WereTypeList);

            if (WereDeliveryEdit != null)
            {
               comboBoxEx1.SelectedIndex= ClassDataGridViewDo.RetunIndexByIdSech(WereDeliveryEdit.Id_WereType, WereType.WereTypeList);
               dateTimeInput1.Value = WereDeliveryEdit.dateDeliveryitem.Value;
               dateTimeInput2.Value = WereDeliveryEdit.DateBackitem.Value;
               textBoxX1.Text = WereDeliveryEdit.Notes;
               this.Text = "تعديل أستلام مادة";
               buttonX1.Text = "تعديل";


            }
            else
            {
                this.Text = "إضافة أستلام مادة";
                buttonX1.Text = "تعديل";

            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (WereDeliveryEdit != null)
            {

            }else
            {



            }


        }
    }
}