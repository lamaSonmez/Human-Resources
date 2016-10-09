using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    public class CvTeamNeed : DataBase , IaddName
    {

        public static List<CvTeamNeed> CvTeamNeedList = new List<CvTeamNeed>();

        public CvTeamNeed (int id ,string FullName)
        {
            this.id = id;
            this.FullName = FullName;

        }


        public int id
        {
            get;
            private set;
        }

        /// <summary>
        /// اسم الفريق
        /// </summary>
        public string FullName
        {
            get;
            private set;
        }
    
        public System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[CvTeamNeed]SET [FullName] = @FullName WHERE id = @id");
            Sqlcom.Parameters.AddWithValue("FullName", this.FullName);
            Sqlcom.Parameters.AddWithValue("id", this.id);
            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[CvTeamNeed] ([FullName] ,[Delete]) VALUES(@FullName , @Delete)");
            Sqlcom.Parameters.AddWithValue("FullName", this.FullName);
            Sqlcom.Parameters.AddWithValue("Delete", false);
            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            throw new NotImplementedException();
        }

        public async static Task<List<CvTeamNeed>> GetAll()
        {

            List<CvTeamNeed> Lista = new List<CvTeamNeed>();

            List<List<object>> Adw = await Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [id] ,[FullName] FROM [HR_SARC].[dbo].[CvTeamNeed] where [Delete] = 0"));


            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new CvTeamNeed(Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1])));

            return Lista;
        }

        public string RetunNameString()
        {
            return this.FullName;
        }

        public int RetunIdNumber()
        {
            return this.id;
        }
    }
}
