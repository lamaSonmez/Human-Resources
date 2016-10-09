using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading.Tasks;

namespace HummanResorser
{
    public partial class DeplcatNameShow : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<IdAndName> IdAndName1 = new List<IdAndName>();

        public DeplcatNameShow()
        {
            InitializeComponent();
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            IdAndName1.Clear();
            dataGridViewX1.Rows.Clear();

            IdAndName1 = await Vitl.GetAll("");

            var employeesByState = from ex in IdAndName1
                                   group ex by ex.Name;
            foreach (var employeeGroup in employeesByState)
            {
                foreach (var employee in employeeGroup)
                {
                    if (employeeGroup.Count() > 1 )
                    dataGridViewX1.Rows.Add(employee.id , employee.Name );
                }

            }


           
        }

        private void Showinfo_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                RibbonForm2 Bibo = new RibbonForm2();
                Bibo.idvite = Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value);
                if (Bibo.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                    dataGridViewX1.Rows.RemoveAt(e.RowIndex);
                Bibo.Dispose();
            }

        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Vitl.DeleByid(Convert.ToInt32(e.Row.Cells[0].Value));
        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {

            IdAndName1.Clear();
            dataGridViewX1.Rows.Clear();

            IdAndName1 = await Vitl.GetAll("");

            for ( int i = 0 ; i < IdAndName1.Count ; i++)
            {
                for ( int j = i+1 ; j < IdAndName1.Count ; j ++)
                   if ( IdAndName1[i].Name.Contains(IdAndName1[j].Name))
                   {
                       dataGridViewX1.Rows.Add(IdAndName1[j].id, IdAndName1[j].Name);
                       dataGridViewX1.Rows.Add(IdAndName1[i].id, IdAndName1[i].Name);

                   }



            }

        }
    }
}