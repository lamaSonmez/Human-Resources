using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    public class HaveScil : DataBase
    {
        public void EditCV_Info_ID(int CV_Info_ID)
        {
            if (this.CV_Info_ID < 1)
                this.CV_Info_ID = CV_Info_ID;
        }

        public HaveScil ( int id , int Scileis_ID , int CV_Info_ID , int Star  )
        {


            this.id = id;
            this.Scileis_ID = Scileis_ID;
            this.CV_Info_ID = CV_Info_ID;
            this.Star = Star;
        }
        public async static System.Threading.Tasks.Task<List<HaveScil>> GetByidInfoCV(int CV_Info_ID)
        {
            List<HaveScil> Lista = new List<HaveScil>();

            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [id],[Scileis_ID],[CV_Info_ID],[Star] FROM [dbo].[HaveScil] where [Delete] = 0 and CV_Info_ID = @CV_Info_ID");
            SqlComm.Parameters.AddWithValue("@CV_Info_ID", CV_Info_ID);
            List<List<object>> Adw = await Sqldatabasethrding.GetSql(SqlComm);


            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new HaveScil(Convert.ToInt32(Adw[i][0]), Convert.ToInt32(Adw[i][1]), Convert.ToInt32(Adw[i][2]), Convert.ToInt32(Adw[i][3])));

            return Lista;
        }
        public async static System.Threading.Tasks.Task<bool> GetHAVECVSELC(int CV_Info_ID, int Scileis_ID)
        {
      

            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [id] FROM [HR_SARC].[dbo].[HaveScil] where [Delete] = 0 and CV_Info_ID = @CV_Info_ID and Scileis_ID =@Scileis_ID");
            SqlComm.Parameters.AddWithValue("@CV_Info_ID", CV_Info_ID);
            SqlComm.Parameters.AddWithValue("@Scileis_ID", Scileis_ID);
            List<List<object>> Adw = await Sqldatabasethrding.GetSql(SqlComm);


            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    return true;

            return false;
        }
   
        /// <summary>
        /// id
        /// </summary>
        public int id
        {
            get;
            private set;
        }
        public int Scileis_ID
        {

            get;
            private set;

        }

        /// <summary>
        /// ربط id CV_Info
        /// </summary>
        public int CV_Info_ID
        {
            get;
            private set;
        }

        /// <summary>
        /// التقيم 5 Star
        /// </summary>
        public int Star
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

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[HaveScil]([CV_Info_ID],[Scileis_ID] ,[Star],[Delete]) VALUES(@CV_Info_ID ,@Scileis_ID,@Star,0)");

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("CV_Info_ID", this.CV_Info_ID));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Scileis_ID", this.Scileis_ID));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Star", this.Star));
            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            throw new NotImplementedException();
        }
    }
}
