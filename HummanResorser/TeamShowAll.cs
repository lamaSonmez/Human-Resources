using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Threading.Tasks;

namespace HummanResorser
{
    public partial class TeamShowAll : DevComponents.DotNetBar.RibbonForm
    {
        public NameTeam NameTeam = null;
        public int Type = 0;
        public List<Team> TeamList = new List<Team>();
        public List<IdAndName> VitlByIdList = new List<IdAndName>();



        private List<int> IntEditTeam = new List<int>();
        private List<int> IntAdderTeam = new List<int>();
        private List<int> IntDeletTeam = new List<int>();


        public TeamShowAll()
        {
            InitializeComponent();
        }

        private void Corser_Load(object sender, EventArgs e)
        {
            ClassDataGridViewDo.DataGridAddVuleComBoxEx((DataGridViewComboBoxExColumn)dataGridViewX1.Columns["Id_Jop_Ta"], Jop.JopStatic);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx((DataGridViewComboBoxExColumn)dataGridViewX1.Columns["Setewation"], Team.Setwation);
            EditTame.AdderComvbox(comboBoxEx1,NameTeamType.NameTeamTypeStatic);
            if (NameTeam != null)
            {

           
                ///////
                Type = NameTeam.NameTeamType_Id;
                textBoxX1.Text = NameTeam.nameOftame;
                comboBoxEx1.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(NameTeam.NameTeamType_Id, NameTeamType.NameTeamTypeStatic);
                comboBoxEx1.Enabled = false;
                ////////////////

                TeamList = Team.GetByGetbyIdNameName(NameTeam.id ,checkBoxX1.Checked );
                foreach (Team TeamVX in TeamList)
                    VitlByIdList.Add(new IdAndName(TeamVX.ID_informtion));

                ClassDataGridViewDo.DataGridEnterGridToWorkTeam(dataGridViewX1, TeamList, VitlByIdList);

            }
        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {
            AdderNameForTeam AdderNameForTeam1 = new AdderNameForTeam();
            AdderNameForTeam1.NameTeam = NameTeam;
            if (AdderNameForTeam1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                await Sqldatabasethrding.SqlSaveVitl(AdderNameForTeam1.Team.adder());
                UpdateTheNewAdderOrEdit();
            }


            
        }

        private void UpdateTheNewAdderOrEdit()
        {
            TeamList = Team.GetByGetbyIdNameName(NameTeam.id, checkBoxX1.Checked);
            VitlByIdList.Clear();
            foreach (Team TeamVX in TeamList)
                VitlByIdList.Add(new IdAndName(TeamVX.ID_informtion));
            ClassDataGridViewDo.DataGridEnterGridToWorkTeam(dataGridViewX1, TeamList, VitlByIdList);
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private async void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AdderNameForTeam EditTame = new AdderNameForTeam();


                this.Opacity = 0.5;
                EditTame.NameTeam = NameTeam;
                EditTame.Team = TeamList[ClassDataGridViewDo.RetunIndexByIdSech(ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), TeamList)];
                if (EditTame.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                 await   Sqldatabasethrding.SqlSaveVitl(EditTame.Team.updata());


                 UpdateTheNewAdderOrEdit();
                }


                this.Opacity = 1;

        
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

     
           
        }

        private async void dataGridViewX1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show(this, String.Format(" هل متأكد من حذف {0} من هذا الفريق؟؟؟", e.Row.Cells[1].Value.ToString()), "رسالة تأكيد بحذف", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                if (await Sqldatabasethrding.SqlSaveVitl(this.TeamList[ClassDataGridViewDo.RetunIndexByIdSech(Convert.ToInt32(e.Row.Cells[0].Value), this.TeamList)].Delete()))
                    MegBox.Show("تم الحذف", this);
            }
            else { e.Cancel = true ; }
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTheNewAdderOrEdit();

        }

        private void dataGridViewX1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            labelX4.Text = dataGridViewX1.Rows.Count.ToString();
        }

        private async void buttonX13_Click(object sender, EventArgs e)
        {

            this.Enabled = false;
            List<int> sfe = new List<int>();

            for (int i = 0; i < TeamList.Count; i++)
            {
                sfe.Add(TeamList[i].ID_informtion);
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