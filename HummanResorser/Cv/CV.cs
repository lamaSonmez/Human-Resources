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
    public partial class CV : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CV()
        {
            InitializeComponent();
        }

        private   void CV_Load(object sender, EventArgs e)
        {
            

            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBox1, CV_Study.CV_StudyList);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBox3, CvTeamNeed.CvTeamNeedList);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, CvTeamNeed.CvTeamNeedList);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx2, Scileis.ScileislList);

        }

        private async void  buttonX4_Click(object sender, EventArgs e)
        {
            await Serch();

        }

        private async void buttonX3_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            CVadderStudy CVadderStudy = new CVadderStudy();
            CVadderStudy.ShowDialog();

            CV_Study.CV_StudyList = await CV_Study.GetAll();
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBox1, CV_Study.CV_StudyList);

            this.Opacity = 1;
        }

        private async void  buttonX2_Click(object sender, EventArgs e)
        {
            CVadderTeam CVadderTeam = new CVadderTeam();
            this.Opacity = 0.3;
            CVadderTeam.ShowDialog();
            this.Opacity = 1;

            CvTeamNeed.CvTeamNeedList = await CvTeamNeed.GetAll();
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBox3, CvTeamNeed.CvTeamNeedList);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, CvTeamNeed.CvTeamNeedList);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            AdderNewCv();
        }

        private void AdderNewCv()
        {
            CvAdder CvAdder = new CvAdder();
            this.Opacity = 0.3;
            CvAdder.labelX4.Text = "";
            CvAdder.buttonX1.Text = "إضافة";
            CvAdder.Text = "إضافة";
            CvAdder.ShowDialog();
            this.Opacity = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public async static System.Threading.Tasks.Task< int> GetTheNumberArchev (int IdStudy )
        {
            //SELECT [NmuberOfArchev] FROM [HR_SARC].[dbo].[CV_Info] where [id_study] = @id_study ORDER BY id DESC
            System.Data.SqlClient.SqlCommand Sql = new System.Data.SqlClient.SqlCommand("SELECT top 1 [NmuberOfArchev] FROM [HR_SARC].[dbo].[CV_Info] where [id_study] = @id_study ORDER BY NmuberOfArchev DESC");
            Sql.Parameters.AddWithValue("id_study", IdStudy);
        List<List<object>> Op=   await  Sqldatabasethrding.GetSql(Sql);
        if (Op.Count != 0)
            return Convert.ToInt32(Op[0][0]) + 1;
        else
            return 1;
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                CvAdder CvAdder = new CvAdder(new CV_Info(Convert.ToInt32( dataGridViewX1.Rows[e.RowIndex].Cells[0].Value)));
                
                this.Opacity = 0.3;
                CvAdder.labelX4.Text = "";
                CvAdder.buttonX1.Text = "تعديل";
                CvAdder.Text = "تعديل";
                CvAdder.ShowDialog();
                this.Opacity = 1;
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;

            CVAdderExFile CVAdderExFile1 = new CVAdderExFile();
            CVAdderExFile1.ShowDialog();
            this.Opacity = 1;

        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            AddScil AddScil = new AddScil();

            AddScil.ShowDialog();
        }

        private void CV_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private async void CV_KeyDown(object sender, KeyEventArgs e)
        {
              if (   e.Control &&  e.KeyCode == Keys.E )
                {
                    this.ActiveControl = textBoxX1;

                }

              else if (   e.KeyCode == Keys.Enter)
              {
                  await Serch();

              }
              else if (e.Control && e.KeyCode == Keys.N)
              {
                  AdderNewCv();

              }



        }

        private async System.Threading.Tasks.Task Serch()
        {
            int NumberPhones = 0;
            try
            {
                NumberPhones = Convert.ToInt32(textBoxX2.Text);
            }
            catch { }
            List<CV_Info> CvList = await CV_Info.Serch(textBox1.Text, textBox2.Text, comboBox1.SelectedIndex != -1 ? CV_Study.CV_StudyList[comboBox1.SelectedIndex].id : -1, comboBox2.SelectedIndex, comboBox3.SelectedIndex != -1 ? CvTeamNeed.CvTeamNeedList[comboBox3.SelectedIndex].id : -1, checkBoxX1.Checked, NumberPhones, textBoxX1.Text, comboBoxEx1.SelectedIndex != -1 ? CvTeamNeed.CvTeamNeedList[comboBoxEx1.SelectedIndex].id : -1, textBoxX3.Text);
            List<CV_Info> CvListAfter = new  List<CV_Info>();
            if (comboBoxEx2.SelectedIndex != -1) {
                for (int i = 0; i < CvList.Count; i++)
                {
                    if (await HaveScil.GetHAVECVSELC(CvList[i].id, Scileis.ScileislList[comboBoxEx2.SelectedIndex].id))
                   CvListAfter.Add(CvList[i]);
                  }
            }
            else
            {
                CvListAfter = CvList;

            }
            System.Threading.Tasks.Task.Run( ()=>
                {
                    ClassDataGridViewDo.DataGridEnterGridForCV_InfoCV(dataGridViewX1, CvListAfter);
                   
                }
            );
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            AdderCVOuter AdderCVOuter1 = new AdderCVOuter();
            AdderCVOuter1.ShowDialog();
        }

        private void dataGridViewX1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            labelX4.Text = dataGridViewX1.Rows.Count.ToString();
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            AdderCvINer AdderCvINer = new AdderCvINer();
            AdderCvINer.ShowDialog();

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}