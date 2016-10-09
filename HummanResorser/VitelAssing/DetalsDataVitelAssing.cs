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
    public partial class DetalsDataVitelAssing : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DetalsDataVitelAssing(vitelAssingInformation vitelAssingInformation1)
        {
            InitializeComponent();
            ClassDataGridViewDo.DataGridEnterAsncyGrAllname(dataGridViewX1, vitelAssingInformation1);
            labelX2.Text = "%" + Convert.ToInt32(vitelAssingInformation1.GetResut()).ToString();
            labelX4.Text = Vitl.VitlIdAndName(vitelAssingInformation1.GetidInformation()).Name;
        }
    }
}