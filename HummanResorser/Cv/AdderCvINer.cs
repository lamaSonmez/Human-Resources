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
    public partial class AdderCvINer : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AdderCvINer()
        {
            InitializeComponent();
        }

        private void AdderCvINer_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Adder();
        }
        private async void Adder()
        {

            if (textBoxX1.Text != "")
            {

                int idw = Convert.ToInt32(await CV_Info.Serch(textBoxX1.Text));
                if (idw != -1)
                {
                    dataGridViewX1.Rows.Add(textBoxX1.Text);
                }

                textBoxX1.Text = "";
            }
        }

        private void AdderCvINer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Adder();
        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                int idw = Convert.ToInt32(await CV_Info.Serch((dataGridViewX1.Rows[i].Cells[0].Value).ToString()));
                if (idw != -1)
                {
                    CV_Info iNfo = new CV_Info(idw);

                    await iNfo.UpdateForGetTheCV(-1, null, "");

                }

                //    MessageBox.Show( (await CV_Info.Serch(textBoxX1.Text)).ToString());

            }
            MegBox.Show("تم المعالجة");
        }
    }
}