using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
  public  class Valuationname : DataBase , IaddName
    {
        public static List<Valuationname> Valuationnamelist = null;

        public static List<string> ValuationnameTypeInt = new List<string>();

        public int id { get;  set; }

        public string Name { get; private set; }

        public int Type { get; private set; }

        public Valuationname ( int id , string Name , int Type)
        {
            this.id = id;
            this.Name = Name;
            this.Type = Type;

        }
        public static List<Valuationname> GetAll()
        {

            List<Valuationname> Lista = new List<Valuationname>();

            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT  [id],[Name],[Type],[Delete]FROM [HR_SARC].[dbo].[Valuationname_Ta] where [Delete] = 0"));
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Valuationname(Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1]) , Convert.ToInt32(Adw[i][2])));

            return Lista;
        }
        public SqlCommand adder()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[Valuationname_Ta] ([Name] ,[Type],[Delete])output INSERTED.ID VALUES(@Name,@Type ,@Delete)");

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Name", Name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Type", Type));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));
            return SqlCommand1;
        }

        public SqlCommand Delete()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Valuationname_Ta] SET [Delete] = 1 WHERE [id] = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));
          
            return SqlCommand1;
        }

        public SqlCommand updata()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Valuationname_Ta] SET [Name] = @Name,[Type] =@Type WHERE [id] = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Name", Name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Type", Type));

            return SqlCommand1;
        }

        public string RetunNameString()
        {
            return Name;
        }

        public int RetunIdNumber()
        {
            return id;
        }
    }
}
