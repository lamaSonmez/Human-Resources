using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
       public delegate object  HandleOutputParamtterMaker(object objectP );

       public delegate string HandleProssesEnum(Enum Enum , bool Isname);

       public delegate string HandleProssesOutput(Enum Enum);


 public class ParamterrMakeSql
    {
     protected string NameOfDateBase = "";

       public ParamterrMakeSql(string NameOfDateBase )
     {
   this.NameOfDateBase = NameOfDateBase;
   }
     public ParamterrMakeSql( )
     {
         this.NameOfDateBase = Sqldatabasethrding.NameDataBase;
            }



     protected string Select = "Select";
     protected string From = "From";
     public enum Condtion {like ,Eqial , WhildCart, EqlessThen , lessThen , EqMoreThen , MoreThen , isnulldb ,isnotnulldb}
     public enum Between {And , Or }
 /// <summary>
 /// الثوابت القاعدة البيانات
 /// </summary>
     protected List<Enum> ListEnum = new List<Enum>();

     /// <summary>
     /// القيمة للبحث
     /// </summary>
     protected List<object> ListObject = new List<object>();
     /// <summary>
     /// المعالجة على قيمة قبل الإخراج
     /// </summary>
     protected List<HandleOutputParamtterMaker> listCommandOutDataObject = new List<HandleOutputParamtterMaker>();

     protected List<Condtion> ListCondetion = new List<Condtion>();

     protected List<HandleProssesEnum> ListProssesEnum = new List<HandleProssesEnum>();


     protected List<Between> ListCondetionBetwen = new List<Between>();

     protected List<Enum> ListOutPut = new List<Enum>();


     protected List<EnumInnder> ListOfInner = new List<EnumInnder>();

     protected List<Enum> ListoutPutNameTab = new List<Enum>();


     protected System.Collections.Generic.Dictionary<Enum, HandleProssesOutput> ListProssessOutput = new System.Collections.Generic.Dictionary<Enum, HandleProssesOutput>();

     public string RetinnerJon (int i )
      {
          return String.Format(" INNER JOIN [{0}].[dbo].[{1}] ON {2}.{3} = [{4}].{5}", this.NameOfDateBase, ListOfInner[i].TabIner, ListOfInner[i].FromTabSelect, ListOfInner[i].FromFildSelect, ListOfInner[i].ToTabSelect, ListOfInner[i].ToFildSelect);
     
     }
     public string RetInnerJonAll()
     {
         string g = "";
         for (int i = 0; i < ListOfInner.Count; i++)
         {
             g += RetinnerJon(i)+" ";

         }
         return g;
     }


     public void AdderinnerJoin(EnumInnder EnumInnder)
    {

        ListOfInner.Add(EnumInnder);
    }


     public void Join(ParamterrMakeSql ParamterrMakeSql)
    {

        for (int i = 0; i < ParamterrMakeSql.ListObject.Count; i++)
        {
            this.ListEnum.Add(ParamterrMakeSql.ListEnum[i]);
            ListObject.Add(ParamterrMakeSql.ListObject[i]);
            listCommandOutDataObject.Add(ParamterrMakeSql.listCommandOutDataObject[i]);
            ListCondetion.Add(ParamterrMakeSql.ListCondetion[i]);
            ListProssesEnum.Add(ParamterrMakeSql.ListProssesEnum[i]);
            ListCondetionBetwen.Add(ParamterrMakeSql.ListCondetionBetwen[i]);

          
        }

        for (int i = 0; i < ParamterrMakeSql.ListOutPut.Count; i++)
        {

            ListOutPut.Add(ParamterrMakeSql.ListOutPut[i]);

            ListProssessOutput.Add(ParamterrMakeSql.ListOutPut[i], ListProssessOutput[ParamterrMakeSql.ListOutPut[i]]);
            ListoutPutNameTab.Add(ParamterrMakeSql.ListoutPutNameTab[i]);
        }


        for (int i = 0; i < ParamterrMakeSql.ListOfInner.Count; i++)
        {

            ListOfInner.Add(ParamterrMakeSql.ListOfInner[i]);

       
        }

    }

     /// <summary>
     /// لإضافة برامتير
     /// </summary>
     /// <param name="Enum">اسم قاعدة البيانات</param>
     /// <param name="pramter">القيمة</param>
     /// <param name="HandleOutputParamtterMaker">المعالجة</param>
    public void AdderParmtaer(Enum Enum, object pramter, HandleOutputParamtterMaker HandleOutputParamtterMaker, HandleProssesEnum ProssesEnum  , Condtion Condtion, Between Between)
        {
        ListEnum.Add(Enum);
        ListObject.Add(pramter);
        listCommandOutDataObject.Add(HandleOutputParamtterMaker);
        ListCondetion.Add(Condtion);
        ListCondetionBetwen.Add(Between);
        ListProssesEnum.Add(ProssesEnum);

        }


     /// <summary>
     /// لاضافة برامتير
     /// </summary>
     /// <param name="Enum">اسم قاعدة البيانات</param>
     /// <param name="pramter">قيمة ... ملاحظة يتم إخراجها متل ماهيه</param>
    public void AdderParmtaer(Enum Enum, object pramter, Condtion Condtion, Between Between)
    {

        AdderParmtaer(Enum, pramter, RetunObject, ProssesEnum, Condtion, Between);

    }

    public void AdderParmtaer(Enum Enum, object pramter, Condtion Condtion, Between Between, HandleProssesEnum ProssesEnum)
    {

        AdderParmtaer(Enum, pramter, RetunObject, ProssesEnum, Condtion, Between);

    }

    public string ProssesOutput(Enum Enum)
    {
       
            return Enum.ToString();

    }



     public string ProssesEnum ( Enum Enum , bool Isname)
    {
        if (!Isname)
            return "[" + Enum.ToString() + "] ";
        else
            return Enum.ToString();
     
    }
     public void AdderOutPut(Enum Enum, HandleProssesOutput ProssesOutput, Enum TabName)
    {

        ListOutPut.Add(Enum);
        ListProssessOutput.Add(Enum, ProssesOutput);
        ListoutPutNameTab.Add(  TabName);
    }
     /// <summary>
     /// لمجموعة من الشروط المتداخلة
     /// </summary>
     /// <param name="CondtionInOne">كلاس مورث من الأصل يحوي على شروط الداخلة</param>
     
     public void AdderOutPut(Enum Enum)
     {
         AdderOutPut(Enum, ProssesOutput ,null );
     }
     
     public void AdderOutPut(Enum Enum, Enum TabName)
     {
         AdderOutPut(Enum, ProssesOutput, TabName);
     }

     public string retOutPutAll()
     {
         string Out = "";
         for (int i = 0; i < ListOutPut.Count; i++)
         {
                          if ( ListoutPutNameTab[i] !=null)
                              Out += ListoutPutNameTab[i].ToString()+"."+ ListProssessOutput[ListOutPut[i]](ListOutPut[i]);
                          else
                              Out += ListProssessOutput[ListOutPut[i]](ListOutPut[i]);

             if (i != ListOutPut.Count - 1)
                 Out += " , ";

         }



         return Out;
     }
     public Enum retOutPut(int i)
     {
         return ListOutPut[i];

     }

     /// <summary>
     /// معالجة داخلية بدون معالجة
     /// </summary>
     /// <param name="object1">دخل نفسو الخرج</param>
     /// <returns></returns>
     protected object RetunObject(object object1)
     {
         return object1;
     }

     /// <summary>
     /// عدد البرامترات
     /// </summary>
     /// <returns></returns>
     public int CountPerammeters()
     {

         return ListObject.Count;

     }

     public int CountFiledOutput()
     {

         return ListOutPut.Count();

     }

     /// <summary>
     /// خرج اسم قاعدة اليبانات
     /// </summary>
     /// <param name="i">مكان في مصوفه </param>
     /// <returns>خرج اسم قاعدة</returns>
     public string RetEnum (int i)
     {
         if (ListProssessOutput.ContainsKey(ListEnum[i]))
             return ListProssessOutput[ListEnum[i]](ListEnum[i]);
         else
             return ProssesOutput((ListEnum[i]));


     }
     /// <summary>
     /// خرج القيمة بعد المعالجة
     /// </summary>
     /// <param name="i">مكان المصوفه</param>
     /// <returns>خرج قيمة بعد المعالجة</returns>
     public object RetObject ( int i )
     {

         return listCommandOutDataObject[i](ListObject[i]);
     }

     public Condtion RetCondetion(int i)
     {

         return ListCondetion[i];
     }
     public Between CondetionBetwen(int i)
     {

         return ListCondetionBetwen[i];
     }

     public string CommanderCondtion(int i)
     {

         string Condtion = "";
         if (ListCondetion[i] == ParamterrMakeSql.Condtion.Eqial)
             Condtion = " = ";
         else if (ListCondetion[i] == ParamterrMakeSql.Condtion.EqlessThen)
             Condtion = " <= ";
         else if (ListCondetion[i] == ParamterrMakeSql.Condtion.lessThen)
             Condtion = " < ";

         else if (ListCondetion[i] == ParamterrMakeSql.Condtion.EqMoreThen)
             Condtion = " >= ";

         else if (ListCondetion[i] == ParamterrMakeSql.Condtion.MoreThen)
             Condtion = " > ";

         else if (ListCondetion[i] == ParamterrMakeSql.Condtion.like)
             Condtion = " like ";

         else if (ListCondetion[i] == ParamterrMakeSql.Condtion.WhildCart)
             Condtion = "like ";

         else if (ListCondetion[i] == ParamterrMakeSql.Condtion.like)
             Condtion = " like ";

         else if (ListCondetion[i] == ParamterrMakeSql.Condtion.isnulldb)
             Condtion = " IS NULL ";

         string outx = ListProssesEnum[i](ListEnum[i], true);

         if (ListCondetion[i] != ParamterrMakeSql.Condtion.isnulldb)
         for (int j = i-1; j >=0 ; j--)
         {
             if (ListProssesEnum[i](ListEnum[i], true) == ListProssesEnum[j](ListEnum[j], true))
                 outx += "1";
         }

         string ce = "";
         if (ListCondetion[i] != ParamterrMakeSql.Condtion.isnulldb)
             ce = ListProssesEnum[i](ListEnum[i], false) + Condtion + "@" + outx;
         else
             ce = ListProssesEnum[i](ListEnum[i], false) + Condtion;


         return ce;
     }
     public string RetunPramter (int i )
     {

       return  Convert.ToString(this.ListObject[i]);
     }
    

      public string CommanderCondtionAll(System.Data.SqlClient.SqlCommand SqlAdder)
     {

         string all = "";
          for (int i = 0 ; i < ListEnum.Count ; i ++ )
          {
             
              all += CommanderCondtion(i);
              if (i != ListEnum.Count - 1)
                  all += " "+ ListCondetionBetwen[i].ToString() +" ";
              if (SqlAdder != null)
              {
                  if (ListCondetion[i] == ParamterrMakeSql.Condtion.WhildCart)
                  {
                      SqlAdder.Parameters.AddWithValue("@" + ListProssesEnum[i](ListEnum[i], true), "%" + RetObject(i) + "%");
                  }else
                  {
                      SqlAdder.Parameters.AddWithValue("@" + ListProssesEnum[i](ListEnum[i], true), RetObject(i));
                  }
              }
          }

          return all;


     }
           
    }

    public class EnumInnder 
    {
      public  Enum TabIner = null ;
      public  Enum FromTabSelect = null ;
      public  Enum FromFildSelect = null ;

      public Enum ToTabSelect = null ;
      public  Enum ToFildSelect = null ;
        public EnumInnder (    Enum TabIner  , Enum FromTabSelect  , Enum FromFildSelect ,    Enum ToTabSelect , Enum ToFildSelect)
        {
            this.TabIner = TabIner ;
            this.FromTabSelect = FromTabSelect;
            this.FromFildSelect = FromFildSelect;

            this.ToTabSelect = ToTabSelect;
            this.ToFildSelect = ToFildSelect;
        }

    }




}
