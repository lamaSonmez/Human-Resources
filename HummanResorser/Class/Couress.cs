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
    /// <remarks>الدورات</remarks>
    public class Couress : DataBase, IaddName
    {
        static float RetultSect = 69.0001f; // علامة النجاح



        
        static int IntTemp = 0;
        static int TyepNamber = 0;
        static string StringSelect = "";

         public void Eidt(int id_NameOfCouress , int Id_Information ,int NumberOfdayregest , float Result )
        {
         
            this.id_NameOfCouress = id_NameOfCouress;
            this.Id_Information = Id_Information;
            this.NumberOfdayregest = NumberOfdayregest;
            this.Result = Result;

        }

        public void EdidInfoId(int idInfo)
        {
            Id_Information = idInfo;
        }

        public Couress ( int id ,int id_NameOfCouress , int Id_Information ,int NumberOfdayregest , float Result )
        {
            this.id = id;
            this.id_NameOfCouress = id_NameOfCouress;
            this.Id_Information = Id_Information;
            this.NumberOfdayregest = NumberOfdayregest;
            this.Result = Result;

        }

        public static List<Couress> GetByIdVil(int id , bool JustSecscc = false)
        {

            List<Couress> Lista = new List<Couress>();
            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [Id],[id_NameOfCouress],[Id_Information],[NumberOfdayregest],[Result] FROM [HR_SARC].[dbo].[Couress_ta] where Id_Information = @id and [Delete] = 0");
            if (JustSecscc)
            {
                SqlComm.CommandText += " and [Result] >= @RetultSect";
                SqlComm.Parameters.AddWithValue("RetultSect", RetultSect);
            }


            SqlComm.Parameters.AddWithValue("@id", id);
            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Couress(Convert.ToInt32(Adw[i][0]), Convert.ToInt32(Adw[i][1]), Convert.ToInt32(Adw[i][2]), Convert.ToInt32(Adw[i][3]), Convert.ToSingle(Adw[i][4])));

            return Lista;



        }
        public static List<Couress> GetByNameOfCores(int id)
        {

            List<Couress> Lista = new List<Couress>();
            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [Id],[id_NameOfCouress],[Id_Information],[NumberOfdayregest],[Result] FROM [HR_SARC].[dbo].[Couress_ta] where id_NameOfCouress = @id and [Delete] = 0");
            SqlComm.Parameters.AddWithValue("@id", id);
            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Couress(Convert.ToInt32(Adw[i][0]), Convert.ToInt32(Adw[i][1]), Convert.ToInt32(Adw[i][2]), Convert.ToInt32(Adw[i][3]), Convert.ToSingle(Adw[i][4])));

            return Lista;



        }
        public int id
        {
            get;
            private set;
        }

        /// <summary>
        /// id الدورة
        /// </summary>
        public int id_NameOfCouress
        {

            get;
            private set;
        }

        /// <summary>
        /// id معلومات الأساسية
        /// </summary>
        public int Id_Information
        {
            get;
            private set;
        }

        /// <summary>
        /// عدد الأيام
        /// </summary>
        public int NumberOfdayregest
        {
            get;
            private set;
        }

        /// <summary>
        /// النتيجة
        /// </summary>
        public float Result
        {
            get;
            private set;
        }

        public System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Couress_ta] SET [id_NameOfCouress] = @id_NameOfCouress,[Id_Information] = @Id_Information,[NumberOfdayregest] = @NumberOfdayregest ,[Result] = @Result  WHERE id = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id_NameOfCouress", this.id_NameOfCouress));
           SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_Information", this.Id_Information));    
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("NumberOfdayregest", this.NumberOfdayregest));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Result", this.Result));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", this.id));

            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[Couress_ta]  ([id_NameOfCouress] ,[Id_Information] ,[NumberOfdayregest] ,[Result],[Delete])VALUES(@id_NameOfCouress,@Id_Information,@NumberOfdayregest,@Result,@Delete)");

                 SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id_NameOfCouress", this.id_NameOfCouress));


                 SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_Information", this.Id_Information));


                SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("NumberOfdayregest", this.NumberOfdayregest));
                SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Result", this.Result));
                SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));


            return SqlCommand1;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Couress_ta] SET [Delete] = @Delete  WHERE id = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", true));
            return SqlCommand1;
        
        }


        public string RetunNameString()
        {
            throw new NotImplementedException();
        }

        public int RetunIdNumber()
        {
            return id;
        }

        public static async Task< bool>  GetIsItHaveCouresByIdInformation( int idinformation , int idCoures , bool IsId = false , bool DotHave = false)
        {
            if (idinformation <= 0)
                return false;

            string Op ="";

              foreach (NameOfCouress Name in NameOfCouress.NameOfCouresslist)
              {
                  if (IsId)
                  {
                      
                          if (Name.Id_TypeofCouress_ta == idCoures)
                              Op += " id_NameOfCouress = " + Name.id.ToString() + " Or";
                     
                  }
                  else
                  {
                     
                          if (Name.Id_TypeofCouress_ta == TypeofCouress.TypeofCouressList[idCoures].id)
                              Op += " id_NameOfCouress = " + Name.id.ToString() + " Or";
                    
                  }
              }
              
              Op = Op.Remove(Op.Length - 3, 3);
              StringSelect = Op;



              System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand(String.Format("SELECT id FROM [HR_SARC].[dbo].[Couress_ta] where [Id_Information]=  @Id_Information and {0} and ({1}) {2} ", "[Delete] = 0 ", Op, "and [Result] > " + RetultSect));
              SqlCommand1.Parameters.AddWithValue("Id_Information", idinformation);
          
                SqlCommand1.Connection = Sqldatabasethrding.SqlConnection1;
            System.Data.SqlClient.SqlDataReader Reader =await SqlCommand1.ExecuteReaderAsync();
            try{
                if (await Reader.ReadAsync())
                {
                    if (!DotHave)
                    {
                        return true;
                    }
                    else
                    { return false; }
                }
                else
                {
                    if (!DotHave)
                    {
                        return false;
                    }else
                    { return true; }
                }

            }catch(Exception e )
            {
                ErrorClass.SaveErrorFile(e);
            }
           finally{

                Reader.Close();
            }
            if (!DotHave)
            {
                return false;
            }
            else
            { return true; }

        }




        public enum EnumCouress
        {


            id,
            id_NameOfCouress,
            Id_Information,
            NumberOfdayregest,
            Result,
            Delete
        }


   
        


    }
 
}
