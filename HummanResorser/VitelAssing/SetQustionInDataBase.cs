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
    public partial class SetQustionInDataBase : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SetQustionInDataBase()
        {
            InitializeComponent();
        }

        private void SetQustionInDataBase_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridEnterGridQustion(dataGridViewX1, Qustiones.Qustioneslist);
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            newQustion newqustion1 = new newQustion(null);
            if (newqustion1.ShowDialog () == DialogResult.OK)
            {

                Qustiones.Qustioneslist = Qustiones.GetAll();

                ClassDataGridViewDo.DataGridEnterGridQustion(dataGridViewX1, Qustiones.Qustioneslist);
            }
        }
    }
}
