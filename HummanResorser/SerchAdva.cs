using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HummanResorser
{

  

    public partial class SerchAdva : DevComponents.DotNetBar.Metro.MetroForm
    {
        SelectTypeSerchCorres TypeCorr = new SelectTypeSerchCorres();
        SelectTypeJop selecttypejop = new SelectTypeJop();
        SelectInformationDate SelectInformation = new SelectInformationDate();
        SelectTeamForAdvSerch SelectTeamForAdvSerch = new SelectTeamForAdvSerch();
        SqlCommand Sqlcom = new SqlCommand();
        SqlCommand SqlInfor = new SqlCommand();
        List<int> idJop = new List<int>();
        List<int> idTema = new List<int>();

        string information = "";
        SerchAdvaCoursClass SerchAdvaCours = new SerchAdvaCoursClass(new List<int>(), new List<bool>(), new DateTime(), new DateTime());
        public SerchAdva()
        {
            InitializeComponent();
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void buttonX3_Click(object sender, EventArgs e)
        {
            buttonX3.Enabled = false;
            
            SqlInfor = new SqlCommand();

            for (int i = 0; i < Sqlcom.Parameters.Count; i++)
            {
                for (int j = 0; j < SqlInfor.Parameters.Count; j++)
                {
                    if (SqlInfor.Parameters[j].ParameterName == Sqlcom.Parameters[i].ParameterName)
                        goto Up;
                }
                SqlInfor.Parameters.Add(new System.Data.SqlClient.SqlParameter(Sqlcom.Parameters[i].ParameterName, Sqlcom.Parameters[i].Value));

                goto End;
            Up:
                SqlInfor.Parameters.Add(new System.Data.SqlClient.SqlParameter(Sqlcom.Parameters[i].ParameterName + "1", Sqlcom.Parameters[i].Value));
        End:
            ;

            }
            
            dataGridViewX1.Rows.Clear();

          await  Sqldatabasethrding.WaitSqlsersh(textBoxX1.Text, SerchAdvaCours, idJop, idTema , checkBoxX1.Checked, information, SqlInfor, dataGridViewX1 ,dateTimeInput1.Value,dateTimeInput2.Value );
            buttonX3.Enabled = true;

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
             

            if (TypeCorr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                SerchAdvaCours = new SerchAdvaCoursClass(TypeCorr.idTypeofcorsSerch, TypeCorr.idTypeofcorsSerchBoll
             , TypeCorr.datetmestart
              , TypeCorr.datetmeend
              );

            }
            else
            {
                TypeCorr = new SelectTypeSerchCorres();
                SerchAdvaCours = new SerchAdvaCoursClass(TypeCorr.idTypeofcorsSerch, TypeCorr.idTypeofcorsSerchBoll
           , TypeCorr.datetmestart
            , TypeCorr.datetmeend
            );
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

            this.idJop.Clear();
            if (selecttypejop.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                this.idJop = selecttypejop.idjopSerch;
            }
            else
            {
                selecttypejop = new SelectTypeJop();
                this.idJop = selecttypejop.idjopSerch;
            }

        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

            this.idTema.Clear();
            if (SelectTeamForAdvSerch.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                this.idTema = SelectTeamForAdvSerch.idjopSerch;
              
            }
            else
            {
                SelectTeamForAdvSerch = new SelectTeamForAdvSerch();
                this.idTema = SelectTeamForAdvSerch.idjopSerch;
            }

        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RibbonForm2 Detalis1 = new RibbonForm2();
                this.Opacity = 0.5;
                Detalis1.idvite = ClassConvert.Convint(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value);
                Detalis1.ShowDialog();
                this.Opacity = 1;
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            if (SelectInformation.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Sqlcom = new SqlCommand();
                this.information = SelectInformation.ParamterrMakeSql1.CommanderCondtionAll(Sqlcom);
            }
            else
            {
                SelectInformation = new SelectInformationDate();

                this.information = "";
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {

        }

        private void SerchAdva_Load(object sender, EventArgs e)
        {

        }

        private async void buttonX13_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            List<int> sfe = new List<int>();

            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                sfe.Add(Convert.ToInt32(dataGridViewX1.Rows[i].Cells[0].Value));
            }
            GetDateByID GetDateByID = null;
            await Task.Run(() =>
            {
                GetDateByID = new GetDateByID(sfe);
            }
                );
            GetDateByID.ShowDialog();
            this.Enabled = true;
        }

        private void dataGridViewX1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            labelX2.Text = dataGridViewX1.Rows.Count.ToString();
        }

        private void buttonX6_Click_1(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked) {

                List<int> IdInfromation = new List<int>();

                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    IdInfromation.Add(Convert.ToInt32(dataGridViewX1.Rows[i].Cells[0].Value));
                }
                IDCartOut IDCartOut1 = new IDCartOut(IdInfromation);
                IDCartOut1.ShowDialog();
            }
        }
    }



    public class SerchAdvaCoursClass
    {

        public DateTime datetmestart
        {
            get;
            private set;
        }
        public DateTime datetmeend
        {
            get;
            private set;
        }
        public List<int> idTypeofcorsSerch
        {
            get;
            private set;
        }
        public List<bool> idTypeofcorsSerchbool
        {
            get;
            private set;
        }
        public SerchAdvaCoursClass(List<int> idTypeofcorsSerch, List<bool> idTypeofcorsSerchbool, DateTime datetmestart, DateTime datetmeend)
        {
            this.idTypeofcorsSerch = idTypeofcorsSerch;
            
            this.datetmestart = datetmestart;
            this.datetmeend = datetmeend;

            this.idTypeofcorsSerchbool = idTypeofcorsSerchbool;

        }

    }


    public class IDinformationAdvSrch
    {

        public int idinformation { get; private set; }
        public int IdNameCoures { get; private set; }
        public int IdTeam { get; private set; }

        public int idJop { get; private set; }
        public IDinformationAdvSrch(int idinformation, int IdNameCoures)
        {
            this.idinformation = idinformation;
            this.IdNameCoures = IdNameCoures;

        }

        public IDinformationAdvSrch(int idinformation, int IdNameCoures, int IdTeam)
        {
            this.idinformation = idinformation;
            this.IdNameCoures = IdNameCoures;
            this.IdTeam = IdTeam;

        }
        public IDinformationAdvSrch(int idinformation, int IdNameCoures, int IdTeam, int idJop)
        {
            this.idinformation = idinformation;
            this.IdNameCoures = IdNameCoures;
            this.IdTeam = IdTeam;
            this.idJop = idJop;

        }



      
    }

        public class IDinformationAdvSrchFullCoures :IDinformationAdvSrch
        {


            List<int> ListCoures = new List<int> ();
            List<int> ListTeam = new List<int>();
            List<int> ListJop = new List<int>();
            public bool IsActiv { get; private set; }
          
            public IDinformationAdvSrchFullCoures(int idinformation, List<IDinformationAdvSrch> IDinformationAdvSrchList)
                : base(idinformation, 0)
            {
                for (int i = 0; i < IDinformationAdvSrchList.Count; i++)
                {
                    if (IDinformationAdvSrchList[i].idJop != 0)
                        ListJop.Add(IDinformationAdvSrchList[i].idJop);

                    if (IDinformationAdvSrchList[i].IdNameCoures != 0)
                        ListCoures.Add(IDinformationAdvSrchList[i].IdNameCoures);

                    if (IDinformationAdvSrchList[i].IdTeam != 0)
                        ListTeam.Add(IDinformationAdvSrchList[i].IdTeam);

                }
            }
            public IDinformationAdvSrchFullCoures(int idinformation)
                : base(idinformation, 0)
            {
             
               
                
            }

            public void SetAtciv ()
            {
                IsActiv = true;
            }
            internal void AddJop(int p)
            {
                ListJop.Add(p);

                
            }

            internal void AddCoures(int p)
            {
                ListCoures.Add(p);
            }

            internal void AddTeam(int p)
            {
                ListTeam.Add(p);
          
            }

            public static async Task<List<IDinformationAdvSrchFullCoures>> GetHaveAll(List<int> IdCour, List<int> IdJop, List<int> IdTeam, bool IsActiv, List<IDinformationAdvSrchFullCoures> IDinformationAdvSrchFullCoureslist)
            {

                List<IDinformationAdvSrchFullCoures> IDinformationRetun = new List<IDinformationAdvSrchFullCoures>();
                await Task.Run(() =>
                {
                    foreach (var item in IDinformationAdvSrchFullCoureslist)
                    {
                        if (GetHave(IdCour, IdJop, IdTeam, IsActiv, item))
                            IDinformationRetun.Add(item);
                    }
                }
                 );
                return IDinformationRetun;

            }

             private static  bool GetHave(List<int> IdCour, List<int> IdJop, List<int> IdTeam, bool IsActiv, IDinformationAdvSrchFullCoures IDinformationAdvSrchFullCoures)
            {
                
                if (IsActiv)
                    if (!IDinformationAdvSrchFullCoures.IsActiv)
                        return false;

                 foreach (var Cour in IdCour)
	                {
                        if (IDinformationAdvSrchFullCoures.ListCoures.IndexOf(Cour) == -1)
                            return false;
	                }

                 foreach (var Cour in IdJop)
                 {
                     if (IDinformationAdvSrchFullCoures.ListJop.IndexOf(Cour) == -1)
                         return false;
                 }
                 foreach (var Cour in IdTeam)
                 {
                     if (IDinformationAdvSrchFullCoures.ListTeam.IndexOf(Cour) == -1)
                         return false;
                 }
                 return true;
                 

            }
          }
}