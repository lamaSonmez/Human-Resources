using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{

    
    class ClassConvert
    {

        public static bool IsNumberPhoneMobileOrGrund (int PhoneNaumber)

        {

           
                if (PhoneNaumber.ToString().Length == 9)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            



        }

        /// <summary>
        /// تحويل إلى قيمة رقمية طويلة
        /// </summary>
        /// <param name="oBject">متغير ذات قيمة طويلة</param>
        /// <returns>رقم طويل</returns>
        public static Int64 Convint64(object oBject)
        {
            Int64 Int1 = 0;

            try
            {
                Int1 = Convert.ToInt64(oBject);

            }
            catch ( Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
            }
            return Int1;
        }

        public static float? ConvFloatNull(object oBject)
        {

            float? Int1 = null;

            try
            {
                Int1 = Convert.ToSingle(oBject);

            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
            }
            return Int1;
        
        
        }



        public static List<DataBase> ConvertListInterfaseToDataBase<T>(List<T> ConvertList)
        {

            List<DataBase> TempBack = new List<DataBase>();
            foreach (DataBase IN in ConvertList)
                TempBack.Add(IN);

            return TempBack;


        }

        /// <summary>
        /// تحويل إلى قمية صحيح
        /// </summary>
        /// <param name="oBject">متغير رقم صحيح</param>
        /// <returns>رقم بدون فواصل</returns>
        public static int Convint(object oBject)
        {
            int Int1 = 0;

            try
            {
                Int1 = Convert.ToInt32(oBject);

            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
            }
            return Int1;

        }

        /// <summary>
        /// تحويل إلى قمية صحيح
        /// </summary>
        /// <param name="oBject">متغير رقم صحيح</param>
        /// <returns>رقم بدون فواصل</returns>
        public static int? ConvintNull(object oBject)
        {
            int? Int1 = null;

            try
            {
                Int1 = Convert.ToInt32(oBject);

            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
            }
            return Int1;

        }





        public static int ConvGenderBoolNull(object oBject)
        {
    

            try
            {
                

                if (ConvBoolnull(oBject) == false)
                    return 0;
               else if (ConvBoolnull(oBject) == true)
                    return 1;
                else
                    return -1;
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
                return -1;
            }
           

        }

        public static string ConvSizeToString(int intc)
        {
                if (intc == 0)
                    return "S";
                else if (intc == 1 )
                    return "M";
                else if (intc == 2 )
                    return "L";
                else if (intc == 3 )
                    return "XL";
                else if (intc == 4)
                    return "XXL";
                else
                    return "";

        }

        public static int ConvSizeToint(object oBject)
        {


            try
            {
                if (Convert.ToString(oBject).Trim().ToUpper() == "S")
                    return 0;
                else if (Convert.ToString(oBject).Trim().ToUpper() == "M")
                    return 1;
                else if (Convert.ToString(oBject).Trim().ToUpper() == "L")
                    return 2;
                else if (Convert.ToString(oBject).Trim().ToUpper() == "XL")
                    return 3;
                else if (Convert.ToString(oBject).Trim().ToUpper() == "XXL")
                    return 4;
                else
                    return -1;
            }
            catch (Exception e)
            {  ErrorClass.ErrorClassConvert(e);
                return -1;
            }

           
        }
        public static int ConvToStatesF(object oBject)
        {


            try
            {
                if (Convert.ToString(oBject).Trim() == "أعزب")
                    return 0;
                else if (Convert.ToString(oBject).Trim() == "اعزب")
                    return 0;
                else if (Convert.ToString(oBject).Trim() == "عزباء")
                    return 0;
                else if (Convert.ToString(oBject).Trim() == "متزوج")
                    return 1;
                else if (Convert.ToString(oBject).Trim() == "متزوجه")
                    return 1;
                else if (Convert.ToString(oBject).Trim() == "متزوجة")
                    return 1;
                else
                    return -1;
            }
            catch (Exception e)
            {  ErrorClass.ErrorClassConvert(e);
                return -1;
            }
          

        }

        public static int ConvToStady(object oBject)
        {

            try
            {

                return (Convert.ToInt32(oBject) - 1);

            }
            catch
            {
                try
                {

                    if (Convert.ToString(oBject).Trim() == "متخرج")
                    { return 6; }
                    else
                        return -1;
                }
                catch (Exception e)
                {
                    ErrorClass.ErrorClassConvert(e);
                    return -1;
                }
            }


        }
        public static string ConvString(object oBject)
        {
            string string1 = null;

            try
            {
                string1 = Convert.ToString(oBject);
                if (string1 == "")
                    string1 = null;
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);

            }
            return string1;
            
        }
        public static string ConvNonullTostring(object oBject)
        {
            string string1 = "";

            try
            {
                string1 = Convert.ToString(oBject);

            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);

            }
            return string1;

        }

        /// <summary>
        /// تحويل إلى bit
        /// </summary>
        /// <param name="oBject">قيمة 1 أو 0</param>
        /// <returns>منطقي</returns>
        public static bool ConvBool(object oBject)
        {
            bool bool1 = false;

            try
            {
             
                    bool1 = Convert.ToBoolean(oBject);
              
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);

            }
            return bool1;

        }
        public static bool? ConvBoolnull(object oBject)
        {
         

            try
            {
                if (oBject.ToString() != "")
                    return Convert.ToBoolean(oBject);
                else
                    return null;
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
                return null;
            }
         

        }

        public static byte[] ConvImageTobyteArray(object oBject)
        {
            MemoryStream ace = new MemoryStream();
         
            byte[] byte1 = null;
            try
            {
               System.Drawing.Image  Image1 = (System.Drawing.Image)oBject;
                Image1.Save(ace, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte1 = ace.ToArray();


            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);

            }
            finally
            {
                ace.Dispose();
        
            }
            return byte1;

        }

        /// <summary>
        /// تحويل إلى وقت
        /// </summary>
        /// <param name="oBject">متغير الوقت</param>
        /// <returns>وقت</returns>
        public static DateTime ConvDateTime(object oBject)
        {
            DateTime DateTime1 = new DateTime();



            try
            {
                DateTime1 = Convert.ToDateTime(oBject);
                if (DateTime1 == DateTime.MinValue)
                {
                    DateTime1 = Convert.ToDateTime("1753/2/1");
                }
            }
               catch (Exception e)

            {
                    ErrorClass.ErrorClassConvert(e);
                DateTime1 = Convert.ToDateTime("1753/2/1");

            }
            return DateTime1;
           
        }
        public static DateTime? ConvDateTimeNull(object oBject)
        {
            DateTime? DateTime1 = null;



            try
            {

                DateTime1 = Convert.ToDateTime(oBject);
                if (DateTime1 == DateTime.MinValue)
                {
                    DateTime1 = null;
                }
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);

            }
            return DateTime1;

        }


        /// <summary>
        /// تحويل من متحول عام إلى صورة
        /// </summary>
        /// <param name="oBject">متغير الصورة</param>
        /// <returns>صورة</returns>
        public static System.Drawing.Image ConvImage(object oBject)
        {
            ///يستوجب تعديل من أجل وضع صورة إفتراضية
            ///تغير إلى null
            ///
            if (oBject == null)
                return null;
            Type ve = oBject.GetType();
            if (ve.Name == "Byte[]")
            {
                try
                {

                    byte[] e = (byte[])(oBject);
                    System.IO.MemoryStream fe = new MemoryStream(e);

                    return System.Drawing.Image.FromStream(fe);


                }
                catch (Exception e)
                {
                    ErrorClass.ErrorClassConvert(e);
                    return null;
                }
                     
            }
            else
            {
                try
                {
                    System.Drawing.Image Image1 = (System.Drawing.Image)oBject;
                    if (Image1 == null)
                        Image1 = System.Drawing.Image.FromFile("C:\\do.jpg");
                    return Image1;
                }

                catch (Exception e)
                {
                    ErrorClass.ErrorClassConvert(e);
                    return null;
                }
            }


        }

        public static System.Xml.XmlDataDocument ConvXml(object oBject)
        {
            ///يستوجب تعديل من أجل وضع صورة إفتراضية
            ///
            System.Xml.XmlDataDocument XmlDataDocument1 = new System.Xml.XmlDataDocument();

            try
            {
                System.Xml.XmlDataDocument XmlDataDocument = (System.Xml.XmlDataDocument)oBject;
                return XmlDataDocument;
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
              
            }
            return XmlDataDocument1;

        }

        public static string ConvertTostringDateOrNull(DateTime? oBject)
        {
            string SW = null;
            try
            {
                SW = oBject.Value.ToShortDateString();
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);

            }
            return SW;
        }

        public static bool? ConvBoolMelaFemalNUll(object p)
        {
            try
            {
                return Convert.ToBoolean(p);
            }
            catch
            {
                try
                {
                    if ((Convert.ToString(p)).Trim() == "ذكر")
                        return false;
                    else if ((Convert.ToString(p)).Trim() == "انثى")
                        return true;
                    else if ((Convert.ToString(p)).Trim() == "إنثى")
                        return true;
                    else if ((Convert.ToString(p)).Trim() == "أنثى")
                        return true;
                    else if ((Convert.ToString(p)).Trim() == "انثي")
                        return true;
                    else if ((Convert.ToString(p)).Trim() == "أنثي")
                        return true;
                    else if ((Convert.ToString(p)).Trim() == "إنثي")
                        return true;
                    else
                        return null;
                }
                catch (Exception e)
                {
                    ErrorClass.ErrorClassConvert(e);
                    return null;
                }

           
            }

        }

        public static int ConvintBoloed(object p)
        {
            try
            {
                return Convert.ToInt32(p);
            }
            catch
            {
                try
                {
                    if (((Convert.ToString(p)).Trim()).ToUpper() == "A+")
                        return 0;
                    else if (((Convert.ToString(p)).Trim()).ToUpper() == "A-")
                        return 1;
                    else if (((Convert.ToString(p)).Trim()).ToUpper() == "B-")
                        return 2;
                    else if (((Convert.ToString(p)).Trim()).ToUpper() == "B+")
                        return 3;
                    else if (((Convert.ToString(p)).Trim()).ToUpper() == "AB+")
                        return 4;
                    else if (((Convert.ToString(p)).Trim()).ToUpper() == "AB-")
                        return 5;
                    else if (((Convert.ToString(p)).Trim()).ToUpper() == "O+")
                        return 6;
                    else if (((Convert.ToString(p)).Trim()).ToUpper() == "O-")
                        return 7;
                    else
                        return -1;
                }
                catch (Exception e)
                {
                    ErrorClass.ErrorClassConvert(e);
                    return -1;
                }

              

            }

        }
        public static string ConvStringBoloed(int p)
        {
           
        
                    if (p==0)
                        return "A+";
                    else if (p==1)
                        return "A-";
                    else if (p==2)
                        return "B-";
                    else if (p==3)
                        return "B+";
                    else if (p==4)
                        return "AB+";
                    else if (p==5)
                        return "AB-";
                    else if (p==6)
                        return "O+";
                    else if (p==7)
                        return "O-";
                    else
                        return "";
            



            

        }
        public static string ConvToIdNational(object p  )
        {
            try
            {
                if (Convint64(p) == 0)
                    return null;

                string Strin = Convert.ToString(p);

                while (Strin.Length < 11)
                {
                    Strin = "0" + Strin;
                }
                return Strin;
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
                return Convert.ToString(p);

            }

           
        }
        public static string ConvIdNumberAdderZero4Digit(object p)
        {
            try
            {

                string Strin = Convert.ToString(p);

                while (Strin.Length < 4)
                {
                    Strin = "0" + Strin;
                }
                return Strin;
            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);
                return Convert.ToString(p);

            }


        }
        public static string ConvNumberCombyereToString(int oBject)
        {
            switch (oBject)
            {
                case 0:
                    return "سنه 1";
                case 1:
                    return "سنه 2";
                case 2:
                    return "سنه 3";
                case 3:
                    return "سنه 4";
                case 4:
                    return "سنه 5";
                case 5:

                    return "سنه 6";
                case 6:
                    return "متخرج";
                   
                default:
                     return "";
            }
        }


        public static float ConvFloat(object oBject)
        {
            float Int1 = 0;

            try
            {
                Int1 = Convert.ToSingle(oBject);

            }
            catch (Exception e)
            {
                ErrorClass.ErrorClassConvert(e);

            }
            return Int1;
        }



        public static string Stutes_Jtma3Tostring (int Stutes_Jtma3  , bool? IsWoman )
        {
            if (Stutes_Jtma3 == 0 && (IsWoman == null || IsWoman == false ))
            {
                return "أعزب";
            }
            else if (Stutes_Jtma3 == 1 && (IsWoman == null || IsWoman == false))
            {
                return "متزوج";
            }
            else if (Stutes_Jtma3 == 0 && IsWoman == true)
            {
                return "عزباء";
            }
            else if (Stutes_Jtma3 == 1 && IsWoman==true)
            {
                return "متزوجة";
            }
            else
            {
                return "";

            }
        }

        public static string yearstudyToString(int p)
        {
            if (p == 0)
                return "سنة الأولى";
            else if (p == 1)
                return "سنة الثانية";
            else if (p == 2)
                return "سنة الثالثة";
            else if (p == 3)
                return "سنة الرابعة";
            else if (p == 4)
                return "سنة الخامسة";
            else if (p == 5)
                return "متخرج";
            else
                return "";
        }
    }
}

        

       

