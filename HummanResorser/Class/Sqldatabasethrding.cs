using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HummanResorser
{
    class Sqldatabasethrding
    {


        public static string NameDataBase = "HR_SARC";
   //    public static string sqlconction = "Data Source=SARC-1-HP\\M1992;Initial Catalog=HR_SARC;Integrated Security=True";
      //public static string sqlconction = "Data Source=192.168.43.220\\m1992;Initial Catalog=HR_SARC;Persist Security Info=True;User ID=sa;Password=123456789";
    // public static string sqlconction = "Data Source=192.168.137.1;Initial Catalog=HR_SARC;Persist Security Info=True;User ID=sa;Password=123456789";
        public static string sqlconction = "Data Source=DESKTOP-95D85KU;Initial Catalog=HR_SARC;Persist Security Info=True;User ID=sa;Password=123456789";
     //public static string sqlconction = "Data Source=Rama-PC;Initial Catalog=HR_SARC;Integrated Security=True";
        public static SqlConnection SqlConnection1 = new SqlConnection();

        public  static async  Task< bool> openConction()
        {
            
            try {
                if (Sqldatabasethrding.SqlConnection1.State != System.Data.ConnectionState.Open)
            {
                SqlConnection1.Close();
                SqlConnection1.ConnectionString = sqlconction;
               await  Sqldatabasethrding.SqlConnection1.OpenAsync();
                
                   
            }
            else
            {
                
            }
        }
            catch ( Exception e )
            {
                ErrorClass.SaveErrorFile(e);
                return false;
            }
            return true;
        }

        /// <summary>
        /// البحث في قاعدة البيانات عن طريق الأسم
        /// </summary>
        /// 
        public static async void WaitSqlsersh(string Stringa, Int64 Idnationl, string Idviter, DateTime DateTimerFrom, DateTime DateTimerTo, DevComponents.DotNetBar.Controls.ProgressBarX ProgressBarX1, DevComponents.DotNetBar.Controls.DataGridViewX DataGridViewX1)
        {
            await openConction();
            SqlCommand sqlcom1 = null;
        

       
                sqlcom1 = Vitl.Serch1(Stringa, DateTimerFrom, DateTimerTo);


            sqlcom1.Connection = SqlConnection1;
            IAsyncResult result = sqlcom1.BeginExecuteReader();

            SqlDataReader reader = sqlcom1.EndExecuteReader(result);
            DataGridViewX1.Rows.Clear();
         
        
           
         
            
            try
            {
              
                
                while (await reader.ReadAsync())
                {

                  
                    List<object> Tempobject = new List<object>();
                   


                    for (int i = 0; i < reader.FieldCount; i++)
                        Tempobject.Add(reader.GetValue(i));

                 
                        ClassDataGridViewDo.DataGridViewShow1Show(DataGridViewX1, Tempobject);
                    
                }


            }


            catch
            {

                MessageBox.Show("Error");
            }

            finally
            {
                reader.Close();


            }
        }

        public static async Task SaveNewAssing(Valuationname valuationname1)
        {
            SqlCommand Sqlcommand1 = valuationname1.adder();

            await openConction();

            try
            {
                //      IAsyncResult result = Sqlcommand1.BeginExecuteNonQuery();
                Sqlcommand1.Connection = Sqldatabasethrding.SqlConnection1;
                valuationname1.id=((int) await Sqlcommand1.ExecuteScalarAsync());
            }

            catch (Exception e)
            {
                ErrorClass.SaveErrorFile(e);
                MessageBox.Show(e.ToString());
            }

            finally
            {



            }
        }
        /// <summary>
        /// من أجل البحث المتقم
        /// </summary>
        /// <param name="Stringa">الأسم</param>
        /// <param name="SerchAdvaCoursClass">كلاس البحث المتقدم</param>
        /// <param name="idJop">مصفوفة المناصب</param>
        /// <param name="IdTeam">مصفوفة الفرق</param>
        /// <param name="ActivVitel">هل المتطوع فعال</param>
        /// <param name="InformationSelect"></param>
        /// <param name="SqlCmaand"></param>
        /// <param name="DataGridViewX1"></param>
        /// <param name="DateFrom"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        public static async Task WaitSqlsersh(string Stringa, SerchAdvaCoursClass SerchAdvaCoursClass, List<int> idJop, List<int> IdTeam, bool ActivVitel,string InformationSelect , SqlCommand SqlCmaand, DevComponents.DotNetBar.Controls.DataGridViewX DataGridViewX1 , DateTime DateFrom , DateTime DateEnd)
        {
            await openConction();
            SqlCommand sqlcom1 = null;

            sqlcom1 = Vitl.SerchRetIdInformation(Stringa, InformationSelect, SqlCmaand, DateFrom, DateEnd);

            sqlcom1.Connection = SqlConnection1;
            IAsyncResult result = sqlcom1.BeginExecuteReader();

            SqlDataReader reader = sqlcom1.EndExecuteReader(result);
            DataGridViewX1.Rows.Clear();

            List<IDinformationAdvSrchFullCoures> IDinformationAdvSrchListProsses = new List<IDinformationAdvSrchFullCoures>();

            try
            {

            int NumberDub = reader.FieldCount;

      
           while (await reader.ReadAsync())
           {
               IDinformationAdvSrchListProsses.Add(new IDinformationAdvSrchFullCoures(reader.GetInt32(0)));
           }

            }


            catch ( Exception e )
            {

                MessageBox.Show(e.ToString());
            }

            finally
            {
                reader.Close();


            }
            ///هاد من شان البحث هل المتطوع لديه هذا المنصب
            for (int i = 0; i < idJop.Count; i++)
            {
                for (int j = 0; j < IDinformationAdvSrchListProsses.Count; j++)
                     {
                         if (await Team.RetHaveVitelJop(IDinformationAdvSrchListProsses[j].idinformation, idJop[i]))
                         {
                             IDinformationAdvSrchListProsses[j].AddJop(idJop[i]);
                         }
                      }
            }
            // هاد من أجل البحث هل المتطوع لديه الدوره
            for (int i = 0; i < SerchAdvaCoursClass.idTypeofcorsSerch.Count; i++)
            {
                for (int j = 0; j < IDinformationAdvSrchListProsses.Count; j++)
                {
                    if (await Couress.GetIsItHaveCouresByIdInformation(IDinformationAdvSrchListProsses[j].idinformation, SerchAdvaCoursClass.idTypeofcorsSerch[i], true, !SerchAdvaCoursClass.idTypeofcorsSerchbool[i]))
                    {
                        IDinformationAdvSrchListProsses[j].AddCoures(SerchAdvaCoursClass.idTypeofcorsSerch[i]);
                    }
                }
            }
            //هل هذا المتطوع في الفريق
            for (int i = 0; i < IdTeam.Count; i++)
            {
                for (int j = 0; j < IDinformationAdvSrchListProsses.Count; j++)
                {
                    if (await Team.RetHaveVitelTeam(IDinformationAdvSrchListProsses[j].idinformation, IdTeam[i]))
                    {
                        IDinformationAdvSrchListProsses[j].AddTeam(IdTeam[i]);
                    }
                }
            }
            ///من أجل المتطوعين الفعالين
            if ( ActivVitel)
            {
                for (int j = 0; j < IDinformationAdvSrchListProsses.Count; j++)
                {
                    if (await Team.RetHaveVitelACtiv(IDinformationAdvSrchListProsses[j].idinformation))
                    {
                        IDinformationAdvSrchListProsses[j].SetAtciv();
                    }
                }

            }

    List<IDinformationAdvSrchFullCoures> IDView =    await    IDinformationAdvSrchFullCoures.GetHaveAll(SerchAdvaCoursClass.idTypeofcorsSerch, idJop, IdTeam, ActivVitel, IDinformationAdvSrchListProsses);
  List<List<object>> obj = new List<List<object>> ();

     obj=   await Sqldatabasethrding.GetSql(Vitl.Serhid(IDView));
        
    


            foreach (List<object> item in obj)
	            {
                int i = 0 ;
                DataGridViewX1.Rows.Add(item[i].ToString(), item[++i].ToString(), item[++i].ToString(), item[++i].ToString(), item[++i].ToString(), item[++i].ToString(), item[++i].ToString(), item[++i].ToString());
	            }
             

        }

     
  

        /// <summary>
        /// البحث في قاعدة البيانات عن طريق ID
        /// </summary>
        /// 
        
        public static async void WaitSqlDowork(int idname, DevComponents.DotNetBar.Controls.ProgressBarX ProgressBarX1, List<Vitl> VitlList)
        {
            SqlConnection SqlConnection1 = new SqlConnection();
            SqlConnection1.ConnectionString = sqlconction;
            await SqlConnection1.OpenAsync();
            ProgressBarX1.Value = 50;
            SqlCommand sqlcom1 = new SqlCommand("select id, first_name + Last_name AS Fullname , natiol_id  from Information_Ta", SqlConnection1);
        
            IAsyncResult result = sqlcom1.BeginExecuteReader();
            
            SqlDataReader reader = sqlcom1.EndExecuteReader (result);

            try
            {
                
                while (await reader.ReadAsync())
                {
                    int id = Convert.ToInt32(reader.GetValue(0));
                    string Fullname = Convert.ToString(reader.GetValue(1));
              
                     Int64 idnationl = ClassConvert.Convint64(reader.GetValue(2));

                    
                }
          
            }
            catch
            {

                MessageBox.Show("Error");
            }

            finally
            {
                reader.Close();
            }

        }

        /// <summary>
        /// من أجل إضافة الأسماء إلى Comboxex
        /// </summary>
        /// <param name="ComboBox1">إضافة</param>
        public static async Task<bool> GetNameForRibbonForm1Combox( List<int> intList)
        {
          await  openConction();
          System.Data.SqlClient.SqlCommand SqlCommand1 = new SqlCommand(); 
          SqlCommand1=   Vitl.GetAllName();
          SqlCommand1.Connection = Sqldatabasethrding.SqlConnection1;
          IAsyncResult result = SqlCommand1.BeginExecuteReader();
          SqlDataReader SqlDataReader1 = SqlCommand1.EndExecuteReader(result); 
          try
          {

              while (await SqlDataReader1.ReadAsync())
              {

                  RibbonForm1.Combox.Add(SqlDataReader1.GetValue(0).ToString());
                  intList.Add(SqlDataReader1.GetInt32(1));
              }

              
          }
            catch(Exception e )
          {

              System.Windows.Forms.MessageBox.Show(e.ToString());
          }

          finally { SqlDataReader1.Close();
          
          }
          return true;
        }
    
        /// <summary>
        /// 
        /// </summary>
        public static async Task<List<object> >  GetvitlByid(System.Data.SqlClient.SqlCommand SqlCommand1)
        {
            List<object> object1 = new List<object>(); 
            await openConction();
            SqlCommand1.Connection = Sqldatabasethrding.SqlConnection1;
            SqlDataReader SqlDataReader1 =  SqlCommand1.ExecuteReader();
            try
            {


                if ( SqlDataReader1.Read())

                        for (int i = 0; i < SqlDataReader1.FieldCount; i++)
                        {
                            object1.Add(SqlDataReader1.GetValue(i));
                        }
                    
                
            }
            catch(Exception e )
            {

                ErrorClass.SaveErrorFile(e);

            }
            finally
            {
                SqlDataReader1.Close();

            }
            return object1;

        }


        /// <summary>
        /// إرسال أمر SQl 
        /// وإرجعه على شكل مصفوفتين كائنات
        /// </summary>
        /// <param name="SqlCommand1">أمر SQL</param>
        /// <returns>ليست بداخل ليست Object</returns>
        public static async Task<List<List<object>>> GetSql(System.Data.SqlClient.SqlCommand SqlCommand1)
        {
            List<object> object1 = new List<object>();
            List<List<object>> object2 = new List<List<object>>();
            if (await openConction())
            {
                SqlCommand1.Connection = Sqldatabasethrding.SqlConnection1;
                
                SqlDataReader SqlDataReader1 = null;

                try
                {
                    SqlDataReader1 =SqlCommand1.ExecuteReader();


                    while (await SqlDataReader1.ReadAsync())
                    {

                        for (int i = 0; i < SqlDataReader1.FieldCount; i++)
                        {
                            object1.Add(SqlDataReader1.GetValue(i));
                        }
                        object2.Add(object1);
                        object1 = new List<object>();
                    }

                }
                catch (Exception e)
                {

                    ErrorClass.SaveErrorFile(e);

                }
                finally
                {
                    SqlDataReader1.Close();
                    SqlDataReader1.Dispose();
                }
                return object2;
            }
            else { return object2; }

        }

        public static async Task<bool> SaveOrUpdeataDataBase(SqlCommand Sqlcommand1)
        {

            await openConction();

            try
            {   
                Sqlcommand1.Connection = Sqldatabasethrding.SqlConnection1;
                Sqlcommand1.ExecuteNonQuery();}

            catch (Exception e)
            {
                ErrorClass.SaveErrorFile(e);
                return false;
             
            }

            finally
            {



            }

            return true;
        }
    
         public static async Task<bool> SqlSaveVitl (SqlCommand Sqlcommand1)
        {

            if (await openConction())
            {
                try
                {
                  
                    Sqlcommand1.Connection = Sqldatabasethrding.SqlConnection1;
                   await Sqlcommand1.ExecuteNonQueryAsync();
                    return true;
                }

                catch (Exception e)
                {
                    ErrorClass.SaveErrorFile(e);
                    MessageBox.Show(e.ToString());
                    return false;
                }
            }
            else
            {

                ErrorClass.SaveErrorFile(new Exception ("لا يوجد إتصال"));
                MessageBox.Show("لا يوجد إتصال");
                return false;
            }

        }
        


         public static async Task SqlupdataVitl(SqlCommand Sqlcommand1)
         {
             await openConction();

             try
             {
                 //      IAsyncResult result = Sqlcommand1.BeginExecuteNonQuery();
                 Sqlcommand1.Connection = Sqldatabasethrding.SqlConnection1;
                 Sqlcommand1.ExecuteNonQuery();
             }

             catch (Exception e)
             {
                 ErrorClass.SaveErrorFile(e);
                 MessageBox.Show(e.ToString());
           
             }

             finally
             {



             }

         }

         public static async void SqlSaveAdderAndBack(Vitl Vitl)
         {

             SqlCommand Sqlcommand1 = Vitl.adder();
             
             await openConction();

             try
             {
                 //      IAsyncResult result = Sqlcommand1.BeginExecuteNonQuery();
                 Sqlcommand1.Connection = Sqldatabasethrding.SqlConnection1;
                Vitl.ChanId ((int)  Sqlcommand1.ExecuteScalar());
             }

             catch (Exception e)
             {
                 ErrorClass.SaveErrorFile(e);
                 MessageBox.Show(e.ToString());
             }

             finally
             {



             }

         }
         public static async Task< int> SqlSaveAdderAndBack(SqlCommand Vitl)
         {

            

             await openConction();

             try
             {
                 //      IAsyncResult result = Sqlcommand1.BeginExecuteNonQuery();
                 Vitl.Connection = Sqldatabasethrding.SqlConnection1;
                 return ((int)Vitl.ExecuteScalar());
                 
             }

             catch (Exception e)
             {
                 ErrorClass.SaveErrorFile(e);
                 MessageBox.Show(e.ToString());
             }

             finally
             {



             }
             return 0;

         }

         public async static Task SqlAddOrUpdateOrDelet(List<DataBase> ListIaddName, List<int> IndexAdder, List<int> IndexUp, List<int> IndexDelet)
         {

             DeletDplcat(IndexAdder);

             DeletDplcat(IndexUp);
             DeletDplcat(IndexDelet);
             foreach (int Index in IndexAdder )
             {
                 
            await     SqlSaveVitl (ListIaddName[Index].adder());
             }
             foreach (int Index in IndexUp)
             {

                 await SqlSaveVitl(ListIaddName[Index].updata());
             }
             foreach (int Index in IndexDelet)
             {

                 await SqlSaveVitl(ListIaddName[Index].Delete());
             }
             IndexUp.Clear();
             IndexAdder.Clear();
             IndexDelet.Clear();

         }

        
      public  static void DeletDplcat(List<int> Delt)
        {
           

            for (int i =0 ; i <Delt.Count ;  i++)
            {
                for (int J = i+1; J < Delt.Count; J++)
                    if (Delt[i] == Delt[J])
                        Delt.RemoveAt(J);
            }


        }


       public enum DataBaseTabName
       {
           Acess_ta ,
           Couress_ta,
           EngerseMissin_ta,
           EngerseMissinNAme_ta,
           EngerseMissinType_ta,
           Information_Ta,
           Jop_Ta,
           NameOfCouress_ta,
           NameTeam_Ta,
           NameTeamType_Ta,
           systemPermtion_ta,
           Team_ta,
           TypeofCouress_ta,
           typeOfOrder,
           typeOfOrder_ta,
           Valuation_ta,
           Valuationname_Ta,
           WereDelivery_ta,
           WereType_ta


       }


    }
}
