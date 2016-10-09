using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
   public class CV_Out 
    {

       public int id{ get; private set;}
       public int ToTeamOut { get; private set; }
       public DateTime TodateOut { get; private set; }
       public int Cv_Info { get; private set; }
       public string Notes { get; private set; }
       public int ToOutTeam { get; private set; }
       public DateTime ToOutDate { get; private set; }
       public string Notesout { get; private set; }

       public CV_Out(int id, int ToTeamOut, DateTime TodateOut, int Cv_Info, string Notes, int ToOutTeam, DateTime ToOutDate , string Notesout) 
       {
        this.id = id;
        this.ToTeamOut = ToTeamOut;
        this.TodateOut = TodateOut;
        this.Cv_Info = Cv_Info;
        this.Notes = Notes;

       }


    }
}
