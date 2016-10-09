using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading.Tasks;

namespace HummanResorser
{
    public partial class SerchNameBynameRetu : DevComponents.DotNetBar.Metro.MetroForm
    {

        List<IdAndName> viltl = new List<IdAndName>();
       public string sech = "";
       public int Id = 0;
       public bool RetDeicIfOneSerch = false;
       public bool DoBefor = false;
        public SerchNameBynameRetu()
        {
            InitializeComponent();
          
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            NameSrc();

        }

        public void DoWorkOff()
        {
            RetDeicIfOneSerch = true;
            
            SerchNameBynameRetu_Load(null, null);
            DoBefor = true;

        }
        public async void NameSrc()
        {
            viltl.Clear();
            dataGridViewX1.Rows.Clear();

           viltl  = await Vitl.GetAll(comboBox1.Text);


            foreach (IdAndName Name in viltl)
            {
                dataGridViewX1.Rows.Add(Name.id, Name.Name);


            }
        }

        
        private void SerchNameBynameRetu_Load(object sender, EventArgs e)
        {
            if (DoBefor== false)
            if (!string.IsNullOrEmpty(sech))
            {
                comboBox1.Text = sech;
                NameSrc();
                if (RetDeicIfOneSerch)
                if ( dataGridViewX1.Rows.Count == 1 )
                {
                    Id = Convert.ToInt32(dataGridViewX1.Rows[0].Cells[0].Value);
                    sech = dataGridViewX1.Rows[0].Cells[1].Value.ToString();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex != -1)
            {
                Id = Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value);
                sech = dataGridViewX1.Rows[dataGridViewX1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void SerchNameBynameRetu_KeyDown(object sender, KeyEventArgs e)
        {
            if (( e.Control && e.KeyCode == Keys.F )  ||  ( e.KeyCode == Keys.Enter) )
                NameSrc();

            else if ( e.Control && e.KeyCode == Keys.N )
            {
                RibbonForm2 RibbonForm2 = new RibbonForm2();
                
                RibbonForm2.ShowDialog();

            }
 
        }

        private void dataGridViewX1_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Enter)
                if (dataGridViewX1.SelectedCells.Count != 0)
            {
                Id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.SelectedCells[0].RowIndex].Cells[0].Value);
                sech = dataGridViewX1.Rows[dataGridViewX1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SerchNameBynameRetu_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void التفاصيلوالتعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( dataGridViewX1.SelectedCells.Count != 0)
            {
               RibbonForm2 RibbonForm2 = new HummanResorser.RibbonForm2 () ;
               RibbonForm2.idvite =Convert.ToInt32( dataGridViewX1.Rows[dataGridViewX1.SelectedCells[0].RowIndex].Cells[0].Value);

               RibbonForm2.ShowDialog();



            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}