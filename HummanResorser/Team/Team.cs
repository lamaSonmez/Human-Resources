using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    /// <summary>
    /// Main
    /// </summary>
    /// <remarks>الفرق التي تطوع فيها</remarks>
    public class Team : DataBase, IaddName
    {
        public static List<int> ListNotAllAtive = new List<int>();
        public static List<String> Setwation = new List<String>();

           public void EdidInfoId ( int idInfo)
        {
            ID_informtion = idInfo;
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
        /// تاريخ البدأ
        /// </summary>
        public DateTime? date_Start
        {
            get;
            private set;
        }

        /// <summary>
        /// تاريخ الإنتهاء
        /// </summary>
        public DateTime? Date_End
        {
            get;
            private set;
        }

        /// <summary>
        /// Id معلومات الأساسية
        /// </summary>
        public int ID_informtion
        {
            get;
            private set;
        }

        /// <summary>
        /// أسم الفريق
        /// </summary>
        public int id_NameTeam_Ta
        {
            get;
            private set;
        }

        /// <summary>
        /// المنصب
        /// </summary>
        public int Id_Jop_Ta
        {
            get;
            private set;
        }

        /// <summary>
        /// رديف - أساسي  - دوار - موظف - غير فعال - تفعيل
        /// </summary>
        public int Setewation
        {
            get;
            private set;
        }


        public Team(int id, DateTime? date_Start, DateTime? Date_End, int ID_informtion, int id_NameTeam_Ta, int Id_Jop_Ta, int Setewation)
        {
           
          
            this.id = id;
            this.date_Start = date_Start;
            this.Date_End = Date_End;
            this.ID_informtion = ID_informtion;
            this.id_NameTeam_Ta = id_NameTeam_Ta;
            this.Id_Jop_Ta = Id_Jop_Ta;
            this.Setewation = Setewation;
        }
        public async static Task< List<Team>> GetByIdVil ( int id , bool Activet = false)
        {

            List<Team> Lista = new List<Team>();
        System.Data.SqlClient.SqlCommand SqlComm =    new System.Data.SqlClient.SqlCommand("SELECT [Id],[date_Start] ,[Date_End],[ID_informtion],[id_NameTeam_Ta],[Id_Jop_Ta] ,[Setewation],[Delete] FROM [HR_SARC].[dbo].[Team_ta] where [Delete] = 0 and [ID_informtion] = @id ");
        if (Activet)
            SqlComm.CommandText += " And ( [Date_End] is null ) ";
            SqlComm.Parameters.AddWithValue("@id",id);
            List<List<object>> Adw = await Sqldatabasethrding.GetSql(SqlComm);
            

        
            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Team(Convert.ToInt32(Adw[i][0]), ClassConvert.ConvDateTimeNull(Adw[i][1]), ClassConvert.ConvDateTimeNull(Adw[i][2]), Convert.ToInt32(Adw[i][3]), Convert.ToInt32(Adw[i][4]), Convert.ToInt32(Adw[i][5]), Convert.ToInt32(Adw[i][6])));

            return Lista;



        }

        public void Eidt( DateTime? date_Start, DateTime? Date_End, int ID_informtion, int id_NameTeam_Ta, int Id_Jop_Ta, int Setewation)
        {
       
            this.date_Start = date_Start;
            this.Date_End = Date_End;
            this.ID_informtion = ID_informtion;
            this.id_NameTeam_Ta = id_NameTeam_Ta;
            this.Id_Jop_Ta = Id_Jop_Ta;
            this.Setewation = Setewation;
        }

        public System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Team_ta] SET [date_Start] = @date_Start,[Date_End] = @Date_End,[ID_informtion] = @ID_informtion,[id_NameTeam_Ta] = @id_NameTeam_Ta,[Id_Jop_Ta] = @Id_Jop_Ta,[Setewation] = @Setewation WHERE id = @id");

            if (this.date_Start != null) SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("date_Start", this.date_Start));
            else SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("date_Start", DBNull.Value));

            if (this.Date_End != null) SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Date_End", this.Date_End));
            else SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Date_End", DBNull.Value));

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_informtion", this.ID_informtion));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id_NameTeam_Ta", this.id_NameTeam_Ta));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_Jop_Ta", this.Id_Jop_Ta));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Setewation", this.Setewation));


            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", this.id));

            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[Team_ta] ([date_Start] ,[Date_End],[ID_informtion],[id_NameTeam_Ta],[Id_Jop_Ta],[Setewation] ,[Delete]) VALUES (@date_Start,@Date_End,@ID_informtion,@id_NameTeam_Ta,@Id_Jop_Ta,@Setewation,@Delete)");
         
            if (this.date_Start !=null) SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("date_Start", this.date_Start));
            else SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("date_Start",DBNull.Value));

            if (this.Date_End != null) SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Date_End", this.Date_End));
            else SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Date_End", DBNull.Value));

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("ID_informtion", this.ID_informtion));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id_NameTeam_Ta", this.id_NameTeam_Ta));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_Jop_Ta", this.Id_Jop_Ta));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Setewation", this.Setewation));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));

            
            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Team_ta] SET [Delete] =@Delete WHERE id = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", true));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", this.id));
            return SqlCommand1;
        }

     

        public string RetunNameString()
        {
            return NameTeam.NameTeamStatic[ClassDataGridViewDo.RetunIndexByIdSech(this.id_NameTeam_Ta, NameTeam.NameTeamStatic)].nameOftame;
        }

        public int RetunIdNumber()
        {
            return id;
        }

        public static List<Team> GetByGetbyIdNameName(int id , bool Ative )
        {

            List<Team> Lista = new List<Team>();
            string sqlCommand ="SELECT [Id],[date_Start] ,[Date_End],[ID_informtion],[id_NameTeam_Ta],[Id_Jop_Ta] ,[Setewation],[Delete] FROM [HR_SARC].[dbo].[Team_ta] where [Delete] = 0 and [id_NameTeam_Ta] = @id ";
            if (Ative)
            {
                sqlCommand += " And ( [Date_End] is null ) ";
                for (int i = 0; i < Team.ListNotAllAtive.Count; i++)
                {
                    sqlCommand += "  And [Setewation] !=" + Team.ListNotAllAtive[i].ToString();
                }
            }
            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand(sqlCommand);
            SqlComm.Parameters.AddWithValue("@id", id);


            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Team(Convert.ToInt32(Adw[i][0]), ClassConvert.ConvDateTimeNull(Adw[i][1]), ClassConvert.ConvDateTimeNull(Adw[i][2]), Convert.ToInt32(Adw[i][3]), Convert.ToInt32(Adw[i][4]), Convert.ToInt32(Adw[i][5]), Convert.ToInt32(Adw[i][6])));

            return Lista;



        }


        public static  async Task< bool> RetHaveVitelJop(int IDInformation, int Id_Jop_Ta)
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("SELECT [Id] FROM [HR_SARC].[dbo].[Team_ta] where [ID_informtion] = @ID_informtion and Id_Jop_Ta =@Id_Jop_Ta and Date_End is null and [Delete] = 0");
            Sqlcom.Parameters.AddWithValue("ID_informtion" ,IDInformation);
            Sqlcom.Parameters.AddWithValue("Id_Jop_Ta", Id_Jop_Ta);

            await Sqldatabasethrding.openConction();
            Sqlcom.Connection = Sqldatabasethrding.SqlConnection1;
            System.Data.SqlClient.SqlDataReader Rader =await  Sqlcom.ExecuteReaderAsync();
            try
            {

                while (await Rader.ReadAsync())
                {
                    return true;

                }
            }
            catch(Exception e )
            {
                ErrorClass.SaveErrorFile(e);

            }
            finally
            {
                Rader.Close();

            }

           return false;

        }

        public static async Task<bool> RetHaveVitelTeam(int ID_informtion, int id_NameTeam_Ta)
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("SELECT [Id] FROM [HR_SARC].[dbo].[Team_ta] where [ID_informtion] = @ID_informtion and id_NameTeam_Ta = @id_NameTeam_Ta and [Delete] = 0  and Date_End is null");
            Sqlcom.Parameters.AddWithValue("ID_informtion", ID_informtion);
            Sqlcom.Parameters.AddWithValue("id_NameTeam_Ta", id_NameTeam_Ta);

            await Sqldatabasethrding.openConction();
            Sqlcom.Connection = Sqldatabasethrding.SqlConnection1;
            System.Data.SqlClient.SqlDataReader Rader = await Sqlcom.ExecuteReaderAsync();
            try
            {

                while (await Rader.ReadAsync())
                {
                    return true;

                }
            }
            catch (Exception e)
            {
                ErrorClass.SaveErrorFile(e);

            }
            finally
            {
                Rader.Close();

            }

            return false;

        }


        public static async Task<bool> RetHaveVitelACtiv(int ID_informtion)
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("SELECT [Id] FROM [HR_SARC].[dbo].[Team_ta] where [ID_informtion] = @ID_informtion and [Delete] = 0  and Date_End is null");
            Sqlcom.Parameters.AddWithValue("ID_informtion", ID_informtion);

            await Sqldatabasethrding.openConction();
            Sqlcom.Connection = Sqldatabasethrding.SqlConnection1;
            System.Data.SqlClient.SqlDataReader Rader = await Sqlcom.ExecuteReaderAsync();
            try
            {

                while (await Rader.ReadAsync())
                {
                    return true;

                }
            }
            catch (Exception e)
            {
                ErrorClass.SaveErrorFile(e);

            }
            finally
            {
                Rader.Close();

            }

            return false;

        }
        public enum EnumTeam
        {

            id,
            date_Start,
            Date_End,
            ID_informtion,
            id_NameTeam_Ta,
            Id_Jop_Ta,
            Setewation,
            Delete

        }
    }



}
