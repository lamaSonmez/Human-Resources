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
    public partial class SelectTypeSerchCorres : DevComponents.DotNetBar.Metro.MetroForm
    {
     public   List<int> idTypeofcorsSerch = new List<int>();
     public List<bool> idTypeofcorsSerchBoll = new List<bool>();
       public DateTime datetmestart = new DateTime();
       public DateTime datetmeend = new DateTime();
        public SelectTypeSerchCorres()
        {
            InitializeComponent();
            foreach (TypeofCouress tpye in TypeofCouress.TypeofCouressList)
                dataGridViewX1.Rows.Add(tpye.id, tpye.RetunNameString());


        }

        private void SelectTypeSerchCorres_Load(object sender, EventArgs e)
        {
            dateTimeInput2.Value = DateTime.Now; 
        }

        private void dataGridViewX2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
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
                dataGridViewX2.Rows.Add(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value, dataGridViewX1.Rows[e.RowIndex].Cells[1].Value , radioButton1.Checked );

                dataGridViewX1.Rows.RemoveAt(e.RowIndex);

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            idTypeofcorsSerch.Clear();
            idTypeofcorsSerchBoll.Clear();

            for (int i = 0; i < dataGridViewX2.Rows.Count; i++)
            {
                idTypeofcorsSerch.Add(Convert.ToInt32(dataGridViewX2.Rows[i].Cells[0].Value));
                idTypeofcorsSerchBoll.Add(Convert.ToBoolean(dataGridViewX2.Rows[i].Cells[2].Value));
            }

            datetmestart = dateTimeInput1.Value;
            datetmeend = dateTimeInput2.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
           

        }

       
    }
}