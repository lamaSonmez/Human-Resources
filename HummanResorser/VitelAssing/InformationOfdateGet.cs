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
    public partial class InformationOfdateGet : DevComponents.DotNetBar.Metro.MetroForm
    {
        int idAssingPHPid = 0;
        string nameusername = "";
        List<vitelAssingInformation> Alldatesee = new List<vitelAssingInformation>();
        public InformationOfdateGet(int idAssingPHPid , string nameusername )
        {
            InitializeComponent();
            this.idAssingPHPid = idAssingPHPid;
            this.nameusername = nameusername;
            Alldatesee= AssingDateGetWebSite.DownloadDataFromWebCliend.GetAllDataByidVitl(idAssingPHPid);
            ClassDataGridViewDo.DataGridEnterAsncyGrAllname(dataGridViewX1, Alldatesee);
            labelX2.Text = nameusername;
        }

        private void labelX1_Click(object sender, EventArgs e)
        {
         
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {

            if (AssingDateGetWebSite.DownloadDataFromWebCliend.LoginSet(true))
            {
                try {
                    AssingDateGetWebSite.DownloadDataFromWebCliend.ENDASSINGSHOW(idAssingPHPid);

                    foreach (vitelAssingInformation vitelAssingInformation1 in Alldatesee)
                    {
                        Valuation Valuation1 = (new Valuation(0, vitelAssingInformation1.GetidInformation(), this.nameusername, vitelAssingInformation1.GetIDform(), vitelAssingInformation1.XDocumentconvert(), DateTime.Now));
                        await Sqldatabasethrding.SqlSaveVitl(Valuation1.adder());
                    }

                    this.Close();
                }
                catch ( Exception ev)
                {
                    MegBox.Show(ev.Message);
                }
            }
            else
            {

                MegBox.Show("لا يوجد إنترنت");
            }
              
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex !=-1)
            {
                DetalsDataVitelAssing DetalsDataVitelAssing1 = new DetalsDataVitelAssing(Alldatesee[ClassDataGridViewDo.RetunIndexByIdSech(Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), Alldatesee)]);
                DetalsDataVitelAssing1.ShowDialog();
            }
        }
    }
}