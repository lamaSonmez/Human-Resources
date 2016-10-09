using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HummanResorser
{
    public partial class AssingNew : DevComponents.DotNetBar.Metro.MetroForm
    {
        Valuationname Valuationname1 = null;
        List<ValuationForm> ValuationForm1 = new List<ValuationForm>();

        int CounitIndex = 0;
        public AssingNew(Valuationname Valuationname1)
        {
            this.Valuationname1 = Valuationname1;

            InitializeComponent();
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, Qustiones.Qustioneslist);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx2,Valuationname.ValuationnameTypeInt);
            if (Valuationname1 == null)
            {
                this.Text = "إضافة تقيم جديد";
               
            }
            else
            {
                // ValuationForm1 = getall;
            }
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if ( comboBoxEx1.SelectedIndex == -1)
            { MegBox.Show("يجب أختيار سؤال", this);
                return;
            }
            if ( integerInput1.Value < 0)
            { MegBox.Show("يجب أختيار قيمة أكبر", this);
                return;
            }
            ValuationForm1.Add(new ValuationForm(CounitIndex--, 0, Qustiones.Qustioneslist[comboBoxEx1.SelectedIndex].id, integerInput1.Value));
            dataGridViewX1.Rows.Add(CounitIndex, comboBoxEx1.Text, integerInput1.Value);
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "")
            {
                MegBox.Show("يجب أدخال أسم للتقيم", this);

                return;
            }
            if (comboBoxEx2.SelectedIndex == -1)
            {
                MegBox.Show("يجب أختيار نوع التقيم", this);
                return;
            }
            if (Valuationname1 == null)
            {
                Valuationname1 = new Valuationname(0, textBoxX1.Text, comboBoxEx2.SelectedIndex);
                await Sqldatabasethrding.SaveNewAssing(Valuationname1);

                for (int i = 0; i < ValuationForm1.Count; i++)
                {
                    ValuationForm1[i].id_Valuationname_Ta = Valuationname1.id;
                   await Sqldatabasethrding.SqlSaveVitl(ValuationForm1[i].adder());
                }
                ValuationForm1 = ValuationForm.GetAllbyIdValuationname(Valuationname1.id);
                this.DialogResult = DialogResult.OK;
            }
            else
            {

            }
        }

      
    }
}
