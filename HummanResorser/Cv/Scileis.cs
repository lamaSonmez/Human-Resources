using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    public class Scileis : DataBase ,IaddName
    {

        public static List<Scileis> ScileislList = new List<Scileis>();

        public Scileis (int id , string NameScil)
        {
            this.id = id;
            this.NameScil = NameScil;
            
        }
        /// <summary>
        /// id
        /// </summary>
        public int id
        {
            get;
            private set;
        }

        /// <summary>
        /// الأسم مهاره
        /// </summary>
        public string NameScil
        {
            get;
            private set;
        }

        public async static Task< List<Scileis>> GetAll()
        {

            List<Scileis> Lista = new List<Scileis>();

            List<List<object>> Adw = await Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [id]  ,[NameScil]  FROM [HR_SARC].[dbo].[Scileis] where [Delete] = 0"));
          

      

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Scileis(Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1])));

            return Lista;
        }


        public System.Data.SqlClient.SqlCommand updata()
        {

            System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Scileis] SET [NameScil] = @NameScil WHERE id = @id");
            SqlCommand.Parameters.AddWithValue("id", this.id);
            SqlCommand.Parameters.AddWithValue("NameScil", this.NameScil);
            return SqlCommand;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {

            System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[Scileis]([NameScil] ,[Delete]) VALUES(@NameScil,0)");
            SqlCommand.Parameters.AddWithValue("NameScil", this.NameScil);
            return SqlCommand;

        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            throw new NotImplementedException();
        }

        public string RetunNameString()
        {
            return this.NameScil;
        }

        public int RetunIdNumber()
        {
            return this.id;
        }
    }
}
