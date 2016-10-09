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
    /// <remarks>أسماء الدورات</remarks>
    public class NameOfCouress : IaddName, DataBase 
    {
        public static List<NameOfCouress> NameOfCouresslist = new List<NameOfCouress>();
        public NameOfCouress(int id, DateTime dataStart, DateTime DataENd, bool Suport, int Id_TypeofCouress_ta, string Decrption, int IntCoures, int WhereIS)
        {

            this.id = id;
            this.dataStart = dataStart;
            this.DataENd = DataENd;
            this.Suport = Suport;
            this.Id_TypeofCouress_ta = Id_TypeofCouress_ta;
            this.Decrption = Decrption;
            this.IntCoures = IntCoures;
            this.WhereIS = WhereIS;
        }

        public void Edit( DateTime dataStart, DateTime DataENd, bool Suport, int Id_TypeofCouress_ta, string Decrption, int IntCoures, int WhereIS)
        {

            
            this.dataStart = dataStart;
            this.DataENd = DataENd;
            this.Suport = Suport;
            this.Id_TypeofCouress_ta = Id_TypeofCouress_ta;
            this.Decrption = Decrption;
            this.IntCoures = IntCoures;
            this.WhereIS = WhereIS;
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
        public DateTime dataStart
        {
            get;
            private set;
        }

        /// <summary>
        /// تاريخ الإنتهاء
        /// </summary>
        public DateTime DataENd
        {
            get;
            private set;
        }

        /// <summary>
        /// مدعومة
        /// </summary>
        public bool Suport
        {
            get;
            private set;
        }

        /// <summary>
        /// نوع الدورة
        /// </summary>
        public int Id_TypeofCouress_ta
        {
            get;
            private set;
        }

        /// <summary>
        /// وصف الدورة
        /// </summary>
        public string Decrption
        {
            get;
            private set;
        }

        /// <summary>
        /// رقم الدورة
        /// </summary>
        public int IntCoures
        {
            get;
            private set;
        }


        /// <summary>
        /// مكان الدورة
        /// </summary>
        public int WhereIS
        {
            get;
            private set;
        }

        public string RetunNameString()
        {
            return Decrption + "| رقم الدورة " + Convert.ToString(IntCoures) + "| تاريخ:" + dataStart.ToShortDateString();
        }

        public int RetunIdNumber()
        {
            return id;
        }

        public System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[NameOfCouress_ta] SET [dataStart] = @dataStart,[DataENd] = @DataENd,[Suport] = @Suport,[Id_TypeofCouress_ta] = @Id_TypeofCouress_ta,[Decrption] = @Decrption,[IntCoures] = @IntCoures,[WhereIS] = @WhereIS WHERE id = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("dataStart", this.dataStart));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("DataENd", this.DataENd));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Suport", this.Suport));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_TypeofCouress_ta", this.Id_TypeofCouress_ta));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Decrption", Decrption));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("IntCoures", IntCoures));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("WhereIS", WhereIS));
             SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", this.id));
            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[NameOfCouress_ta]    ([dataStart] ,[DataENd]   ,[Suport]  ,[Id_TypeofCouress_ta]  ,[Decrption] ,[IntCoures],[WhereIS],[Delete])  VALUES (@dataStart,@DataENd,@Suport,@Id_TypeofCouress_ta ,@Decrption,@IntCoures ,@WhereIS,@Delete)");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("dataStart", this.dataStart));

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("DataENd", this.DataENd));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Suport", this.Suport));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_TypeofCouress_ta", this.Id_TypeofCouress_ta));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Decrption", this.Decrption));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("IntCoures", this.IntCoures));

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("WhereIS", this.WhereIS));
          
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));

            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[NameOfCouress_ta] SET [Delete] = @Delete WHERE id = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", true));

            return SqlCommand1;
        }

        public static List<NameOfCouress> GetAll()
        {
            List<NameOfCouress> Lista = new List<NameOfCouress>();
            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [Id],[dataStart],[DataENd],[Suport],[Id_TypeofCouress_ta]   ,[Decrption] ,[IntCoures] , WhereIS FROM [HR_SARC].[dbo].[NameOfCouress_ta] where [Delete] = 0");
            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new NameOfCouress(Convert.ToInt32(Adw[i][0]), ClassConvert.ConvDateTime(Adw[i][1]), ClassConvert.ConvDateTime(Adw[i][2]), ClassConvert.ConvBool(Adw[i][3]), Convert.ToInt32(Adw[i][4]), Convert.ToString(Adw[i][5]), Convert.ToInt32(Adw[i][6]), Convert.ToInt32(Adw[i][7])));
            
            return Lista;
        }

        public static int SerchByListStaticRetId( int Id_TypeofCouress_ta , int IntCoures  )
        {

            for (int i = 0; i < NameOfCouresslist.Count; i++)
            {
                if (NameOfCouresslist[i].Id_TypeofCouress_ta == Id_TypeofCouress_ta && NameOfCouresslist[i].IntCoures == IntCoures)
                    return NameOfCouresslist[i].id;
            }

            return -1;

        }


    }
}
