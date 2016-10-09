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
    public partial class AssisngTeamVitl : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AssisngTeamVitl()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            UserAndNameAdderingToWebSite UserAndNameAdderingToWebSite = new UserAndNameAdderingToWebSite();
            UserAndNameAdderingToWebSite.ShowDialog();

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            AssingDateGetWebSite AssingDateGetWebSite = new AssingDateGetWebSite();
            AssingDateGetWebSite.ShowDialog();

        }

        private void AssisngTeamVitl_Load(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            SetQustionInDataBase SetQustionInDataBase1 = new SetQustionInDataBase();
            SetQustionInDataBase1.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            AdderAssing AdderAssing1 = new AdderAssing();
            AdderAssing1.ShowDialog();
        }
    }
}