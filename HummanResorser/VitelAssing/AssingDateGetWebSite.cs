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
    
    public partial class AssingDateGetWebSite : DevComponents.DotNetBar.Metro.MetroForm
    {

public  static DownloadDataFromWebCliend DownloadDataFromWebCliend = new DownloadDataFromWebCliend();

        public AssingDateGetWebSite()
        {
            InitializeComponent();
            try
            {
                DownloadDataFromWebCliend.LoginSet("m5524512", "m5524512");

            }
            catch(Exception e )
            {
                ErrorClass.SaveErrorFile(e , true);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try {
                List<AsncyGetInformation> AsncyGetInformation = DownloadDataFromWebCliend.GetInfrmationofdateGet(DownloadDataFromWebCliend.EnumGetXML.GetString);
                ClassDataGridViewDo.DataGridEnterAsncyGetInformation(dataGridViewX1, AsncyGetInformation);
            }
            catch (Exception ec )
            {
                MegBox.Show(ec.Message, this);
            }
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex != -1 )
            {
                InformationOfdateGet InformationOfdateGet = new InformationOfdateGet(Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value), dataGridViewX1.Rows[e.RowIndex].Cells[1].Value.ToString() );
                InformationOfdateGet.ShowDialog();
                try
                {
                    List<AsncyGetInformation> AsncyGetInformation = DownloadDataFromWebCliend.GetInfrmationofdateGet(DownloadDataFromWebCliend.EnumGetXML.GetString);
                    ClassDataGridViewDo.DataGridEnterAsncyGetInformation(dataGridViewX1, AsncyGetInformation);
                }
                catch (Exception ec)
                {
                    MegBox.Show(ec.Message, this);
                }
            }
        }
    }
}