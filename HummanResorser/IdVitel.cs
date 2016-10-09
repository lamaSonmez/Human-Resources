using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HummanResorser
{
    public partial class IdVitel : DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    {
        public string ErrorText = " رقم الهلال خاطئ";
        public bool Errorbool = false;
        public IdVitel()
        {
            InitializeComponent();
        }

        private void IdVitel_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void IdVitel_Leave(object sender, EventArgs e)
        {
            if (Text[7] =='_')
            {
                Errorbool = true;
                errorProvider1.SetError(this, "رقم المعرف خطأ");
            }
            else
            {
                Errorbool = false;
                errorProvider1.Clear();
            }
        }
    }
}
