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
    /// <remarks>المناصب</remarks>
    public class Jop : DataBase, IaddName 
    {

        static public List<Jop> JopStatic = new List<Jop>();
       

        public Jop(int id, string NvacherWord, string NvacherWordEng, bool Sex)
        {
            this.id = id;
            this.NvacherWord = NvacherWord;
            this.NvacherWordEng = NvacherWordEng;
            this.Sex = Sex;

        }
        /// <summary>
        /// معرف
        /// </summary>
        public int id
        {
            get;
          private  set;
        }

        /// <summary>
        /// اسم العمل
        /// </summary>
        public string NvacherWord
        {
            get;
            private set;
        }

        /// <summary>
        /// اسم العمل بإنكليزي
        /// </summary>
        public string NvacherWordEng
        {
            get;
            private set;
        }

        /// <summary>
        /// جنس
        /// </summary>
        public bool Sex
        {
            get;
            private set;
        }

        public System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Jop_Ta] SET [NvacherWord] = @NvacherWord,[NvacherWordEng] = @NvacherWordEng  WHERE id = @id");
            Sqlcom.Parameters.AddWithValue("id", this.id);
            Sqlcom.Parameters.AddWithValue("NvacherWord", this.NvacherWord);
            Sqlcom.Parameters.AddWithValue("NvacherWordEng", this.NvacherWordEng);
            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[Jop_Ta]([NvacherWord],[NvacherWordEng],[Sex],[Delete]) VALUES(@NvacherWord,@NvacherWordEng ,0,0)");
            Sqlcom.Parameters.AddWithValue("NvacherWord", this.NvacherWord);
            Sqlcom.Parameters.AddWithValue("NvacherWordEng", this.NvacherWordEng);
            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Jop_Ta] SET [Delete] = 1 WHERE id = @id");
            Sqlcom.Parameters.AddWithValue("id", this.id);
            
            return Sqlcom;
        }

        public string RetunNameString()
        {
            return this.NvacherWord;
        }
              public int RetunIdNumber()
        {
            return id;
        }


        /// <summary>
        /// أرجع جميع الأعامل
        /// </summary>
        /// <returns></returns>
        public static List<Jop> GetAll()
        {

            List<Jop> Lista = new List<Jop>();

            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [Id] ,[NvacherWord],[NvacherWordEng] ,[Sex] ,[Delete] FROM [HR_SARC].[dbo].[Jop_Ta] where [Delete] = 0"));
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Jop(Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1]), Convert.ToString(Adw[i][2]), Convert.ToBoolean(Adw[i][3])));

            return Lista;
        }



  

    }
}
