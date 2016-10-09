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
    public class NameTeamType  : IaddName , DataBase
    {
        /// <summary>
        /// متغير عام يحفظ جميع أنوع الفرق
        /// </summary>
        static public List<NameTeamType> NameTeamTypeStatic = new List<NameTeamType>();

        /// <summary>
        /// id
        /// </summary>
        /// 
        public int id
        {
            get;
            private set;
        }
        


        /// <summary>
        /// نوع الفريق
        /// </summary>
        public string TypeOfTeam
        {
            get;
            private set;
        }

        /// <summary>
        /// إرجاع قيمة للضافة في Combox
        /// </summary>
        /// <returns>تغير قيمة نص للإضافة</returns>
        public string RetunNameString()
        {
            return TypeOfTeam;

        }

        /// <summary>
        /// إنشاء كائن جديد
        /// </summary>
        /// <param name="TypeOfTeam">إسم الفريق</param>
        public NameTeamType (int id, string TypeOfTeam)
        {
            this.id = id;
            this.TypeOfTeam = TypeOfTeam;

        }

        public static List<NameTeamType> GetAll()
        {

             List<NameTeamType> Lista = new List<NameTeamType> ( ) ;

             Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [Id],[TypeOfTeam] FROM [HR_SARC].[dbo].[NameTeamType_Ta] where [Delete] = 0"));
             while (!temp.IsCompleted)
             { }
       
             List<List<object>> Adw = temp.Result;

           for (int i = 0; i < Adw.Count; i++ )
               if (Adw[i].Count!=0)
               Lista.Add(new NameTeamType(  Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1])));

           return Lista;
        }

        public System.Data.SqlClient.SqlCommand updata()
        {
            throw new NotImplementedException();
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[NameTeamType_Ta] ([TypeOfTeam]  ,[Delete]) VALUES (@TypeOfTeam  ,@Delete) ");

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("TypeOfTeam", this.TypeOfTeam));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));
            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            throw new NotImplementedException();
        }


        public int RetunIdNumber()
        {
            return id;
        }
    }
}
