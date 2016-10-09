using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HummanResorser
{
    public class DownloadDataFromWebCliend
    {


        System.Net.WebClient WebClient = new System.Net.WebClient();

        public static readonly string ClassV = "IsAdmin"; // رقم الكلاس للتحقق
        public static readonly string Header = @"<?xml version=""1.0"" encoding=""UTF-8""?>";
        public static readonly string LocationXmlSave = System.IO.Path.GetTempPath() + "\\XXV2153CCefe.xml";
        private string DomenName = "http://127.0.0.1/HR_Asyc"; // الدومين
        //private string DomenName = "http://128.2.0.1/HR_Asycc";

        private string UserName, Password = ""; // يوز نيم و باس ورد
        public int Id { get; private set; }
        private bool Login = false; // هل تم تسجيل الدخول
        public bool LoginSet(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
            string Like = string.Format("{0}/{1}{2}"
                     , DomenName, EnumLink.ChkUserAndPassAndVerin, EnumLink.AtuTction(this.UserName, this.Password)
                     );
            try
            {
                string st = System.Text.Encoding.UTF8.GetString(WebClient.DownloadData(Like));

                Id = Convert.ToInt32(st.Trim());
                if (Id > 0)
                {
                    Login = true;
                    return true;
                }
                else if (Id == -1)
                {
                    throw new IndexOutOfRangeException("النسخة قديمة.. الرجاء تحديث");
                }
            }
            catch (WebException WebExceptionc) { Login = false; throw WebExceptionc; }

            Login = false;
            throw new IndexOutOfRangeException("كلمة السر أو أسم المستخدم خطأ");




        }

        public void ENDASSINGSHOW(int idAssingPHPid)
        {
            string Like = string.Format("{0}/{1}{2}&{3}={4}"
                     , DomenName, "EndAssetAfterGet.php", EnumLink.AtuTction(this.UserName, this.Password), "IdOfassessvitelEnd", idAssingPHPid
                     );
            try
            {
                string st = System.Text.Encoding.UTF8.GetString(WebClient.DownloadData(Like));

            }
            catch (WebException WebExceptionc)
            {
                 throw WebExceptionc;
            }
        }

        public bool LoginSet(bool Sinlnt = false)
        {
            string Like = string.Format("{0}/{1}{2}"
                     , DomenName, EnumLink.ChkUserAndPassAndVerin, EnumLink.AtuTction(this.UserName, this.Password)
                     );
            try
            {
                string st = System.Text.Encoding.UTF8.GetString(WebClient.DownloadData(Like));

                Id = Convert.ToInt32(st.Trim());
                if (Id > 0)
                {
                    Login = true;
                    return true;
                }
                else if (Id == -1)
                {if (!Sinlnt)
                    throw new IndexOutOfRangeException("النسخة قديمة.. الرجاء تحديث");
                }
            }
            catch (WebException WebExceptionc) { Login = false;
                if (!Sinlnt) throw WebExceptionc; }
            Login = false;
            if (!Sinlnt)
                throw new IndexOutOfRangeException("كلمة السر أو أسم المستخدم خطأ");

            return false;
        }
        public XDocument GetXmlFile(EnumGetXML Enum)
        {
            if (!Login)
                throw new MemberAccessException("لم يتم تسجيل الدخول");

            XDocument doc = null;
            if (Enum == EnumGetXML.GetXMLTheAssessVitel)
            {
                string Like = string.Format("{0}/{1}{2}&id={3}"
                    , DomenName
                    , EnumLink.GetNameForAssessVitel
                    , EnumLink.AtuTction(this.UserName, this.Password)
                    , this.Id
                     );
  


                string Get = System.Text.Encoding.UTF8.GetString(WebClient.DownloadData(Like));
                int f = 0;
                try
                {
                    f = Convert.ToInt32(Get);


                }
                catch { }
                if (f == -1)
                    throw new MemberAccessException("لا يوجد متطوعين للتقيم");

                try
                {
                    doc = XDocument.Parse(Get.Trim());
                }
                catch (Exception e)
                {
                    throw e;
                }
                return doc;
            }




            else if (Enum == EnumGetXML.GetXMLTheNameTeam)
            {
                string Like = string.Format("{0}/{1}{2}&id={3}"
                    , DomenName
                    , EnumLink.GetNameTeamVitel
                    , EnumLink.AtuTction(this.UserName, this.Password)
                    , this.Id

                     );


                doc = XDocument.Load(Like);
                return doc;

            }
            return doc;



        }
        public List<UserNameGetWebSite> GetInfrmationofdateGet()
        {
            if (!Login)
                throw new MemberAccessException("لم يتم تسجيل الدخول");

            List<UserNameGetWebSite> UserNameGetWebSite = new List<UserNameGetWebSite>();
            #region GetString

                string Like = string.Format("{0}/{1}{2}"
                    , DomenName
                    , EnumLink.GetAllUserInformation
                    , EnumLink.AtuTction(this.UserName, this.Password)

                     );
         try
            {
                string Get = System.Text.Encoding.UTF8.GetString(WebClient.DownloadData(Like));
                string[] temS = Get.Split(';');

                    foreach (string item in temS)
                    {
                        string[] temAll = item.Split(',');
                    UserNameGetWebSite.Add(new UserNameGetWebSite(Convert.ToInt32(temAll[0]), Convert.ToString(temAll[1]), Convert.ToString(temAll[2]) , Convert.ToString(temAll[3])));
                    }

                }
                catch { }



            
            #endregion
            return UserNameGetWebSite;
        }

        public List<AsncyGetInformation> GetInfrmationofdateGet(EnumGetXML Enum)
        {
            if (!Login)
                throw new MemberAccessException("لم يتم تسجيل الدخول");

            List<AsncyGetInformation> AsncyGetInformation = new List<AsncyGetInformation>();
            #region GetString
            if (Enum == EnumGetXML.GetString)
            {

                string Like = string.Format("{0}/{1}{2}"
                    , DomenName
                    , EnumLink.GetNameTeamVitel
                    , EnumLink.AtuTction(this.UserName, this.Password)

                     );

                try
                {

                    string Get = System.Text.Encoding.UTF8.GetString(WebClient.DownloadData(Like));

                    string[] temS = Get.Split(';');
                    foreach (string item in temS)
                    {
                        string[] temAll = item.Split(',');
                        AsncyGetInformation.Add(new AsncyGetInformation(Convert.ToInt32(temAll[0]), Convert.ToString(temAll[1]), Convert.ToInt32(temAll[2]) == 1 ? true : false));
                    }

                }
                catch { }



            }
            #endregion
            return AsncyGetInformation;

        }

        public List<vitelAssingInformation> GetAllDataByidVitl(int infox)
        {
            if (!Login)
                throw new MemberAccessException("لم يتم تسجيل الدخول");

            List<vitelAssingInformation> vitelAssingInformation1 = new List<vitelAssingInformation>();

            #region vitelAssingInformation1

            string Like = string.Format("{0}/{1}{2}{3}"
                , DomenName
                , EnumLink.GetTeamNameVitelbyid
                , EnumLink.AtuTction(this.UserName, this.Password)
                , "&IdVitl=" + infox.ToString()
                     );
            
            WebClient client = new WebClient();
            string tringofdataid = System.Text.Encoding.UTF8.GetString(client.DownloadData(Like));
            XDocument fe = XDocument.Parse(tringofdataid.Remove(0,1));



            #endregion


            List<int> qustionId = new List<int>();
           XElement elementx =    fe.Root.Element("QustionId");
            XElement elIdForm = fe.Root.Element("IdForm");
            IEnumerable<XElement> feef = elementx.Elements();
            foreach (XElement item in feef)
            {
                qustionId.Add(Convert.ToInt32(item.Value));
            }
            List<int> idinformation = new List<int>();
            XElement Allname = fe.Root.Element("AllNameId");
            IEnumerable<XElement> Allnameout = Allname.Elements();
            
            foreach (XElement item in Allnameout)
            {
                idinformation.Add(Convert.ToInt32(item.Value));
            }

            List<List<int>> restut = new List<List<int>>();
            XElement Allreslt = fe.Root.Element("AllAnsser");
            IEnumerable<XElement> Allresltin1 = Allreslt.Elements();

            foreach (XElement item in Allresltin1)
            {
                IEnumerable<XElement> Resutone = item.Elements();
                List<int> oneReslut = new List<int>();
                foreach (XElement Res in Resutone)
                {
                    oneReslut.Add(Convert.ToInt32(Res.Value));
                }

                restut.Add(oneReslut);
            }

            for (int i = 0; i < restut.Count; i++)
            {
                vitelAssingInformation1.Add(new vitelAssingInformation(qustionId, restut[i], idinformation[i] ,Convert.ToInt32( elIdForm.Value)));
            }
            return vitelAssingInformation1;



        }
        public void RetXmlFile(EnumGetXML Enum, XDocument XDocument, int IdDataBase)
        {


            if (!Login)
                throw new MemberAccessException("لم يتم تسجيل الدخول");
            string Link ="";
            if (Enum == EnumGetXML.RetXMLTheAssessVitel)
            {
                 Link = string.Format("{0}/{1}{2}&IdOpration={3}&XmlRet={4}"
                    , DomenName
                    , EnumLink.RetNameForAssessVitel
                    , EnumLink.AtuTction(this.UserName, this.Password)
                    , IdDataBase
                    , Header + XDocument.ToString()
                     );

            
                
            }
            else if (Enum == EnumGetXML.MakeAssetGet)
            {
                 Link = string.Format("{0}/{1}{2}&XmlGET={3}&IDUserLogin={4}"
                    , DomenName
                    , EnumLink.MakeAssetGet
                    , EnumLink.AtuTction(this.UserName, this.Password)
                    , Header + XDocument.ToString()
                    , IdDataBase
                     );

            }

            WebClient client = new WebClient();
        string tringofdataid = System.Text.Encoding.UTF8.GetString(client.DownloadData(Link));




    }



    public static class EnumLink
        {
            private static readonly string AtutectionLink = "?Username={0}&Password={1}&ver={2}";

            public static readonly string ChkUserAndPassAndVerin = "ChkUserAndPassAndVerin.php";//تحقق من أسم المتسخدم و كلمة السر

            public static readonly string GetNameForAssessVitel = "AssetGet.php";//أخذ أسماء للتقيم
            public static readonly string RetNameForAssessVitel = "AssetRet.php";// أرجاع مع التقيم
            public static readonly string GetTeamNameVitelbyid = "GetTeamNameVitelbyid.php";
            public static readonly string GetNameTeamVitel = "GetTeamNameVitel.php";//أرجاع أسماء الفرق
            public static readonly string GetAllUserInformation = "GetAllUserInformation.php";
            public static readonly string MakeAssetGet = "MakeAssetGet.php";
            /// <summary>
            /// إرجاع لينك بايوزر نيم و كلمة السر مع النسخة
            /// </summary>
            /// <param name="UserName">يوزر نيم</param>
            /// <param name="PassWord">كلمة السر</param>
            /// <returns></returns>
            public static string AtuTction(string UserName, string PassWord)
            {
                return string.Format(AtutectionLink, UserName, PassWord, ClassV);
            }

        }

        public enum EnumGetXML
        {
            GetXMLTheAssessVitel,
            GetXMLTheNameTeam,
            RetXMLTheAssessVitel,
            GetString,
            MakeAssetGet,


        }

    }
}
