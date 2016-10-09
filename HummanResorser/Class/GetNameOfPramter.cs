using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
   public class GetNameOfPramter
    {

        public static List<string> ConvertIdBranchToString = new List<string>();

       /// <summary>
       /// مصفوفة أسماء فرق 
       /// </summary>
        public static List<NameTeam> NameTeamListConvert = new List<NameTeam>();
       
       /// <summary>
       /// مصفوفة المناصب
       /// </summary>
             public static List<Jop> JopListConvert = new List<Jop>();


             public static List<String> SewtWationDec = new List<String>();

             public static List<TypeofCouress> TypeofCouresslist = new List<TypeofCouress>();
        public async static void SetUpAll ()
             {
                    #region ConvertIdBranchToString
                 ConvertIdBranchToString.Add("حلب");
            ConvertIdBranchToString.Add("حلب-سفيرة");
            ConvertIdBranchToString.Add("حلب-الباب");
            ConvertIdBranchToString.Add("حلب-عفرين");
            ConvertIdBranchToString.Add("حلب- أروم الكبرى");
            #endregion
                    #region SewtWationDec
                    SewtWationDec.Add("أساسي");
                    SewtWationDec.Add("رديف");
                    SewtWationDec.Add("موظف");
                    SewtWationDec.Add("دوار");
                    SewtWationDec.Add("غير فعال");
                    SewtWationDec.Add("مسافر");
                    SewtWationDec.Add("منقطع");
                    #endregion
            

        await Sqldatabasethrding.SqlGetAllNnameTeam(NameTeam.GetAll());
        await Sqldatabasethrding.SqlGetAllJob(Jop.GetAll());
        await Sqldatabasethrding.SqlGetAllTypeOfCouress(TypeofCouress.GetAll());

        }
      
        }

    }

