using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    public class CV_Study : DataBase , IaddName
    {
        public static int NumberOfIdNotReg = -1;
       static public List<CV_Study> CV_StudyList = new List<CV_Study>();

        /// <summary>
        /// id
        /// </summary>
       public int id
       {
           get;
           private set;
       }

        /// <summary>
        /// الدراسة
        /// </summary>
        public string Sutdy
        {
            get;
            private set;
        }

        /// <summary>
        /// الرمز
        /// </summary>
        public string Sampl
        {
            get;
            private set;
        }
        public CV_Study(int id, string Sutdy, string Sampl)
        {
            this.id = id;
            this.Sutdy = Sutdy;
            this.Sampl = Sampl;



        }
        public async static Task< List<CV_Study>> GetAll()
        {

            List<CV_Study> Lista = new List<CV_Study>();

            List<List<object>> Adw = await Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [id] ,[Sutdy]  ,[Sampl]  FROM [HR_SARC].[dbo].[CV_Study] where [Delete] = 0"));
           

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new CV_Study(Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1]), Convert.ToString(Adw[i][2])));

            return Lista;
        }
    
        public System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[CV_Study] SET [Sutdy] = @Sutdy,[Sampl] =@Sampl WHERE id = @id");
            Sqlcom.Parameters.AddWithValue("Sutdy", this.Sutdy);
            Sqlcom.Parameters.AddWithValue("Sampl", this.Sampl);
            Sqlcom.Parameters.AddWithValue("id", this.id);

            return Sqlcom;
  

        }

        public System.Data.SqlClient.SqlCommand adder()
        {

            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[CV_Study]([Sutdy],[Sampl],[Delete]) VALUES(@Sutdy,@Sampl,@Delete)");
            Sqlcom.Parameters.AddWithValue("Sutdy", this.Sutdy);
            Sqlcom.Parameters.AddWithValue("Sampl", this.Sampl);
            Sqlcom.Parameters.AddWithValue("Delete", false);

            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            throw new NotImplementedException();
        }

        public string RetunNameString()
        {
            return this.Sutdy;
        }

        public int RetunIdNumber()
        {
            return this.id;
        }

        public async static Task< int> CV_studyID (string W)
        {

            System.Data.SqlClient.SqlCommand sql = new System.Data.SqlClient.SqlCommand("SELECT [id] FROM [HR_SARC].[dbo].[CV_Study] where sampl = @sampl ");
            sql.Parameters.AddWithValue("sampl", W);
            List<List<object>> Sqlb = await Sqldatabasethrding.GetSql(sql);

                if ( Sqlb.Count  != 0)
                    return Convert.ToInt32(Sqlb[0][0]);
                else
                    return NumberOfIdNotReg;

        }
    }
}
