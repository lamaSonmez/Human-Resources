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
    public partial class AdderAssing : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AdderAssing()
        {
            InitializeComponent();
        }

        private void AdderAssing_Load(object sender, EventArgs e)
        {
            // ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, Valuationname.Valuationnamelist);
            ClassDataGridViewDo.DataGridEnterGridAllValutionename(dataGridViewX1, Valuationname.Valuationnamelist);
           
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            AssingNew AssingNew1 = new AssingNew(null);
           if (  AssingNew1.ShowDialog()== DialogResult.OK)
            {
                Valuationname.Valuationnamelist = Valuationname.GetAll();
                ClassDataGridViewDo.DataGridEnterGridAllValutionename(dataGridViewX1, Valuationname.Valuationnamelist);
            }
        }
    }
}
