using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlTypes;
using System.Data;
using System.Data.SqlClient;

namespace HummanResorser
{
    /// <summary>
    /// المتطوعين Main
    /// </summary>
    /// <remarks>تعديل و الإضافة و الحذف</remarks>
    public class Vitl : DataGet
    {


        static public List<String> Bransh = new List<string>();
        static public List<string> viteDataBase = new List<string>();
        static public List<string> NameArabic = new List<string>();
        static public List<Action> OutputM = new List<Action>();

        static public SqlCommand RetunForNameByIdForIdAndName(int id)
        {
            System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand("SELECT [id],[first_name],[Last_name] ,[data_regs] FROM [Information_Ta] where [id] = @id And [Delete] = 0 ");
            SqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));
            return SqlCommand;
        }
        public static IdAndName VitlIdAndName(int id)
        {
            

            Task<List<object>> V1x = (Sqldatabasethrding.GetvitlByid(RetunForNameByIdForIdAndName(id)));
            List<object> V1 = new List<object>();
            V1x.Wait();
            V1 = V1x.Result;
         if ( V1.Count==0)
             return new IdAndName(true);
            else

             return new IdAndName(Convert.ToInt32(V1[0]), V1[1].ToString() + " " + V1[2].ToString(),Convert.ToDateTime( V1[3]));

        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetUpNameDataBase()
        {
            Vitl.viteDataBase.Add("id");
            Vitl.viteDataBase.Add("first_name");
            Vitl.viteDataBase.Add("Last_name");
            Vitl.viteDataBase.Add("Father_name");
            Vitl.viteDataBase.Add("Mather_name");
            Vitl.viteDataBase.Add("natiol_id");
            Vitl.viteDataBase.Add("Gender");
            Vitl.viteDataBase.Add("where_birth");
            Vitl.viteDataBase.Add("data_barthday");
            Vitl.viteDataBase.Add("Hanei_whare");
            Vitl.viteDataBase.Add("Hanei_whare1");
            Vitl.viteDataBase.Add("adderas");
            Vitl.viteDataBase.Add("e_mail");
            Vitl.viteDataBase.Add("Stutes_Jtma3");
            Vitl.viteDataBase.Add("Phone_Ground");
            Vitl.viteDataBase.Add("Phone_Mobile1");
            Vitl.viteDataBase.Add("Phone_Mobile2");
            Vitl.viteDataBase.Add("Facebook");
            Vitl.viteDataBase.Add("Twiter");
            Vitl.viteDataBase.Add("whatsApp");
            Vitl.viteDataBase.Add("viper");
            Vitl.viteDataBase.Add("study");
            Vitl.viteDataBase.Add("yearstudy");
            Vitl.viteDataBase.Add("Id_course");
            Vitl.viteDataBase.Add("Id_course_Ware");
            Vitl.viteDataBase.Add("data_regs");
            Vitl.viteDataBase.Add("Image_id_nationl1");
            Vitl.viteDataBase.Add("Image_id_nationl2");
            Vitl.viteDataBase.Add("image");
            Vitl.viteDataBase.Add("Image_font");
            Vitl.viteDataBase.Add("Boold_id");
            Vitl.viteDataBase.Add("Nkname");
            Vitl.viteDataBase.Add("nameEnglish");
            Vitl.viteDataBase.Add("Z1");
            Vitl.viteDataBase.Add("z2");
            Vitl.viteDataBase.Add("z3");
            Vitl.viteDataBase.Add("XmlHobbies");
            Vitl.viteDataBase.Add("Delete");

        }
        public Vitl ()
        {

        }

        public async Task MakeAsn(int id)
        {

            System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand();
            SqlCommand = this.GetFromIdAsnc(id);

     List<object> V1 = await Sqldatabasethrding.GetvitlByid(SqlCommand);

            int i = 1;
            this.id = id;
            this.first_name = ClassConvert.ConvString(V1[i]);
            this.Last_name = ClassConvert.ConvString(V1[++i]);
            this.Father_name = ClassConvert.ConvString(V1[++i]);
            this.Mather_name = ClassConvert.ConvString(V1[++i]);
            this.natiol_id = ClassConvert.Convint64(V1[++i]);
            this.Gender = ClassConvert.ConvBoolnull(V1[++i]);
            this.where_birth = ClassConvert.ConvString(V1[++i]);
            this.data_barthday = ClassConvert.ConvDateTime(V1[++i]);
            this.Hanei_whare = ClassConvert.ConvString(V1[++i]);
            this.Hanei_whare1 = ClassConvert.ConvString(V1[++i]);
            this.adderas = ClassConvert.ConvString(V1[++i]);
            this.e_mail = ClassConvert.ConvString(V1[++i]);
            this.Stutes_Jtma3 = ClassConvert.Convint(V1[++i]);
            this.Phone_Ground = ClassConvert.Convint(V1[++i]);
            this.Phone_Mobile1 = ClassConvert.Convint(V1[++i]);
            this.Phone_Mobile2 = ClassConvert.Convint(V1[++i]);
            this.Facebook = ClassConvert.ConvString(V1[++i]);
            this.Twiter = ClassConvert.ConvString(V1[++i]);
            this.whatsApp = ClassConvert.Convint(V1[++i]);
            this.viper = ClassConvert.Convint(V1[++i]);
            this.study = ClassConvert.ConvString(V1[++i]);
            this.yearstudy = ClassConvert.Convint(V1[++i]);
            this.Id_course = ClassConvert.Convint(V1[++i]);
            this.Id_course_Ware = ClassConvert.ConvString(V1[++i]);
            this.data_regs = ClassConvert.ConvDateTime(V1[++i]);

            this.Boold_id = ClassConvert.Convint(V1[++i]);
            this.Nkname = ClassConvert.ConvString(V1[++i]);
            this.nameEnglish = ClassConvert.ConvString(V1[++i]);
            this.Z1 = ClassConvert.Convint(V1[++i]);
            this.z2 = ClassConvert.Convint(V1[++i]);
            this.z3 = ClassConvert.Convint(V1[++i]);
            this.XmlHobbies = ClassConvert.ConvXml(V1[++i]);

        }
        public  void Dispose()
        {
            if (image != null)
            {
                image.Dispose();
            }

            if (Image_id_nationl1 != null)
            {
                Image_id_nationl1.Dispose();
            }
          if (   Image_id_nationl2 != null )
            {
                Image_id_nationl2.Dispose();
            }
        }
        public Vitl(int id, string first_name, string Last_name, string Father_name, string Mather_name, long natiol_id, bool? Gender, string where_birth, DateTime data_barthday, string Hanei_whare, string Hanei_whare1, string adderas, string e_mail, int Stutes_Jtma3, int Phone_Ground, int Phone_Mobile1, int Phone_Mobile2, string Facebook, string Twiter, int whatsApp, int viper, string study, int yearstudy, int Id_course, string Id_course_Ware, DateTime data_regs, Image Image_id_nationl1, Image Image_id_nationl2, Image image, Image Image_font, int Boold_id, string Nkname, string nameEnglish, int Z1, int z2, int z3, System.Xml.XmlDataDocument XmlHobbies)
        {

            this.id = id;
            this.first_name = first_name;
            this.Last_name = Last_name;
            this.Father_name = Father_name;
            this.Mather_name = Mather_name;
            this.natiol_id = natiol_id;
            this.Gender = Gender;
            this.where_birth = where_birth;
            this.data_barthday = data_barthday;
            this.Hanei_whare = Hanei_whare;
            this.Hanei_whare1 = Hanei_whare1;
            this.adderas = adderas;
            this.e_mail = e_mail;
            this.Stutes_Jtma3 = Stutes_Jtma3;
            this.Phone_Ground = Phone_Ground;
            this.Phone_Mobile1 = Phone_Mobile1;
            this.Phone_Mobile2 = Phone_Mobile2;
            this.Facebook = Facebook;
            this.Twiter = Twiter;
            this.whatsApp = whatsApp;
            this.viper = viper;
            this.study = study;
            this.yearstudy = yearstudy;
            this.Id_course = Id_course;
            this.Id_course_Ware = Id_course_Ware;
            this.data_regs = data_regs;
            this.Image_id_nationl1 = Image_id_nationl1;
            this.Image_id_nationl2 = Image_id_nationl2;
            this.image = image;
            this.Image_font = Image_font;
            this.Boold_id = Boold_id;
            this.Nkname = Nkname;
            this.nameEnglish = nameEnglish;
            this.Z1 = Z1;
            this.z2 = z2;
            this.z3 = z3;
            this.XmlHobbies = XmlHobbies;
        }

        /// <summary>
        /// بحث , إضافة من ID
        /// </summary>
        /// <param name="id"> بحث عن طريق ID</param>
        public  Vitl(int id)
        {

            System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand();
            SqlCommand = this.GetFromId(id);

            Task<List<object>> V1x = (Sqldatabasethrding.GetvitlByid(SqlCommand));
            List<object> V1 = new List<object>();
            V1x.Wait();
            V1 = V1x.Result;
            int i = 1;
            this.id = id;
            this.first_name = ClassConvert.ConvString(V1[i]);
            this.Last_name = ClassConvert.ConvString(V1[++i]);
            this.Father_name = ClassConvert.ConvString(V1[++i]);
            this.Mather_name = ClassConvert.ConvString(V1[++i]);
            this.natiol_id = ClassConvert.Convint64(V1[++i]);
            this.Gender = ClassConvert.ConvBoolnull(V1[++i]);
            this.where_birth = ClassConvert.ConvString(V1[++i]);
            this.data_barthday = ClassConvert.ConvDateTime(V1[++i]);
            this.Hanei_whare = ClassConvert.ConvString(V1[++i]);
            this.Hanei_whare1 = ClassConvert.ConvString(V1[++i]);
            this.adderas = ClassConvert.ConvString(V1[++i]);
            this.e_mail = ClassConvert.ConvString(V1[++i]);
            this.Stutes_Jtma3 = ClassConvert.Convint(V1[++i]);
            this.Phone_Ground = ClassConvert.Convint(V1[++i]);
            this.Phone_Mobile1 = ClassConvert.Convint(V1[++i]);
            this.Phone_Mobile2 = ClassConvert.Convint(V1[++i]);
            this.Facebook = ClassConvert.ConvString(V1[++i]);
            this.Twiter = ClassConvert.ConvString(V1[++i]);
            this.whatsApp = ClassConvert.Convint(V1[++i]);
            this.viper = ClassConvert.Convint(V1[++i]);
            this.study = ClassConvert.ConvString(V1[++i]);
            this.yearstudy = ClassConvert.Convint(V1[++i]);
            this.Id_course = ClassConvert.Convint(V1[++i]);
            this.Id_course_Ware = ClassConvert.ConvString(V1[++i]);
            this.data_regs = ClassConvert.ConvDateTime(V1[++i]);
            this.Image_id_nationl1 = ClassConvert.ConvImage(V1[++i]);
            this.Image_id_nationl2 = ClassConvert.ConvImage(V1[++i]);
            this.image = ClassConvert.ConvImage(V1[++i]);
            this.Image_font = ClassConvert.ConvImage(V1[++i]);
            this.Boold_id = ClassConvert.Convint(V1[++i]);
            this.Nkname = ClassConvert.ConvString(V1[++i]);
            this.nameEnglish = ClassConvert.ConvString(V1[++i]);
            this.Z1 = ClassConvert.Convint(V1[++i]);
            this.z2 = ClassConvert.Convint(V1[++i]);
            this.z3 = ClassConvert.Convint(V1[++i]);
            this.XmlHobbies = ClassConvert.ConvXml(V1[++i]);

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
        /// الأسم الأول
        /// </summary>
        public string first_name
        {
            get;
            private set;
        }

        /// <summary>
        /// الشهرة
        /// </summary>
        public string Last_name
        {
            get;
            private set;
        }

        /// <summary>
        /// أسم الأب
        /// </summary>
        public string Father_name
        {
            get;
            private set;
        }

        /// <summary>
        /// أسم الأم
        /// </summary>
        public string Mather_name
        {
            get;
            private set;
        }

        /// <summary>
        /// رقم الهوية
        /// </summary>
        public Int64 natiol_id
        {
            get;
             set;
        }

        /// <summary>
        /// الجنس
        /// </summary>
        public bool? Gender
        {
            get;
            private set;
        }

        /// <summary>
        /// محل الولادة
        /// </summary>
        public string where_birth
        {
            get;
            private set;
        }

        /// <summary>
        /// تاريخ الولادة
        /// </summary>
        public DateTime data_barthday
        {
            get;
            private set;
        }

        /// <summary>
        /// الامانة
        /// </summary>
        public string Hanei_whare
        {
            get;
            private set;
        }

        /// <summary>
        /// القيد
        /// </summary>
        public string Hanei_whare1
        {
            get;
            private set;
        }

        /// <summary>
        /// العنوان
        /// </summary>
        public string adderas
        {
            get;
            private set;
        }

        /// <summary>
        /// البريد الألكتروني
        /// </summary>
        public string e_mail
        {
            get;
            private set;
        }

        /// <summary>
        /// الحالة الاجتماعية
        /// </summary>
        public int Stutes_Jtma3
        {
            get;
            private set;
        }

        /// <summary>
        /// رقم هاتف أرضي
        /// </summary>
        public int Phone_Ground
        {
            get;
            private set;
        }

        /// <summary>
        /// رقم هاتف موبايل 1
        /// </summary>
        public int Phone_Mobile1
        {
            get;
            private set;
        }

        /// <summary>
        /// رقم هاتف موبايل 2
        /// </summary>
        public int Phone_Mobile2
        {
            get;
            private set;
        }

        /// <summary>
        /// Facebook
        /// </summary>
        public string Facebook
        {
            get;
            private set;
        }

        /// <summary>
        /// Twiter
        /// </summary>
        public string Twiter
        {
            get;
            private set;
        }

        /// <summary>
        /// whatsApp
        /// </summary>
        public int whatsApp
        {
            get;
            private set;
        }

        /// <summary>
        /// viper
        /// </summary>
        public int viper
        {
            get;
            private set;
        }

        /// <summary>
        /// الدراسة
        /// </summary>
        public string study
        {
            get;
            private set;
        }

        /// <summary>
        /// السنه الدراسة
        /// </summary>
        public int yearstudy
        {
            get;
            private set;
        }

        /// <summary>
        /// ID_Course
        /// </summary>
        public int Id_course
        {
            get;
            private set;
        }

        /// <summary>
        /// الفرع
        /// </summary>
        public string Id_course_Ware
        {
            get;
            private set;
        }

        /// <summary>
        /// تاريخ التسجيل في هلال
        /// </summary>
        public DateTime data_regs
        {
            get;
            private set;
        }

        /// <summary>
        /// صورة عن هاوية الأول
        /// </summary>
        public Image Image_id_nationl1
        {
            get;
            private set;
        }

        /// <summary>
        /// صورة عن هاوية الثاني
        /// </summary>
        public Image Image_id_nationl2
        {
            get;
            private set;
        }

        /// <summary>
        /// صورة المتطوع
        /// </summary>
        public Image image
        {
            get;
            private set;
        }

        /// <summary>
        /// صورة أمامية ID متطوع
        /// </summary>
        public Image Image_font
        {
            get;
            private set;
        }

        /// <summary>
        /// زمرة الدم
        /// </summary>
        public int Boold_id
        {
            get;
            private set;
        }

        /// <summary>
        /// الأسم المستعار
        /// </summary>
        public string Nkname
        {
            get;
            private set;
        }

        /// <summary>
        /// الأسم بالإنكليزي
        /// </summary>
        public string nameEnglish
        {
            get;
            private set;
        }

        /// <summary>
        /// مقاس الخصر
        /// </summary>
        public int Z1
        {
            get;
            private set;
        }

        /// <summary>
        /// مقاس القدم
        /// </summary>
        public int z2
        {
            get;
            private set;
        }

        /// <summary>
        /// مقاس الكتفين
        /// </summary>
        public int z3
        {
            get;
            private set;
        }

        public System.Xml.XmlDataDocument XmlHobbies
        {
            get;
            private set;

        }

        public void ChanId(int id)
        {
            if (this.id <= 0)
                this.id = id;

        }
        public override System.Data.SqlClient.SqlCommand adder()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand(" INSERT INTO [Information_Ta]([first_name],[Last_name],[Father_name],[Mather_name],[natiol_id],[Gender],[where_birth],[data_barthday],[Hanei_whare],[Hanei_whare1] ,[adderas],[e_mail] ,[Stutes_Jtma3] ,[Phone_Ground],[Phone_Mobile1],[Phone_Mobile2] ,[Facebook] ,[Twiter] ,[whatsApp] ,[viper] ,[study],[yearstudy],[Id_course],[Id_course_Ware],[data_regs] ,[Image_id_nationl1],[Image_id_nationl2],[image],[Image_font],[Boold_id],[Nkname],[nameEnglish],[Z1],[z2],[z3],[XmlHobbies],[Delete])output INSERTED.ID VALUES ( @first_name   ,@Last_name   ,@Father_name  ,@Mather_name  ,@natiol_id  ,@Gender  ,@where_birth  ,@data_barthday  ,@Hanei_whare  ,@Hanei_whare1   ,@adderas  ,@e_mail   ,@Stutes_Jtma3   ,@Phone_Ground  ,@Phone_Mobile1  ,@Phone_Mobile2   ,@Facebook   ,@Twiter   ,@whatsApp   ,@viper   ,@study  ,@yearstudy  ,@Id_course  ,@Id_course_Ware  ,@data_regs   ,@Image_id_nationl1  ,@Image_id_nationl2  ,@image  ,@Image_font  ,@Boold_id  ,@Nkname  ,@nameEnglish  ,@Z1  ,@z2  ,@z3  ,@XmlHobbies   ,@Delete )");

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("first_name", this.first_name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Last_name", this.Last_name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Father_name", this.Father_name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Mather_name", this.Mather_name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("natiol_id", this.natiol_id));
            if (this.Gender != null)
                SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Gender", this.Gender));
            else
                SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Gender", DBNull.Value));

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("data_barthday", this.data_barthday));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Hanei_whare", this.Hanei_whare));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Hanei_whare1", this.Hanei_whare1));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("adderas", this.adderas));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("e_mail", this.e_mail));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Stutes_Jtma3", this.Stutes_Jtma3));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Phone_Ground", this.Phone_Ground));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Phone_Mobile1", this.Phone_Mobile1));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Phone_Mobile2", this.Phone_Mobile2));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Facebook", this.Facebook));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Twiter", this.Twiter));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("whatsApp", this.whatsApp));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("viper", this.viper));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("study", this.study));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("where_birth", this.where_birth));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("data_regs", this.data_regs));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("yearstudy", this.yearstudy));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_course", this.Id_course));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_course_Ware", this.Id_course_Ware));

            #region Image_id_nationl1
            if (Image_id_nationl1 != null)
            {
                SqlParameter SqlParameter3 = new System.Data.SqlClient.SqlParameter("Image_id_nationl1", ClassConvert.ConvImageTobyteArray(this.Image_id_nationl1));
                SqlParameter3.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter3);
            }
            else
            {
                SqlParameter SqlParameter3 = new System.Data.SqlClient.SqlParameter("Image_id_nationl1", DBNull.Value);
                SqlParameter3.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter3);
            }
            #endregion

            #region Image_id_nationl2
            if (Image_id_nationl2 != null)
            {
                SqlParameter SqlParameter4 = new System.Data.SqlClient.SqlParameter("Image_id_nationl2", ClassConvert.ConvImageTobyteArray(this.Image_id_nationl2));
                SqlParameter4.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter4);
            }
            else
            {
                SqlParameter SqlParameter4 = new System.Data.SqlClient.SqlParameter("Image_id_nationl2", DBNull.Value);
                SqlParameter4.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter4);
            }
            #endregion

            #region image
            if (image != null)
            {
                SqlParameter SqlParameter2 = new System.Data.SqlClient.SqlParameter("image", ClassConvert.ConvImageTobyteArray(this.image));
                SqlParameter2.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter2);
            }
            else
            {
                SqlParameter SqlParameter2 = new System.Data.SqlClient.SqlParameter("image", DBNull.Value);
                SqlParameter2.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter2);
            }
            #endregion

            #region Image_font
            if (Image_font != null)
            {
                SqlParameter SqlParameter1 = new System.Data.SqlClient.SqlParameter("Image_font", ClassConvert.ConvImageTobyteArray(this.Image_font));
                SqlParameter1.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter1);
            }
            else
            {
                SqlParameter SqlParameter1 = new System.Data.SqlClient.SqlParameter("Image_font", DBNull.Value);
                SqlParameter1.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter1);
            }
            #endregion

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Boold_id", this.Boold_id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Nkname", this.Nkname));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("nameEnglish", this.nameEnglish));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Z1", this.Z1));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("z2", this.z2));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("z3", this.z3));

            #region XmlHobbies
            if (XmlHobbies != null)
            {
                SqlParameter param = new SqlParameter("@XmlHobbies", SqlDbType.Xml);
                param.Value = new SqlXml(new XmlTextReader(XmlHobbies.InnerXml, XmlNodeType.Document, null));
                SqlCommand1.Parameters.Add(param);
            }
            else
            {
                SqlParameter param = new SqlParameter("@XmlHobbies", DBNull.Value);
                SqlCommand1.Parameters.Add(param);
            }
            #endregion


            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));

            return SqlCommand1;
        }

        public override System.Data.SqlClient.SqlCommand Delete()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Information_Ta] SET [Delete] =@Delete WHERE id =@id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", this.id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", true));
            return SqlCommand1;
        }

        public override System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Information_Ta] SET [first_name] = @first_name,[Last_name] = @Last_name,[Father_name] =@Father_name ,[Mather_name] =@Mather_name ,[natiol_id] =@natiol_id ,[Gender] =@Gender ,[where_birth] =@where_birth  ,[data_barthday] =@data_barthday ,[Hanei_whare] =@Hanei_whare ,[Hanei_whare1] =@Hanei_whare1  ,[adderas] =@adderas ,[e_mail] =@e_mail,[Stutes_Jtma3] =@Stutes_Jtma3 ,[Phone_Ground] =@Phone_Ground ,[Phone_Mobile1] =@Phone_Mobile1,[Phone_Mobile2] =@Phone_Mobile2 ,[Facebook] =@Facebook ,[Twiter] =@Twiter ,[whatsApp] =@whatsApp ,[viper] =@viper,[study] =@study,[yearstudy] =@yearstudy,[Id_course] =@Id_course ,[Id_course_Ware] =@Id_course_Ware ,[data_regs] =@data_regs,[Image_id_nationl1] =@Image_id_nationl1 ,[Image_id_nationl2] =@Image_id_nationl2 ,[image] =@image,[Image_font] =@Image_font,[Boold_id] =@Boold_id ,[Nkname] =@Nkname ,[nameEnglish] =@nameEnglish ,[Z1] =@Z1 ,[z2] =@z2,[z3] =@z3 ,[XmlHobbies] =@XmlHobbies WHERE id =@id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", this.id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("first_name", this.first_name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Last_name", this.Last_name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Father_name", this.Father_name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Mather_name", this.Mather_name));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("natiol_id", this.natiol_id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Gender", this.Gender));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("data_barthday", this.data_barthday));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Hanei_whare", this.Hanei_whare));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Hanei_whare1", this.Hanei_whare1));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("adderas", this.adderas));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("e_mail", this.e_mail));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Stutes_Jtma3", this.Stutes_Jtma3));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Phone_Ground", this.Phone_Ground));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Phone_Mobile1", this.Phone_Mobile1));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Phone_Mobile2", this.Phone_Mobile2));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Facebook", this.Facebook));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Twiter", this.Twiter));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("whatsApp", this.whatsApp));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("viper", this.viper));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("study", this.study));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("where_birth", this.where_birth));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("data_regs", this.data_regs));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("yearstudy", this.yearstudy));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_course", this.Id_course));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Id_course_Ware", this.Id_course_Ware));

            #region Image_id_nationl1
            if (Image_id_nationl1 != null)
            {
                SqlParameter SqlParameter3 = new System.Data.SqlClient.SqlParameter("Image_id_nationl1", ClassConvert.ConvImageTobyteArray(this.Image_id_nationl1));
                SqlParameter3.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter3);
            }
            else
            {
                SqlParameter SqlParameter3 = new System.Data.SqlClient.SqlParameter("Image_id_nationl1", DBNull.Value);
                SqlParameter3.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter3);
            }
            #endregion

            #region Image_id_nationl2
            if (Image_id_nationl2 != null)
            {
                SqlParameter SqlParameter4 = new System.Data.SqlClient.SqlParameter("Image_id_nationl2", ClassConvert.ConvImageTobyteArray(this.Image_id_nationl2));
                SqlParameter4.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter4);
            }
            else
            {
                SqlParameter SqlParameter4 = new System.Data.SqlClient.SqlParameter("Image_id_nationl2", DBNull.Value);
                SqlParameter4.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter4);
            }
            #endregion

            #region image
            if (image != null)
            {
                SqlParameter SqlParameter2 = new System.Data.SqlClient.SqlParameter("image", ClassConvert.ConvImageTobyteArray(this.image));
                SqlParameter2.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter2);
            }
            else
            {
                SqlParameter SqlParameter2 = new System.Data.SqlClient.SqlParameter("image", DBNull.Value);
                SqlParameter2.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter2);
            }
            #endregion

            #region Image_font
            if (Image_font != null)
            {
                SqlParameter SqlParameter1 = new System.Data.SqlClient.SqlParameter("Image_font", ClassConvert.ConvImageTobyteArray(this.Image_font));
                SqlParameter1.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter1);
            }
            else
            {
                SqlParameter SqlParameter1 = new System.Data.SqlClient.SqlParameter("Image_font", DBNull.Value);
                SqlParameter1.SqlDbType = SqlDbType.Image;
                SqlCommand1.Parameters.Add(SqlParameter1);
            }
            #endregion

            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Boold_id", this.Boold_id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Nkname", this.Nkname));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("nameEnglish", this.nameEnglish));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Z1", this.Z1));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("z2", this.z2));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("z3", this.z3));

            #region XmlHobbies
            if (XmlHobbies == null)
            {
                SqlParameter param = new SqlParameter("@XmlHobbies", DBNull.Value);
                SqlCommand1.Parameters.Add(param);
            }
            else
            {
                SqlParameter param = new SqlParameter("@XmlHobbies", DBNull.Value);
                SqlCommand1.Parameters.Add(param);
            }
            #endregion



            return SqlCommand1;
        }
        public  System.Data.SqlClient.SqlCommand GetFromIdAsnc(int id)
        {
            System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand("SELECT [id],[first_name],[Last_name],[Father_name],[Mather_name],[natiol_id],[Gender],[where_birth],[data_barthday],[Hanei_whare],[Hanei_whare1],[adderas],[e_mail],[Stutes_Jtma3],[Phone_Ground],[Phone_Mobile1],[Phone_Mobile2],[Facebook],[Twiter],[whatsApp],[viper],[study],[yearstudy],[Id_course],[Id_course_Ware],[data_regs],[Boold_id],[Nkname],[nameEnglish],[Z1],[z2],[z3],[Delete] FROM [Information_Ta] where [id] = @id");
            SqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));

            return SqlCommand;
        }

        public override System.Data.SqlClient.SqlCommand GetFromId(int id)
        {
            System.Data.SqlClient.SqlCommand SqlCommand = new System.Data.SqlClient.SqlCommand("SELECT [id],[first_name],[Last_name],[Father_name],[Mather_name],[natiol_id],[Gender],[where_birth],[data_barthday],[Hanei_whare],[Hanei_whare1],[adderas],[e_mail],[Stutes_Jtma3],[Phone_Ground],[Phone_Mobile1],[Phone_Mobile2],[Facebook],[Twiter],[whatsApp],[viper],[study],[yearstudy],[Id_course],[Id_course_Ware],[data_regs],[Image_id_nationl1],[Image_id_nationl2],[image],[Image_font],[Boold_id],[Nkname],[nameEnglish],[Z1],[z2],[z3],[Delete] FROM [HR_SARC].[dbo].[Information_Ta] where [id] = @id");
            SqlCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));

            return SqlCommand;
        }
        public static bool GetIf(Int64 Idnas)
        {


            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [Id] FROM [HR_SARC].[dbo].[Information_Ta]  where [natiol_id] = @id ");
            SqlComm.Parameters.AddWithValue("@id", Idnas);
            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    return false;

            return true;


        }

        public static bool GetIfEmail(string Idnas)
        {


            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [Id] FROM [HR_SARC].[dbo].[Information_Ta]  where [e_mail] = @id ");
            SqlComm.Parameters.AddWithValue("@id", Idnas);
            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    return false;

            return true;


        }

        public static bool GetIfmobilephon(int Idnas)
        {


            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("SELECT [Id] FROM [HR_SARC].[dbo].[Information_Ta]  where [Phone_Mobile1] = @id ");
            SqlComm.Parameters.AddWithValue("@id", Idnas);
            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    return false;

            return true;


        }
        public static System.Data.SqlClient.SqlCommand Serch1(int id)
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("SELECT  * FROM [dbo].[Serch1] Where id = @id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));

            return SqlCommand1;

        }

        public static System.Data.SqlClient.SqlCommand Serch1(string stringx)
        {
            stringx = ClassDataGridViewDo.LograthemChangEverAleffToAll(stringx, true);

            SqlCommand Sqlcom = new SqlCommand("SELECT Id, first_name + N' ' + Last_name AS [الأسم الكامل], natiol_id AS [الرقم الوطني], Id_course AS [id الهلال], Id_course_Ware AS الفرع, adderas AS العنوان, Phone_Mobile1 AS موبايل, Phone_Ground AS أرضي FROM [HR_SARC].[dbo].[All_Info] where [Delete] = 0 and  [Expr1] like @namx ");
            Sqlcom.Parameters.AddWithValue("@namx", "%" + stringx + "%");

            return Sqlcom;

        }

        public static System.Data.SqlClient.SqlCommand Serhid(List<IDinformationAdvSrchFullCoures> idLIst)
        {
            string STe = " And id = 0";
            if (idLIst.Count != 0)
            {
                 STe = "And (";
                for (int i = 0; i < idLIst.Count; i++)
                {
                    if (i == idLIst.Count - 1)
                        STe += "  [id] = " + idLIst[i].idinformation.ToString();
                    else
                        STe += "  [id] = " + idLIst[i].idinformation.ToString() + " or ";

                }
                STe += " ) ";
            }
            SqlCommand Sqlcom = new SqlCommand("SELECT Id, first_name + N' ' + Last_name AS [الأسم الكامل], natiol_id AS [الرقم الوطني], Id_course AS [id الهلال], Id_course_Ware AS الفرع, adderas AS العنوان, Phone_Mobile1 AS موبايل, Phone_Ground AS أرضي FROM [HR_SARC].[dbo].[Information_Ta] where [Delete] = 0 " + STe);
            
            return Sqlcom;
        }

        public static System.Data.SqlClient.SqlCommand SerchRetIdInformation(string stringx , string informSelect , SqlCommand SqlcomadAdder , DateTime DateFrom , DateTime DateEnd)
        {
            /*
            string whereString = "";
            string SelecSqlTeam = " , [HR_SARC].[dbo].[Team_ta].[Id_Jop_Ta] ";
            string innerTeam = @"INNER JOIN  [HR_SARC].[dbo].[Team_ta] ON  [HR_SARC].[dbo].[Information_Ta].[Id] =  [HR_SARC].[dbo].[Team_ta].[ID_informtion] ";
          
            string InnerCoures = @"INNER JOIN  [HR_SARC].[dbo].[Couress_ta] ON  [HR_SARC].[dbo].[Information_Ta].[Id] =  [HR_SARC].[dbo].[Couress_ta].[Id_Information]";
           
          
            string Sql_JopDelete = "( [HR_SARC].[dbo].[Team_ta].[Delete] = 0) ";
            string Sql_CouressDelete = "( [HR_SARC].[dbo].[Couress_ta].[Delete] = 0) ";
            string Sql_informationSelect = " ([HR_SARC].[dbo].[Information_Ta].[Delete] = 0) And [HR_SARC].[dbo].[Information_Ta].[first_name] + N' '+[HR_SARC].[dbo].[Information_Ta].[Last_name] like @namx ";

            stringx = ClassDataGridViewDo.LograthemChangEverAleffToAll(stringx, true);
            List<List<string>> strinofidcoresc = new List<List<string>>();

            string SqlCommandInformation = @"
        [" + Sqldatabasethrding.NameDataBase + @"].[dbo].[Information_Ta].[Id]";
             string SqlCommandCorser =@" 
           [" + Sqldatabasethrding.NameDataBase + @"].[dbo].[Couress_ta].[id_NameOfCouress]  ";

             string SqlCommandTeam = @" 
           [" + Sqldatabasethrding.NameDataBase + @"].[dbo].[Team_ta].[id_NameTeam_Ta]  ";
                
           


             List<int> Id_coresListAffterProsses = new List<int>();

             #region دروات
             
           
            ////معالجة الأي دي الدورات المطلوبة
                for (int vc = 0; vc < id_cores.Count; vc++)
                {
                    
                    for (int j = 0; j < NameOfCouress.NameOfCouresslist.Count; j++)
                    {
                        if (NameOfCouress.NameOfCouresslist[j].Id_TypeofCouress_ta == id_cores[vc])
                        {
                            if (NameOfCouress.NameOfCouresslist[j].dataStart >= datestart && NameOfCouress.NameOfCouresslist[j].dataStart <= dateend)
                            { Id_coresListAffterProsses.Add(NameOfCouress.NameOfCouresslist[j].id); }
                        }

                    }
                    
                }


                if (Id_coresListAffterProsses.Count != 0)
                {
                    whereString += " (";
                    for (int i = 0; i < Id_coresListAffterProsses.Count; i++)
                        if (i != Id_coresListAffterProsses.Count - 1)
                     {

                         whereString += "[" + Sqldatabasethrding.NameDataBase + @"].[dbo].[Couress_ta].[id_NameOfCouress] = " + Id_coresListAffterProsses[i] + " or ";
                     }
                     else
                     {
                         whereString += "[" + Sqldatabasethrding.NameDataBase + @"].[dbo].[Couress_ta].[id_NameOfCouress] = " + Id_coresListAffterProsses[i];
                     }
                 whereString += ") And ";
                }
             #endregion
                //   List<string> ListFormWhare = new List<string>();
                #region العمل
                if (idjop.Count != 0)
                {
                    whereString += " (";
                    for (int i = 0; i < idjop.Count; i++)
                        if (i != idjop.Count - 1)
                        {

                            whereString += "[" + Sqldatabasethrding.NameDataBase + @"].[dbo].[Team_ta].[Id_Jop_Ta] = " + idjop[i] + " or ";
                        }
                        else
                        {
                            whereString += "[" + Sqldatabasethrding.NameDataBase + @"].[dbo].[Team_ta].[Id_Jop_Ta] = " + idjop[i];
                        }
                    whereString += ") And ";
                }
                #endregion

                whereString += string.Format("{0} {1}", Id_coresListAffterProsses.Count != 0 ? 
             Sql_CouressDelete : "",

                idjop.Count != 0 && idjop.Count != 0 ? Id_coresListAffterProsses.Count !=0 ?
                " And "+ Sql_JopDelete : Sql_JopDelete :""
                );
                whereString += Id_coresListAffterProsses.Count != 0 
                 || idjop.Count != 0 //AdderTeam
                ? " AND " : "";

           whereString += " ([HR_SARC].[dbo].[Information_Ta].[Delete] = 0) And [HR_SARC].[dbo].[Information_Ta].[first_name] + N' '+[HR_SARC].[dbo].[Information_Ta].[Last_name] like @namx ";
           string Sql = string.Format(@"SELECT {0} {1} {2} From  [" + Sqldatabasethrding.NameDataBase + @"].[dbo].[Information_Ta] {3} {4} Where {5}  ", SqlCommandInformation, Id_coresListAffterProsses.Count > 0 ? "," + SqlCommandCorser : "", idjop.Count !=0 ? SelecSqlTeam : ""
                    , Id_coresListAffterProsses.Count > 0 ? InnerCoures : "",
                     idjop.Count > 0 ? innerTeam : ""
                    , whereString
                    );
            ///
                SqlCommand Sqlcom = new SqlCommand(@Sql );
                Sqlcom.Parameters.AddWithValue("@namx", "%" + stringx + "%"); /// SerchSqlCommandForName




                return Sqlcom;*/

            stringx = ClassDataGridViewDo.LograthemChangEverAleffToAll(stringx, true);
            if (informSelect != "")
            informSelect= informSelect.Insert(0, " AND ");

            if (DateFrom == DateTime.MinValue)
                DateFrom = Convert.ToDateTime("1/1/1753");

            if (DateEnd == DateTime.MinValue)
                DateEnd = DateTime.Now;



            SqlcomadAdder.CommandText = "SELECT Id FROM [HR_SARC].[dbo].[Information_Ta] where [Delete] = 0 and  [HR_SARC].[dbo].[Information_Ta].[first_name] + N' '+[HR_SARC].[dbo].[Information_Ta].[Last_name] like @namx  and data_regs >=@DateFrom and data_regs <=@DateEnd " + informSelect;
           
            SqlcomadAdder.Parameters.AddWithValue("@DateFrom", DateFrom);
            SqlcomadAdder.Parameters.AddWithValue("@DateEnd", DateEnd);

            SqlcomadAdder.Parameters.AddWithValue("@namx", "%" + stringx + "%");
             
            return SqlcomadAdder;


            /*
            stringx = ClassDataGridViewDo.LograthemChangEverAleffToAll(stringx, true);
            List<List<string>> strinofidcoresc = new List<List<string>>();
            if (id_cores.Count == 0 && idjop != null)
            {


                #region idJop


                for (int vc = 0; vc < idjop.Count; vc++)
                {
                    List<string> strinofidcores = new List<string>();
                    for (int j = 0; j < Jop.JopStatic.Count; j++)
                    {
                        if (Jop.JopStatic[j].id == idjop[vc])
                        {
                            if (NameOfCouress.NameOfCouresslist[j].dataStart >= datestart && NameOfCouress.NameOfCouresslist[j].dataStart <= dateend)
                                strinofidcores.Add("[Id_Jop_Ta] = " + NameOfCouress.NameOfCouresslist[j].id);
                        }

                    }
                    strinofidcoresc.Add(strinofidcores);

                }

                List<string> Allf = new List<string>();
                foreach (List<string> St in strinofidcoresc)
                {
                    string Strq = "";
                    if (St.Count != 0)
                        Strq += "(";
                    foreach (string ve in St)
                        Strq += ve + " or ";

                    try
                    {
                        Strq = Strq.Remove(Strq.Length - 4, 4);
                    }
                    catch { }
                    if (St.Count != 0)
                        Strq += ")";
                    if (Strq != "")
                        Allf.Add(Strq);
                }


                string strinofidcoresca = "";
                foreach (string sfe in Allf)
                {
                    strinofidcoresca += sfe + " And ";

                }
                #endregion
                if (Fs == true)
                {
                    strinofidcoresca += "Date_End=@Date_End And ";

                }

                SqlCommand Sqlcom = new SqlCommand("SELECT [Id]  ,[الأسم الكامل] ,[الرقم الوطني]  ,[id الهلال] ,[الفرع] ,[العنوان]   ,[موبايل]  ,[أرضي] FROM [HR_SARC].[dbo].[SerchbynameAndTemaJop] where " + strinofidcoresca + "  [الأسم الكامل] like @namx ");
                Sqlcom.Parameters.AddWithValue("@namx", "%" + stringx + "%");
                Sqlcom.Parameters.AddWithValue("@Date_End", DBNull.Value);
                return Sqlcom;

            }

            else if (idjop == null && Fs == false && id_cores.Count != 0)
            {
                #region Foridcores


                for (int vc = 0; vc < id_cores.Count; vc++)
                {
                    List<string> strinofidcores = new List<string>();
                    for (int j = 0; j < NameOfCouress.NameOfCouresslist.Count; j++)
                    {
                        if (NameOfCouress.NameOfCouresslist[j].Id_TypeofCouress_ta == id_cores[vc])
                        {
                            if (NameOfCouress.NameOfCouresslist[j].dataStart >= datestart && NameOfCouress.NameOfCouresslist[j].dataStart <= dateend)
                                strinofidcores.Add("[id_nameOfcouress] = " + NameOfCouress.NameOfCouresslist[j].id);
                        }

                    }
                    strinofidcoresc.Add(strinofidcores);

                }

                List<string> Allf = new List<string>();
                foreach (List<string> St in strinofidcoresc)
                {
                    string Strq = "";
                    if (St.Count != 0)
                        Strq += "(";
                    foreach (string ve in St)
                        Strq += ve + " or ";

                    try
                    {
                        Strq = Strq.Remove(Strq.Length - 4, 4);
                    }
                    catch { }
                    if (St.Count != 0)
                        Strq += ")";
                    if (Strq != "")
                        Allf.Add(Strq);
                }


                string strinofidcoresca = "";
                foreach (string sfe in Allf)
                {
                    strinofidcoresca += sfe + " And ";

                }
                #endregion



                SqlCommand Sqlcom = new SqlCommand("SELECT [Id]  ,[الأسم الكامل] ,[الرقم الوطني]  ,[id الهلال] ,[الفرع] ,[العنوان]   ,[موبايل]  ,[أرضي] FROM [HR_SARC].[dbo].[SerchByNameAndDateStartAndIdcor] where " + strinofidcoresca + "  [الأسم الكامل] like @namx ");
                Sqlcom.Parameters.AddWithValue("@namx", "%" + stringx + "%");
                return Sqlcom;
            }
            else if (id_cores.Count != 0 && idjop != null)
            {
                #region Foridcores


                for (int vc = 0; vc < id_cores.Count; vc++)
                {
                    List<string> strinofidcores = new List<string>();
                    for (int j = 0; j < NameOfCouress.NameOfCouresslist.Count; j++)
                    {
                        if (NameOfCouress.NameOfCouresslist[j].Id_TypeofCouress_ta == id_cores[vc])
                        {
                            if (NameOfCouress.NameOfCouresslist[j].dataStart >= datestart && NameOfCouress.NameOfCouresslist[j].dataStart <= dateend)
                                strinofidcores.Add("[id_nameOfcouress] = " + NameOfCouress.NameOfCouresslist[j].id);
                        }

                    }
                    strinofidcoresc.Add(strinofidcores);

                }

                List<string> Allf = new List<string>();
                foreach (List<string> St in strinofidcoresc)
                {
                    string Strq = "";
                    if (St.Count != 0)
                        Strq += "(";
                    foreach (string ve in St)
                        Strq += ve + " or ";

                    try
                    {
                        Strq = Strq.Remove(Strq.Length - 4, 4);
                    }
                    catch { }
                    if (St.Count != 0)
                        Strq += ")";
                    if (Strq != "")
                        Allf.Add(Strq);
                }


                string strinofidcoresca = "";
                foreach (string sfe in Allf)
                {
                    strinofidcoresca += sfe + " And ";

                }
                #endregion

                #region idJop


                for (int vc = 0; vc < idjop.Count; vc++)
                {
                    List<string> strinofidcores = new List<string>();
                    for (int j = 0; j < Jop.JopStatic.Count; j++)
                    {
                        if (Jop.JopStatic[j].id == idjop[vc])
                        {
                            if (NameOfCouress.NameOfCouresslist[j].dataStart >= datestart && NameOfCouress.NameOfCouresslist[j].dataStart <= dateend)
                                strinofidcores.Add("[Id_Jop_Ta] = " + NameOfCouress.NameOfCouresslist[j].id);
                        }

                    }
                    strinofidcoresc.Add(strinofidcores);

                }

                Allf = new List<string>();
                foreach (List<string> St in strinofidcoresc)
                {
                    string Strq = "";
                    if (St.Count != 0)
                        Strq += "(";
                    foreach (string ve in St)
                        Strq += ve + " or ";

                    try
                    {
                        Strq = Strq.Remove(Strq.Length - 4, 4);
                    }
                    catch { }
                    if (St.Count != 0)
                        Strq += ")";
                    if (Strq != "")
                        Allf.Add(Strq);
                }



                foreach (string sfe in Allf)
                {
                    strinofidcoresca += sfe + " And ";

                }
                #endregion

                if (Fs == true)
                {
                    strinofidcoresca += "Date_End=@Date_End And ";

                }
                SqlCommand Sqlcom = new SqlCommand("SELECT [Id]  ,[الأسم الكامل] ,[الرقم الوطني]  ,[id الهلال] ,[الفرع] ,[العنوان]   ,[موبايل]  ,[أرضي] FROM [HR_SARC].[dbo].[SerchbyNameAndDateStareAndIdcorsAndActive] where " + strinofidcoresca + "  [الأسم الكامل] like @namx ");
                Sqlcom.Parameters.AddWithValue("@namx", "%" + stringx + "%");
                Sqlcom.Parameters.AddWithValue("@Date_End", DBNull.Value);
                return Sqlcom;
            }
            else
            {

                return Serch1(stringx);
            }*/
        }


        public static System.Data.SqlClient.SqlCommand GetAllName()
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("SELECT * FROM dbo.[Fullname] ");

            return SqlCommand1;

        }

        public static SqlCommand GetAll(int int1 = 100)
        {
            SqlCommand Sqlcommand = new SqlCommand("SELECT top (" + int1 + ") * FROM [HR_SARC].[dbo].[ShowAll] ORDER BY Id DESC ");


            return Sqlcommand;
        }

        public void UpdateOUtid(string first_name, string Last_name, string Father_name, string Mather_name, long natiol_id, bool Gender, string where_birth, DateTime data_barthday, string Hanei_whare, string Hanei_whare1, string adderas, string e_mail, int Stutes_Jtma3, int Phone_Ground, int Phone_Mobile1, int Phone_Mobile2, string Facebook, string Twiter, int whatsApp, int viper, string study, int yearstudy, int Id_course, string Id_course_Ware, DateTime data_regs, Image Image_id_nationl1, Image Image_id_nationl2, Image image, Image Image_font, int Boold_id, string Nkname, string nameEnglish, int Z1, int z2, int z3, System.Xml.XmlDataDocument XmlHobbies)
        {
            this.id = id;
            this.first_name = first_name;
            this.Last_name = Last_name;
            this.Father_name = Father_name;
            this.Mather_name = Mather_name;
            this.natiol_id = natiol_id;
            this.Gender = Gender;
            this.where_birth = where_birth;
            this.data_barthday = data_barthday;
            this.Hanei_whare = Hanei_whare;
            this.Hanei_whare1 = Hanei_whare1;
            this.adderas = adderas;
            this.e_mail = e_mail;
            this.Stutes_Jtma3 = Stutes_Jtma3;
            this.Phone_Ground = Phone_Ground;
            this.Phone_Mobile1 = Phone_Mobile1;
            this.Phone_Mobile2 = Phone_Mobile2;
            this.Facebook = Facebook;
            this.Twiter = Twiter;
            this.whatsApp = whatsApp;
            this.viper = viper;
            this.study = study;
            this.yearstudy = yearstudy;
            this.Id_course = Id_course;
            this.Id_course_Ware = Id_course_Ware;
            this.data_regs = data_regs;
            this.Image_id_nationl1 = Image_id_nationl1;
            this.Image_id_nationl2 = Image_id_nationl2;
            this.image = image;
            this.Image_font = Image_font;
            this.Boold_id = Boold_id;
            this.Nkname = Nkname;
            this.nameEnglish = nameEnglish;
            this.Z1 = Z1;
            this.z2 = z2;
            this.z3 = z3;
            this.XmlHobbies = XmlHobbies;
        }



        public async static Task<List<IdAndName>> GetAll(string stringx)
        {
            List<IdAndName> ListVitl = new List<IdAndName>();
            stringx = ClassDataGridViewDo.LograthemChangEverAleffToAll(stringx, true);

            SqlCommand Sqlcom = new SqlCommand("SELECT  [Id] , [first_name] + N' ' + [Last_name]  FROM [HR_SARC].[dbo].[Information_Ta] where [Delete] = 0 and  [first_name] + N' ' + [Last_name] like @namx ");
            Sqlcom.Parameters.AddWithValue("@namx", "%" + stringx + "%");

            List<List<object>> Vitel = await Sqldatabasethrding.GetSql(Sqlcom);
            foreach (List<object> V1 in Vitel)
            {

                ListVitl.Add(new IdAndName(Convert.ToInt32(V1[0]), V1[1].ToString()));
            }

            return ListVitl;


        }


        public async static Task<IdAndName> GetbyidIdAndName(int id)
        {



            SqlCommand Sqlcom = new SqlCommand("SELECT [Id],first_name + N' ' + Last_name AS [الأسم الكامل],[data_regs] FROM [HR_SARC].[dbo].[Information_Ta] where id = @id ");
            Sqlcom.Parameters.AddWithValue("@id", id);

            List<List<object>> Vitel = await Sqldatabasethrding.GetSql(Sqlcom);
            List<object> V1 = Vitel[0];



            return new IdAndName(Convert.ToInt32(V1[0]), V1[1].ToString(), ClassConvert.ConvDateTime(V1[2]));





        }
        public async static void DeleByid(int id)
        {

            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Information_Ta] SET [Delete] =@Delete WHERE id =@id");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", id));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", true));

            await Sqldatabasethrding.SqlSaveVitl(SqlCommand1);


        }

        public async static void EditbyIdRegInSARC(int id, DateTime Datetimeeding)
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Information_Ta] SET [data_regs] = @data_regs WHERE id =@id");
            SqlCommand1.Parameters.AddWithValue("data_regs", Datetimeeding);
            SqlCommand1.Parameters.AddWithValue("id", id);
            await Sqldatabasethrding.SqlSaveVitl(SqlCommand1);
        }

        public async static Task EditByidNationId(int id, Int64 National)
        {
            SqlCommand SqlC = new SqlCommand("UPDATE [dbo].[Information_Ta]  SET [natiol_id] = @natiol_id WHERE id = @id");
            SqlC.Parameters.AddWithValue("id" , id );
            SqlC.Parameters.AddWithValue("natiol_id", National);
      await  Sqldatabasethrding.SqlSaveVitl(SqlC);


        }

        public static SqlCommand Serch1(string stringx, DateTime DateTimerFrom, DateTime DateTimerTo)
        {
            if (DateTimerTo == DateTime.MinValue)
                DateTimerTo = DateTime.MaxValue;
            if (DateTimerFrom == DateTime.MinValue)
                DateTimerFrom = new DateTime(1753, 1, 1);

            stringx = ClassDataGridViewDo.LograthemChangEverAleffToAll(stringx, true);

            SqlCommand Sqlcom = new SqlCommand("SELECT Id, first_name + N' ' + Last_name AS [الأسم الكامل], natiol_id AS [الرقم الوطني], Id_course AS [id الهلال], Id_course_Ware AS الفرع, adderas AS العنوان, Phone_Mobile1 AS موبايل, Phone_Ground AS أرضي FROM [HR_SARC].[dbo].[Information_Ta] where [Delete] = 0 and [data_regs] >= @DateTimerFrom  and [data_regs] <= @DateTimerTo  and  first_name + N' ' + Last_name like @namx ");
            Sqlcom.Parameters.AddWithValue("@namx", "%" + stringx + "%");
            Sqlcom.Parameters.AddWithValue("@DateTimerFrom", DateTimerFrom);
            Sqlcom.Parameters.AddWithValue("@DateTimerTo", DateTimerTo);

            return Sqlcom;
        }

        #region ForMakeSqlCommandSerch


        public static SqlCommand SqlFildRetunFormList(ParamterrMakeSql ParamterrMakeSql1)
        {

            string Command = "";

            string Table = " FROM [HR_SARC].[dbo].[Information_Ta] ";
            string OutPut = ParamterrMakeSql1.retOutPutAll();
            string Joiner = ParamterrMakeSql1.RetInnerJonAll();
            string Condetion = ParamterrMakeSql1.CommanderCondtionAll(null);

            SqlCommand Sqlcom = new SqlCommand();
            
            for (int i = 0; i < ParamterrMakeSql1.CountPerammeters(); i++ )
            {
                
                Sqlcom.Parameters.AddWithValue(ParamterrMakeSql1.RetEnum(i), ParamterrMakeSql1.RetObject(i));
            }

            Command = "SELECT " + OutPut + Table + Joiner + " where " +Condetion;
            Sqlcom.CommandText = Command;

            
            return Sqlcom;

        }

        #endregion
        public enum vitl
        { id,
            first_name
               ,
            Last_name
                ,
            Father_name
                ,
            Mather_name
                ,
            natiol_id
                ,
            Gender
                ,
            where_birth
                ,
            data_barthday
                ,
            Hanei_whare
                ,
            Hanei_whare1
                ,
            adderas
                ,
            e_mail
                ,
            Stutes_Jtma3
                ,
            Phone_Ground
                ,
            Phone_Mobile1
                ,
            Phone_Mobile2
                ,
            Facebook
                ,
            Twiter
                ,
            whatsApp
                ,
            viper
                ,
            study
                ,
            yearstudy
                ,
            Id_course
                ,
            Id_course_Ware
                ,
            data_regs
                ,
            Image_id_nationl1
                ,
            Image_id_nationl2
                ,
            image
                ,
            Image_font
                ,
            Boold_id
                ,
            Nkname
                ,
            nameEnglish
                ,
            Z1
                ,
            z2
                ,
            z3
                ,
            XmlHobbies
                ,
            Delete

        }

      


    }
    public class IdAndName
    {
        public IdAndName (int id)
        {
          IdAndName IdAndName1 =     Vitl.VitlIdAndName(id);

          this.id = IdAndName1.id;
          this.Name = IdAndName1.Name;
          this.Regesterdeg = IdAndName1.Regesterdeg;
   
         }


        public int id = 0;
        public string Name = "";
        
        public DateTime Regesterdeg = new DateTime();
        public bool DeleatOrErrorId = false;
        public IdAndName(int id, string Name)
        {

            this.id = id;
            this.Name = Name;

        }

                public IdAndName(bool ErrorOrNo)
        {
            DeleatOrErrorId = true;
        }


        public IdAndName(int id, string Name, DateTime Regesterdeg)
        {

            this.id = id;
            this.Name = Name;
            this.Regesterdeg = Regesterdeg;

        }
    }



   
}

