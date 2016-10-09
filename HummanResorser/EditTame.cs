using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
namespace HummanResorser
{
    public partial class EditTame : DevComponents.DotNetBar.Metro.MetroForm
    {
     public int idVite = 0;
     public static int CountOfNew;
     public Team TeamEdit=null;
     public bool EditTemaJust = false;
     public string nameVit = "";
        public EditTame()
        {
            
            InitializeComponent();
        }

        private void EditTame_Load(object sender, EventArgs e)
        {
            AdderComvbox(id_NameTeam_Ta,NameTeamType.NameTeamTypeStatic,NameTeam.NameTeamStatic);
            AdderComvbox(Id_Jop_Ta,Jop.JopStatic);
            if (!EditTemaJust)
            {
                if (TeamEdit != null)
                {
                    idVite = TeamEdit.ID_informtion;
                    date_Start.Value = Convert.ToDateTime(TeamEdit.date_Start);
                    Date_End.Value = Convert.ToDateTime(TeamEdit.Date_End);
                    id_NameTeam_Ta.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(TeamEdit.id_NameTeam_Ta, NameTeam.NameTeamStatic);
                    Id_Jop_Ta.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(TeamEdit.Id_Jop_Ta, Jop.JopStatic);
                    Setewation.SelectedIndex = TeamEdit.Setewation;
                    buttonX1.Text = "تعديل";


                }
            }
            else
            {
                if (TeamEdit != null)
                {
                    idVite = TeamEdit.ID_informtion;
                    date_Start.Value = Convert.ToDateTime(TeamEdit.date_Start);
                    Date_End.Value = Convert.ToDateTime(TeamEdit.Date_End);
                    id_NameTeam_Ta.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(TeamEdit.id_NameTeam_Ta, NameTeam.NameTeamStatic);
                    id_NameTeam_Ta.Visible = false;
                    textBoxX1.Visible = true;
                    labelX2.Text = "المتطوع";
                    textBoxX1.Enabled = false;
                    textBoxX1.Text = nameVit;
                    Id_Jop_Ta.SelectedIndex = ClassDataGridViewDo.RetunIndexByIdSech(TeamEdit.Id_Jop_Ta, Jop.JopStatic);
                    Setewation.SelectedIndex = TeamEdit.Setewation;
                    buttonX1.Text = "تعديل";


                }
            }

                

                
        }
        public static int SerchByComBBox<T>(DevComponents.DotNetBar.Controls.ComboBoxEx ComboEx, List<T> Class)
        {
            
           return  ((IaddName) Class[ComboEx.SelectedIndex]).RetunIdNumber();
        }
        public static void AdderComvbox<T>(DevComponents.DotNetBar.Controls.ComboBoxEx ComboEx, List<T> Class)
        {
            foreach(IaddName DD in Class)
            {

                ComboEx.Items.Add(DD.RetunNameString());

            }


        }
        public static void AdderComvbox(DevComponents.DotNetBar.Controls.ComboBoxEx ComboEx, List<NameTeamType> mo, List<NameTeam> mo1)
        {
            var fe = from s in mo1
                     join e in mo
                    on s.NameTeamType_Id equals e.id
                     select new { e.TypeOfTeam, s.nameOftame };

            foreach (var strin in fe)
                ComboEx.Items.Add(strin.TypeOfTeam + " - " + strin.nameOftame);

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
          
            if (  TeamEdit == null )
            {
             
                TeamEdit = new Team(CountOfNew, ClassConvert.ConvDateTimeNull(date_Start.Value), ClassConvert.ConvDateTimeNull(Date_End.Value), idVite, SerchByComBBox(id_NameTeam_Ta, NameTeam.NameTeamStatic), SerchByComBBox(Id_Jop_Ta, Jop.JopStatic), Setewation.SelectedIndex);
                CountOfNew--;
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else
            {
                TeamEdit.Eidt(ClassConvert.ConvDateTimeNull( date_Start.Value),ClassConvert.ConvDateTimeNull( Date_End.Value), idVite, SerchByComBBox(id_NameTeam_Ta, NameTeam.NameTeamStatic), SerchByComBBox(Id_Jop_Ta, Jop.JopStatic), Setewation.SelectedIndex);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            
            this.Close();
        }

    }
}