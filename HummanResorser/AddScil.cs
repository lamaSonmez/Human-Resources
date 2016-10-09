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
    public partial class AddScil : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AddScil()
        {
            InitializeComponent();
        }

        private  void AddScil_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridEnterGridForFillScil(dataGridViewX1, Scileis.ScileislList);
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            SeliAdderForm SeliAdderForm = new SeliAdderForm();
            SeliAdderForm.ShowDialog();
            Scileis.ScileislList =await  Scileis.GetAll();
            ClassDataGridViewDo.DataGridEnterGridForFillScil(dataGridViewX1, Scileis.ScileislList);
        }

        private async void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex!= -1 )
            {
                if (Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value) > 0)
                {
                    SeliAdderForm SeliAdderForm = new SeliAdderForm(Scileis.ScileislList[ClassDataGridViewDo.RetunIndexByIdSech(Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), Scileis.ScileislList)]);
                    SeliAdderForm.ShowDialog();
                    Scileis.ScileislList = await Scileis.GetAll();
                    ClassDataGridViewDo.DataGridEnterGridForFillScil(dataGridViewX1, Scileis.ScileislList);

                }
            }
            else
            {

            }
        }
    }
}