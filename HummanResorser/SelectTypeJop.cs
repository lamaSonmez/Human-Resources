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
    public partial class SelectTypeJop : DevComponents.DotNetBar.Metro.MetroForm
    {
     public   List<int> idjopSerch = new List<int>(); 

        public SelectTypeJop()
        {
            InitializeComponent();
            foreach (Jop Jop1 in Jop.JopStatic)
                dataGridViewX1.Rows.Add(Jop1.id, Jop1.RetunNameString());
        }

        private void dataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewX1.Rows.Add(dataGridViewX2.Rows[e.RowIndex].Cells[0].Value, dataGridViewX2.Rows[e.RowIndex].Cells[1].Value);

                dataGridViewX2.Rows.RemoveAt(e.RowIndex);

            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewX2.Rows.Add(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value, dataGridViewX1.Rows[e.RowIndex].Cells[1].Value);

                dataGridViewX1.Rows.RemoveAt(e.RowIndex);

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
                idjopSerch.Add(Convert.ToInt32(dataGridViewX2.Rows[i].Cells[0].Value));

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}