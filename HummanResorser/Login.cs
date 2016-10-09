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
    public partial class Login : DevComponents.DotNetBar.Metro.MetroForm
    {
        RibbonForm1 RibbonForm1 = null;
        public Login()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ChkPassWord();
        }

        private void ChkPassWord()
        {
            if (textBoxX1.Text == "Rama" && textBoxX2.Text == "Rama")
            {
                Runx();

            }
            else if (textBoxX1.Text == "mo" && textBoxX2.Text == "suse1987")
            {
              Sqldatabasethrding.sqlconction = "Data Source=SARC-1-HP\\M1992;Initial Catalog=HR_SARC;Integrated Security=True";
                Runx();

            }
            else
            {
                MegBox.Show("كلمة سر خطأ!");


            }
        }

        private void Runx()
        {
            this.Hide();
            //Loding loding = new Loding();


            // loding.ShowDialog();

            RibbonForm1.ShowDialog();
            this.Close();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            RibbonForm1 = new RibbonForm1();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
           if (  e.KeyData == Keys.Enter)
               ChkPassWord();

        }

        private void Login_HelpButtonClick(object sender, EventArgs e)
        {
            AboutBox1 AboutBox1 = new AboutBox1();
            AboutBox1.ShowDialog();
        }
    }
}