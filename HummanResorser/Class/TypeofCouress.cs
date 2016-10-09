using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    /// <summary>
    /// Main
    /// </summary>
    /// <remarks>أنواع الدورات</remarks>
    public class TypeofCouress : DataBase, IaddName
    {
        public static List<TypeofCouress> TypeofCouressList = new List<TypeofCouress>();


        public int id
        {
            get;
            private set;
        }

        public string NameOfCouress
        {
            get;
            private set;

        }

        public int NameTeam_Ta
        {
            get;
            private set;

        }

        public System.Data.SqlClient.SqlCommand updata()
        {
            throw new NotImplementedException();
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[TypeofCouress_ta]([NameOfCouress] ,[NameTeam_Ta],[Delete]) VALUES(@NameOfCouress ,@NameTeam_Ta ,@Delete)");

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("NameOfCouress", this.NameOfCouress));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("NameTeam_Ta", this.NameTeam_Ta));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));
            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            throw new NotImplementedException();
        }

        public string RetunNameString()
        {
            return NameOfCouress; 

        }

        public int RetunIdNumber()
        {
            return id;
        }
        public TypeofCouress(int id, string NameOfCouress, int NameTeam_Ta)
        {
            this.id = id;
            this.NameOfCouress = NameOfCouress;
            this.NameTeam_Ta = NameTeam_Ta;
        }
        
        public  static List<TypeofCouress> GetAll()
        {
            List<TypeofCouress> Lista = new List<TypeofCouress>();
            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [Id],[NameOfCouress],[NameTeam_Ta] FROM [dbo].[TypeofCouress_ta] where [Delete] = 0");
            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new TypeofCouress(Convert.ToInt32(Adw[i][0]), ClassConvert.ConvString(Adw[i][1]), ClassConvert.Convint(Adw[i][2])));

            return Lista;
        }
    }
}
