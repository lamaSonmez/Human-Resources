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
    public partial class Corser : DevComponents.DotNetBar.RibbonForm
    {
        public NameOfCouress NameOfCouress = null;
        public int Type = 0;

        public List<Couress> CouressList = new List<Couress> ();
        public List<IdAndName> VitlByIdList = new List<IdAndName>();

        private List<int> IntEditCoress = new List<int>();
        private List<int> IntAdderCoress = new List<int>();
        private List<int> IntDeletCoress = new List<int>();

        public Corser()
        {
            InitializeComponent();
        }

        private void Corser_Load(object sender, EventArgs e)
        {
            EditTame.AdderComvbox(comboBoxEx1, TypeofCouress.TypeofCouressList);
         if ( NameOfCouress ==null)
         {

         }
             else
               {

                    Type = NameOfCouress.Id_TypeofCouress_ta;
                    textBoxX1.Text = NameOfCouress.Decrption;
                    comboBoxEx1.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(NameOfCouress.Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList);
                    comboBoxEx1.Enabled = false;
                    CouressList = Couress.GetByNameOfCores(NameOfCouress.id);

                    foreach (Couress Couressv in CouressList  )
                        VitlByIdList.Add( Vitl.VitlIdAndName(Couressv.Id_Information));

             ClassDataGridViewDo.DataGridEnterGridToWorkNameOfCouress_ta(dataGridViewX1, CouressList, VitlByIdList);

              }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            CoresEditAdder CoresEditAdder = new CoresEditAdder();
            CoresEditAdder.ToAddInCores = true;
            if (Type != 0)
            {
                CoresEditAdder.idVite = NameOfCouress.id;

                if (CoresEditAdder.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    CouressList.Add(CoresEditAdder.CouressEdit);
                    IntAdderCoress.Add(CouressList.Count - 1);

                    VitlByIdList.Clear();
                    foreach (Couress Couressv in CouressList)
                        VitlByIdList.Add(Vitl.VitlIdAndName(Couressv.Id_Information));

                    ClassDataGridViewDo.DataGridEnterGridToWorkNameOfCouress_ta(dataGridViewX1, CoresEditAdder.CouressEdit, VitlByIdList[CouressList.IndexOf( CoresEditAdder.CouressEdit)]);
                }
                

                
            }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Type = EditTame.SerchByComBBox(comboBoxEx1, TypeofCouress.TypeofCouressList);
            comboBoxEx1.Enabled = false;
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CoresEditAdder Detalis1 = new CoresEditAdder();
                Detalis1.idVite = NameOfCouress.id;
                this.Opacity = 0.5;
                Detalis1.CouressEdit = CouressList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), CouressList)];
                if (Detalis1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {


                    CouressList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), CouressList)] = Detalis1.CouressEdit;

                    if (ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value) > 0)
                        IntEditCoress.Add(ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), CouressList));

                }

                ClassDataGridViewDo.DataGridEnterGridToWorkNameOfCouress_ta(dataGridViewX1, CouressList,VitlByIdList);
                this.Opacity = 1;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
                Sqldatabasethrding.SqlAddOrUpdateOrDelet(ClassConvert.ConvertListInterfaseToDataBase(CouressList), IntAdderCoress, IntEditCoress, IntDeletCoress);
                CouressList = Couress.GetByNameOfCores(NameOfCouress.id);
            VitlByIdList.Clear();
            foreach (Couress Couressv in CouressList)
                VitlByIdList.Add(Vitl.VitlIdAndName(Couressv.Id_Information));
            
            ClassDataGridViewDo.DataGridEnterGridToWorkNameOfCouress_ta(dataGridViewX1, CouressList, VitlByIdList);
        }

        private void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Convert.ToInt32(e.Row.Cells["Idcours"].Value) <= 0)
            {
                e.Cancel = true;
            }

            else
            {
                IntDeletCoress.Add(ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(e.Row.Cells["Idcours"].Value), CouressList));
            }

        }

        private async void buttonX4_Click(object sender, EventArgs e)
        {
            AdderCouresFor AdderCouresFor1 = new AdderCouresFor();
            AdderCouresFor1.NameOfCouress1 = NameOfCouress;
            if ( AdderCouresFor1.ShowDialog () == System.Windows.Forms.DialogResult.OK )
            {
                NameOfCouress = AdderCouresFor1.NameOfCouress1;
              await  Sqldatabasethrding.SqlSaveVitl(AdderCouresFor1.NameOfCouress1.updata());
                textBoxX1.Text = NameOfCouress.Decrption;
                comboBoxEx1.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(NameOfCouress.Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList);

            }
            
        }

        private void Corser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
                buttonX2_Click(null, null);

        }

        private async void buttonX13_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            List<int> sfe = new List<int>();

            for (int i = 0; i < CouressList.Count; i++)
            {
                sfe.Add(CouressList[i].Id_Information);
            }
            GetDateByID GetDateByID = null;
            await Task.Run(() =>
            {
                GetDateByID = new GetDateByID(sfe);
            }
                );
            GetDateByID.ShowDialog();
            this.Enabled = true;
        }
    }
}