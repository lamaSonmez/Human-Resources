using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{


    /// <summary>
    /// جدول بأسماء الفرق
    /// </summary>
    /// <remarks>أسماء الفرق</remarks>
    public class NameTeam : DataBase, IaddName 
    {
        /// <summary>
        /// متغير عام يحفظ جميع أسماء الفرق 
        /// </summary>
        static public List<NameTeam> NameTeamStatic = new List<NameTeam>();


       public NameTeam (int id , string nameOftame , int NameTeamType_Id )
        {
           
                this.id = id;
                this.nameOftame = nameOftame;
                this.NameTeamType_Id = NameTeamType_Id;
                
            
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
        /// أسم الفريق
        /// </summary>
        public string nameOftame
        {
            get;
            private set;
        }

        /// <summary>
        /// تصنيف الفريق
        /// </summary>
        public int NameTeamType_Id
        {
            get;
            private set;
        }


        /// <summary>
        /// جلب جميع الأسماء
        /// </summary>
        /// <returns></returns>
        public async static Task< List<NameTeam>> GetAll()
        {

            List<NameTeam> Lista = new List<NameTeam>();

            List<List<object>> Adw = await Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [Id],[nameOftame],[NameTeamType_Id]  FROM [HR_SARC].[dbo].[NameTeam_Ta] where [Delete] = 0"));



            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new NameTeam(Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1]), Convert.ToInt32(Adw[i][2])));

            return Lista;
        }




        public System.Data.SqlClient.SqlCommand updata()
        {
            //UPDATE [dbo].[NameTeam_Ta] SET [nameOftame] = @nameOftame ,[NameTeamType_Id] = @NameTeamType_Id,[Delete] = @Delete WHERE id = @id
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[NameTeam_Ta] SET [nameOftame] = @nameOftame ,[NameTeamType_Id] = @NameTeamType_Id WHERE id = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", this.id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("nameOftame", this.nameOftame));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("NameTeamType_Id", this.NameTeamType_Id));
            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[NameTeam_Ta]([nameOftame],[NameTeamType_Id],[Delete])VALUES (@nameOftame ,@NameTeamType_Id ,@Delete)");

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("nameOftame", this.nameOftame));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("NameTeamType_Id", this.NameTeamType_Id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));
            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            throw new NotImplementedException();
        }

        public string RetunNameString()
        {
            return nameOftame;
        }


        public int RetunIdNumber()
        {
            return id;
        }
    }

    
}
