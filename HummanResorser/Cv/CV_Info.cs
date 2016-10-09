using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HummanResorser
{
    public class CV_Info : DataBase
    {    
     public CV_Info(int id )
        {
        // 
            System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand("SELECT  [id]  ,[FullName] ,[Notes]  ,[NmuberOfArchev]  ,[Id_Study] ,[Year_sutr],[Numberphone]  ,[Date],[ID_TemaNeed] ,[Bit]   ,[ToOutTeam]  ,[ToOutDate]  ,[Notesout] FROM [HR_SARC].[dbo].[CV_Info] where [Delete] =0 and  id = @id");
            SqlCommand.Parameters.AddWithValue("id", id);
            List<List<object>> Adw =  (Sqldatabasethrding.GetSql(SqlCommand)).Result;

            if (Adw[0].Count != 0)
            {
                this.id = Convert.ToInt32(Adw[0][0]);
                this.FullName = Convert.ToString(Adw[0][1]);
                this.Notes = Convert.ToString(Adw[0][2]);
                this.NmuberOfArchev = Convert.ToInt32(Adw[0][3]);
                this.Id_Study = Convert.ToInt32(Adw[0][4]);
                this.Year_sutr = Convert.ToInt32(Adw[0][5]);
                this.Numberphone = Convert.ToInt32(Adw[0][6]);
                this.Date = ClassConvert.ConvDateTimeNull (Adw[0][7]);
                this.ID_TemaNeed = Convert.ToInt32(Adw[0][8]);
                this.Bit = Convert.ToBoolean(Adw[0][9]);
                this.ToOutTeam = ClassConvert.Convint(Adw[0][10]);
                this.ToOutDate = ClassConvert.ConvDateTimeNull(Adw[0][11]);
                this.Notesout = Convert.ToString(Adw[0][12]);
                        
            }

     }

     public CV_Info(int id, string FullName, string Notes, int NmuberOfArchev, int Id_Study, int Year_sutr, int Numberphone, DateTime? Date, int ID_TemaNeed, bool Bit, int ToOutTeam, DateTime? ToOutDate, string Notesout)
      {
         // ( id,  FullName,  Notes,  NmuberOfArchev,  Id_Study,  Year_sutr,  Numberphone,  Date,  ID_TemaNeed,  Bit)
          this.id = id;
          this.FullName = FullName;
          this.Notes = Notes;
          this.NmuberOfArchev = NmuberOfArchev;
          this.Id_Study = Id_Study;
          this.Year_sutr = Year_sutr;
          this.Numberphone = Numberphone;
          this.Date = Date;
          this.ID_TemaNeed = ID_TemaNeed;
          this.Bit = Bit;

          this.ToOutTeam = ToOutTeam;
          this.ToOutDate = ToOutDate;
          this.Notesout = Notesout;

        }
      public int id
      {
          get;
          private set;

      }

      public static async System.Threading.Tasks.Task<int> Serch(string ByIdArchev)
      {
    
          ByIdArchev = ClassDataGridViewDo.Trimall(ByIdArchev);


          System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("");


          Sqlcom.CommandText = "SELECT [HR_SARC]. dbo.CV_Info.id , [HR_SARC].dbo.CV_Info.NmuberOfArchev , [HR_SARC]. dbo.CV_Study.Sampl FROM   [HR_SARC].dbo.CV_Info INNER JOIN  [HR_SARC].dbo.CV_Study on [HR_SARC].[dbo].CV_Info.Id_Study =  [HR_SARC].[dbo].CV_Study.id WHERE [HR_SARC].dbo.CV_Study.Sampl + CAST( [HR_SARC].dbo.CV_Info.NmuberOfArchev as nvarchar) like @ByIdArchev ";



          Sqlcom.Parameters.AddWithValue("@ByIdArchev", ByIdArchev);
          List<CV_Info> Ve = new List<CV_Info>();

          List<List<object>> Ob = await Sqldatabasethrding.GetSql(Sqlcom);

          for (int i = 0; i < Ob.Count; i++)
              if (Ob[i].Count != 0)
              {
                  try
                  {

                      return Convert.ToInt32(Ob[i][0]);

                  }
                  catch (Exception e)
                  {
                      ErrorClass.SaveErrorFile(e);

                  }
              }

          return -1;

      }
      public static async System.Threading.Tasks.Task<List<CV_Info>> Serch(string Fullname, string Notes, int Id_Study, int Year_sutr, int ID_TemaNeed, bool Chek, int NumberPhone, string CodeForCV, int SelectTeamOut, string NotesOut)
      {
          String Where = "";
          List<CV_Info> Ve = new List<CV_Info>();
          Fullname = ClassDataGridViewDo.LograthemChangEverAleffToAll(Fullname, true);




          System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("SELECT  [id]  ,[FullName] ,[Notes]  ,[NmuberOfArchev]  ,[Id_Study] ,[Year_sutr],[Numberphone]  ,[Date],[ID_TemaNeed] ,[Bit] ,[ToOutTeam] , [ToOutDate] , [Notesout],[Delete]  FROM [HR_SARC].[dbo].[CV_Info] where [Delete] =0 and [FullName] = @FullName  " + Where);
          if (Notes.Trim() != "")
          {
              Where += " and [Notes] like @Notes";
              Sqlcom.Parameters.AddWithValue("@Notes", "%" + ClassDataGridViewDo.LograthemChangEverAleffToAll(Notes) + "%");

          }

          if (Id_Study != -1)
          {
              Where += " and [Id_Study] = @Id_Study";
              Sqlcom.Parameters.AddWithValue("Id_Study", Id_Study);

          }
          if (Year_sutr != -1)
          {
              Where += " and [Year_sutr] = @Year_sutr";
              Sqlcom.Parameters.AddWithValue("Year_sutr", Year_sutr);

          }
          if (ID_TemaNeed != -1)
          {
              Where += " and [ID_TemaNeed] = @ID_TemaNeed";
              Sqlcom.Parameters.AddWithValue("ID_TemaNeed", ID_TemaNeed);

          }
          if (Chek)
          {
              Where += " and [Bit] = @Bit";
              Sqlcom.Parameters.AddWithValue("Bit", !Chek);
          }
          if (NumberPhone != 0)
          {
              Where += " and [Numberphone] = @Numberphone";
              Sqlcom.Parameters.AddWithValue("Numberphone", NumberPhone);
          }
          if (SelectTeamOut != -1)
          {
              Where += " and [ToOutTeam] = @ToOutTeam";
              Sqlcom.Parameters.AddWithValue("ToOutTeam", SelectTeamOut);
          }
          if (NotesOut.Trim() != "")
          {
              Where += " and [Notesout] like @Notesout";
              Sqlcom.Parameters.AddWithValue("Notesout", "%" + ClassDataGridViewDo.LograthemChangEverAleffToAll(NotesOut,true) + "%");
          }


          Sqlcom.CommandText = "SELECT  [id]  ,[FullName] ,[Notes]  ,[NmuberOfArchev]  ,[Id_Study] ,[Year_sutr],[Numberphone]  ,[Date],[ID_TemaNeed] ,[Bit] ,[ToOutTeam] , [ToOutDate] , [Notesout],[Delete]  FROM [HR_SARC].[dbo].[CV_Info] where [Delete] =0 and [FullName] like @FullName  " + Where;
          Sqlcom.Parameters.AddWithValue("@FullName", "%" + Fullname + "%");

          if ( CodeForCV != "")
          {
          
                  Sqlcom.CommandText = "SELECT  [id]  ,[FullName] ,[Notes]  ,[NmuberOfArchev]  ,[Id_Study] ,[Year_sutr],[Numberphone]  ,[Date],[ID_TemaNeed] ,[Bit] ,[ToOutTeam] , [ToOutDate] , [Notesout],[Delete]  FROM [HR_SARC].[dbo].[CV_Info] where [Delete] =0 and [id] = @id  ";
                  Sqlcom.Parameters.AddWithValue("id", await CV_Info.Serch(CodeForCV));

          }
         

          List<List<object>> Ob = await Sqldatabasethrding.GetSql(Sqlcom);

          for (int i = 0; i < Ob.Count; i++)
              if (Ob[i].Count != 0)
              {
                  try
                  {

                      Ve.Add(new CV_Info(
                       Convert.ToInt32(Ob[i][0]),
                       Convert.ToString(Ob[i][1]),
                       Convert.ToString(Ob[i][2]),
                      Convert.ToInt32(Ob[i][3]),
                       Convert.ToInt32(Ob[i][4]),
                       Convert.ToInt32(Ob[i][5]),
                     Convert.ToInt32(Ob[i][6]),
                     ClassConvert.ConvDateTimeNull(Ob[i][7]),
                     Convert.ToInt32(Ob[i][8]),
                       Convert.ToBoolean(Ob[i][9]),
                        -1,
                       null,
                      null
                     ));

                  }
                  catch (Exception e)
                  {
                      ErrorClass.SaveErrorFile(e);

                  }
              }

          return Ve;

      }
       public static async System.Threading.Tasks.Task< List<CV_Info>> Serch(string Fullname, string Notes , int Id_Study , int Year_sutr ,int ID_TemaNeed  , bool Chek , int NumberPhone )
        {
            String Where = "";
            Fullname = ClassDataGridViewDo.LograthemChangEverAleffToAll(Fullname, true);




            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("SELECT  [id]  ,[FullName] ,[Notes]  ,[NmuberOfArchev]  ,[Id_Study] ,[Year_sutr],[Numberphone]  ,[Date],[ID_TemaNeed] ,[Bit] ,[ToOutTeam] , [ToOutDate] , [Notesout],[Delete]  FROM [HR_SARC].[dbo].[CV_Info] where [Delete] =0 and [FullName] = @FullName  " + Where);
            if (Notes.Trim() != "")
            {
                Where += " and [Notes] like @Notes";
                Sqlcom.Parameters.AddWithValue("@Notes", "%" + ClassDataGridViewDo.LograthemChangEverAleffToAll(Notes) + "%");   

            }

            if (Id_Study!=-1)
            {
                Where += " and [Id_Study] = @Id_Study";
                Sqlcom.Parameters.AddWithValue("Id_Study", Id_Study);



            }
            if (Year_sutr != -1)
            {
                Where += " and [Year_sutr] = @Year_sutr";
                Sqlcom.Parameters.AddWithValue("Year_sutr", Year_sutr);



            }
            if (ID_TemaNeed != -1)
            {
                Where += " and [ID_TemaNeed] = @ID_TemaNeed";
                Sqlcom.Parameters.AddWithValue("ID_TemaNeed", ID_TemaNeed);



            }
            if (Chek)
            {
                Where += " and [Bit] = @Bit";
                Sqlcom.Parameters.AddWithValue("Bit", !Chek);



            }
            if (NumberPhone !=0)
            {
                Where += " and [Numberphone] = @Numberphone";
                Sqlcom.Parameters.AddWithValue("Numberphone", NumberPhone);



            }

            Sqlcom.CommandText = "SELECT  [id]  ,[FullName] ,[Notes]  ,[NmuberOfArchev]  ,[Id_Study] ,[Year_sutr],[Numberphone]  ,[Date],[ID_TemaNeed] ,[Bit] ,[ToOutTeam] , [ToOutDate] , [Notesout],[Delete]  FROM [HR_SARC].[dbo].[CV_Info] where [Delete] =0 and [FullName] like @FullName  " + Where;

          

            Sqlcom.Parameters.AddWithValue("@FullName", "%" + Fullname + "%");
            List<CV_Info> Ve = new List<CV_Info>();

       List<List<object>> Ob =   await Sqldatabasethrding.GetSql(Sqlcom);

       for (int i = 0; i < Ob.Count; i++)
           if (Ob[i].Count != 0)
           {
               try
               {
                  
                   Ve.Add(new CV_Info(
                    Convert.ToInt32(Ob[i][0]),
                    Convert.ToString(Ob[i][1]),
                    Convert.ToString(Ob[i][2]),
                   Convert.ToInt32(Ob[i][3]),
                    Convert.ToInt32(Ob[i][4]),
                    Convert.ToInt32(Ob[i][5]),
                  Convert.ToInt32(Ob[i][6]),
                  ClassConvert.ConvDateTimeNull(Ob[i][7]),
                  Convert.ToInt32(Ob[i][8]),
                    Convert.ToBoolean(Ob[i][9]) ,
                     -1,
                    null,
                   null
                  ));
                
               }
               catch ( Exception e )
               {
                   ErrorClass.SaveErrorFile(e);

               }
           }

       return Ve;

        }

        /// <summary>
        /// الأسم كامل
        /// </summary>
        public string FullName
        {
            get;
            private set;
        }

        /// <summary>
        /// ملا حظات
        /// </summary>
        public string Notes
        {
            get;
            private set;

        }

        /// <summary>
        /// رقم الأرشفه
        /// </summary>
        public int NmuberOfArchev
        {
            get;
            private set;
        }

        /// <summary>
        /// الدراسة
        /// </summary>
        public int Id_Study
        {
            get;
            private set;
        }

        /// <summary>
        /// أي سنه دراسة
        /// </summary>
        public int Year_sutr
        {
            get;
            private set;
        }

        /// <summary>
        /// رقم الهاتف
        /// </summary>
        public int Numberphone
        {
            get;
            private set;
        }

        /// <summary>
        /// تم مقابلة
        /// </summary>
        public bool Bit
        {
            get;
            private set;
        }

        /// <summary>
        /// تاريخ التقديم
        /// </summary>
        public DateTime? Date
        {
            get;
            private set;
        }

        /// <summary>
        /// الفريق المطلوب
        /// </summary>
        public int ID_TemaNeed
        {
            get;
            private set;
        }

        public int ToOutTeam { get; private set; }
        public DateTime? ToOutDate { get; private set; }
        public string Notesout { get; private set; }

        public System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[CV_Info] SET [FullName] = @FullName  ,[Notes] = @Notes ,[NmuberOfArchev] =@NmuberOfArchev,[Id_Study] = @Id_Study,[Year_sutr] = @Year_sutr ,[Numberphone] =@Numberphone,[Date] = @Date,[ID_TemaNeed] = @ID_TemaNeed,[Bit] = @Bit , [ToOutTeam] =@ToOutTeam  , [ToOutDate] =@ToOutDate , Notesout = @Notesout WHERE id = @id");
            Sqlcom.Parameters.AddWithValue("FullName", this.FullName);
            Sqlcom.Parameters.AddWithValue("Notes", this.Notes);
            Sqlcom.Parameters.AddWithValue("NmuberOfArchev", this.NmuberOfArchev);
            Sqlcom.Parameters.AddWithValue("Id_Study", this.Id_Study);
            Sqlcom.Parameters.AddWithValue("Year_sutr", this.Year_sutr);
            Sqlcom.Parameters.AddWithValue("Numberphone", this.Numberphone);

            if (this.ToOutTeam !=null)
            Sqlcom.Parameters.AddWithValue("ToOutTeam", this.ToOutTeam);
            else
                Sqlcom.Parameters.AddWithValue("ToOutTeam", DBNull.Value);

            if (this.ToOutDate != null)
            Sqlcom.Parameters.AddWithValue("ToOutDate", this.ToOutDate);
            else
                Sqlcom.Parameters.AddWithValue("ToOutDate", DBNull.Value);

            if (this.Notesout != null)
            Sqlcom.Parameters.AddWithValue("Notesout", this.Notesout);
     

            if (this.Date != null)
                Sqlcom.Parameters.AddWithValue("Date", this.Date);
            else
                Sqlcom.Parameters.AddWithValue("Date", DBNull.Value);

            Sqlcom.Parameters.AddWithValue("ID_TemaNeed", this.ID_TemaNeed);
            Sqlcom.Parameters.AddWithValue("Bit", this.Bit);
            Sqlcom.Parameters.AddWithValue("id", this.id);
            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[CV_Info]([FullName] ,[Notes]    ,[NmuberOfArchev]    ,[Id_Study]  ,[Year_sutr] ,[Numberphone]  ,[Date]    ,[ID_TemaNeed]  ,[Bit] ,[Delete] ,[ToOutTeam], [ToOutDate] , [Notesout])output INSERTED.ID VALUES(@FullName ,@Notes,@NmuberOfArchev  , @Id_Study , @Year_sutr  , @Numberphone , @Date , @ID_TemaNeed , @Bit , @Delete , @ToOutTeam , @ToOutDate , @Notesout)");
            Sqlcom.Parameters.AddWithValue("FullName", this.FullName);
            Sqlcom.Parameters.AddWithValue("Notes", this.Notes);
            Sqlcom.Parameters.AddWithValue("NmuberOfArchev", this.NmuberOfArchev);
            Sqlcom.Parameters.AddWithValue("Id_Study", this.Id_Study);
            Sqlcom.Parameters.AddWithValue("Year_sutr", this.Year_sutr);
            Sqlcom.Parameters.AddWithValue("Numberphone", this.Numberphone);
            if (this.Date != null)

            Sqlcom.Parameters.AddWithValue("Date", this.Date);
            else
                Sqlcom.Parameters.AddWithValue("Date", DBNull.Value);

            Sqlcom.Parameters.AddWithValue("ID_TemaNeed", this.ID_TemaNeed);
            Sqlcom.Parameters.AddWithValue("Bit", this.Bit);
            Sqlcom.Parameters.AddWithValue("Delete", false);




            if (this.ToOutTeam != null)
                Sqlcom.Parameters.AddWithValue("ToOutTeam", this.ToOutTeam);
            else
                Sqlcom.Parameters.AddWithValue("ToOutTeam", DBNull.Value);

            if (this.ToOutDate != null)
                Sqlcom.Parameters.AddWithValue("ToOutDate", this.ToOutDate);
            else
                Sqlcom.Parameters.AddWithValue("ToOutDate", DBNull.Value);

        
                Sqlcom.Parameters.AddWithValue("Notesout", this.Notesout);


            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[CV_Info] SET [Delete] =@delete WHERE id = @id");
            Sqlcom.Parameters.AddWithValue("id", this.id);
            Sqlcom.Parameters.AddWithValue("delete", true);
            return Sqlcom;
        }

        public string GetCodeArch()
        {
            if (this.Id_Study != -1)
                return CV_Study.CV_StudyList[ClassDataGridViewDo.RetunIndexByIdSech(this.Id_Study, CV_Study.CV_StudyList)].Sampl + this.NmuberOfArchev.ToString();
            else
                return "غير مسجل";
        }
   
        public async System.Threading.Tasks.Task UpdateForGetTheCV(int ToOutTeam, DateTime? ToOutDate, string Notesout)
        {
            this.ToOutTeam = ToOutTeam;

            if (ToOutDate ==DateTime.MinValue)
            this.ToOutDate = null;
            else
                this.ToOutDate = ToOutDate;

            this.Notesout = Notesout;

            await Sqldatabasethrding.SqlSaveVitl(this.updata());

        }
    }
}
