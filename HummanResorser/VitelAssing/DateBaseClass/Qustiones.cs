using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
  public  class Qustiones : DataBase ,IaddName
    {

        public static List<Qustiones> Qustioneslist = null;
       public int id { get; private set; }

       public string name { get; private set; }

        public Qustiones ( int id , string name)
        {
            this.id = id;
            this.name = name;

        }

        public static List<Qustiones> GetAll()
        {

            List<Qustiones> Lista = new List<Qustiones>();

            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT  [id],[name],[Delete] FROM [HR_SARC].[dbo].[Qustiones] where [Delete] = 0"));
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Qustiones(Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1])));

            return Lista;
        }
        public SqlCommand adder()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[Qustiones] ([name],[Delete]) VALUES (@name ,@Delete)");

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("name", name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));
            return SqlCommand1;
        }

        public SqlCommand Delete()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Qustiones] SET  [Delete] = 1  WHERE [id] = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));
            return SqlCommand1;
        }

        public SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Qustiones] SET  [name] = @name  WHERE [id] = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));
            return SqlCommand1;
        }

        public string RetunNameString()
        {
            return name;
        }

        public int RetunIdNumber()
        {
            return id;
        }
    }
}
