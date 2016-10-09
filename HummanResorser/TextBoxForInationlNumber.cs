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
        public partial class TextBoxForInationlNumber : DevComponents.DotNetBar.Controls.TextBoxX
    {
        public string ErrorText = "رقم الوطني خاطئ";
        public bool Errorbool = false;
        public TextBoxForInationlNumber()
        {
            InitializeComponent();
        }

        private void TextBoxForInationlNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Convert.ToChar(8) != e.KeyChar)
                e.Handled = true;
        }

        private void TextBoxForInationlNumber_Leave(object sender, EventArgs e)
        {
            if (this.Text.Length != 11 && this.Text.Length != 0 )
            {
                Errorbool = true;
                errorProvider1.SetError(this, "رقم الوطني خطأ");
            }
            else
            {
                Errorbool = false;
                errorProvider1.Clear();
            }
        
        }
    }
}
