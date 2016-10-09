using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HummanResorser
{
    public partial class newQustion : DevComponents.DotNetBar.Metro.MetroForm
    {
        Qustiones Qustiones1 = null;

        public newQustion(Qustiones Qustiones1)
        {
            InitializeComponent();
            if ( Qustiones1 == null)
            {
                this.Text = "إضافة سؤال جديد";
                buttonX2.Text = "إضافة";

            }else
            {
                textBoxX1.Text = Qustiones1.name;

            }
        }

        private void newQustion_Load(object sender, EventArgs e)
        {

        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxX1.Text))
            { MegBox.Show("يجب أدخال", this);
                return;
            }

            if (Qustiones1 == null)
            {
                Qustiones1 = new Qustiones(0, textBoxX1.Text);

               await Sqldatabasethrding.SqlSaveVitl(Qustiones1.adder());
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Qustiones1 = new Qustiones(Qustiones1.id, textBoxX1.Text);
                await Sqldatabasethrding.SqlSaveVitl(Qustiones1.updata());
                this.DialogResult = DialogResult.OK;
            }
        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            if (Qustiones1 != null)
            {
                await Sqldatabasethrding.SqlSaveVitl(Qustiones1.Delete());
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
