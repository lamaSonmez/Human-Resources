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
    public partial class AdderHaveSciles : DevComponents.DotNetBar.Metro.MetroForm
    {

       public HaveScil HaveScil = null;
        int CV_INFo = 0;
        public Int32 NumberAdderId;

        public AdderHaveSciles(HaveScil HaveScil = null, int CV_INFo = 0 )
        {
            InitializeComponent();
            this.HaveScil = HaveScil;
            this.CV_INFo = CV_INFo;
       
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdderHaveSciles_Load(object sender, EventArgs e)
        {

           ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1,Scileis.ScileislList);

            if ( HaveScil==null)
            {
                this.Text = "إضافة";
                buttonX1.Text = "إضافة";


            }
            else
            {
                this.Text = "تعديل";
                buttonX1.Text = "تعديل";

                comboBoxEx1.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(HaveScil.Scileis_ID, Scileis.ScileislList);
                ratingStar1.Rating = HaveScil.Star;
                
                 
            }
        }

        private  void buttonX1_Click(object sender, EventArgs e)
        {


            if ( comboBoxEx1.SelectedIndex == -1)
            {
                MegBox.Show("يجب إختيار من قائمة");
                return;
            }


              if ( HaveScil==null)
            {
                HaveScil = new HaveScil(NumberAdderId, Scileis.ScileislList[comboBoxEx1.SelectedIndex].id, CV_INFo, ratingStar1.Rating);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            else
            {
                HaveScil = new HaveScil(HaveScil.id, Scileis.ScileislList[comboBoxEx1.SelectedIndex].id, CV_INFo, ratingStar1.Rating);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;

            SeliAdderForm SeliAdderForm1 = new SeliAdderForm();
            SeliAdderForm1.ShowDialog();
            Scileis.ScileislList = await  Scileis.GetAll();
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, Scileis.ScileislList);
       
            this.Opacity = 1;
        }
    }
}