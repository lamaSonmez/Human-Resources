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
    public partial class GetDateByID : DevComponents.DotNetBar.Metro.MetroForm
    {


        List<Vitl> Vite = new List<Vitl>();
        List<int> id = new List<int>();
        public  GetDateByID(List<int> id =null)
        {
            InitializeComponent();
            this.id = id;
            
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            SerchNameBynameRetu SerchNameBynameRetu1 = new SerchNameBynameRetu();

            if (SerchNameBynameRetu1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Vite.Add(new Vitl(SerchNameBynameRetu1.Id));
        
            ClassDataGridViewDo.DataGridEnterGridForGetdateByID(dataGridViewX1, Vite[Vite.Count - 1], await Team.GetByIdVil(Vite[Vite.Count - 1].id, true), Couress.GetByIdVil(Vite[Vite.Count - 1].id, true));


        }

        private async void GetDateByID_Load(object sender, EventArgs e)
        {
            if ( id !=null)
            for (int i = 0; i < id.Count; i++)
            {
                Vite.Add(new Vitl());
                await Vite[Vite.Count - 1].MakeAsn(id[i]);
                    ClassDataGridViewDo.DataGridEnterGridForGetdateByID(dataGridViewX1, Vite[Vite.Count - 1], await Team.GetByIdVil(Vite[Vite.Count - 1].id, true), Couress.GetByIdVil(Vite[Vite.Count - 1].id, true));
                }
            

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}