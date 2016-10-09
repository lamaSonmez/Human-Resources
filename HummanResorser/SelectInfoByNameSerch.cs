using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;

namespace HummanResorser
{
    public partial class SelectInfoByNameSerch : DevComponents.DotNetBar.Metro.MetroForm
    {
        public SelectInfoByNameSerch()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {  //35
            OpenFileDialog S = new OpenFileDialog();
            S.Filter = " Excel | *.xlsx";
            if (S.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                @S.FileName +
                                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                OleDbConnection con = new OleDbConnection(constr);

                con.Open();
                DataTable Dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                String name = Dt.Rows[0]["TABLE_NAME"].ToString();
                OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "]", con);
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);

                DataTable data = new DataTable();

                sda.Fill(data);

                dataGridViewX1.DataSource = data;

            }

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (!dataGridViewX1.Columns.Contains("id"))
                dataGridViewX1.Columns.Add("Id", "id");

            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (ClassConvert.Convint(dataGridViewX1.Rows[i].Cells["id"].Value) <= 0)
                {
                    string name = Convert.ToString(dataGridViewX1.Rows[i].Cells["الاسم"].Value);

                    SerchNameBynameRetu SerchNameBynameRetu = new SerchNameBynameRetu();

                    SerchNameBynameRetu.sech = name;
                    SerchNameBynameRetu.DoWorkOff();

                    if (SerchNameBynameRetu.Id > 0)
                    {
                        dataGridViewX1.Rows[i].Cells["id"].Value = SerchNameBynameRetu.Id;

                    }
                    else
                    {
                        SerchNameBynameRetu.Text = name;
                        if (SerchNameBynameRetu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            dataGridViewX1.Rows[i].Cells["id"].Value = SerchNameBynameRetu.Id;
                    }
                }
            }
        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {
            if (!dataGridViewX1.Columns.Contains("تاريخ1"))
                dataGridViewX1.Columns.Add("تاريخ1", "تاريخ");

            if (!dataGridViewX1.Columns.Contains("تاريخ2"))
                dataGridViewX1.Columns.Add("تاريخ2", "تاريخ");

            if (!dataGridViewX1.Columns.Contains("الاسم1"))
                dataGridViewX1.Columns.Add("الاسم1", "تاريخ");

            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (ClassConvert.Convint(dataGridViewX1.Rows[i].Cells["id"].Value) > 0)
                {


                    IdAndName vit = await Vitl.GetbyidIdAndName(ClassConvert.Convint(dataGridViewX1.Rows[i].Cells["id"].Value));

                    dataGridViewX1.Rows[i].Cells["الاسم1"].Value = vit.Name;
                    dataGridViewX1.Rows[i].Cells["تاريخ1"].Value = vit.Regesterdeg.ToShortDateString();

                    dataGridViewX1.Rows[i].Cells["تاريخ2"].Value = vit.Regesterdeg.ToLongDateString();

                }
            }

        }
    }
}