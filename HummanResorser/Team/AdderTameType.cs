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
    public partial class AdderTameType : DevComponents.DotNetBar.Metro.MetroForm
    {
    public    NameTeamType NameTeamType= null;

        public AdderTameType()
        {
            InitializeComponent();
        }

        

        private void AdderTameType_Load(object sender, EventArgs e)
        {
          if ( NameTeamType == null )
         {
                buttonX1.Text = "إضافة";
              
         }
         else
         {
             textBoxX1.Text = NameTeamType.TypeOfTeam; 
               
             buttonX1.Text = "تعديل";

         }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            NameTeamType = new NameTeamType(0, textBoxX1.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK; 

        
        }
    }
}