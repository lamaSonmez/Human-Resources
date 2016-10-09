using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar.Controls;

namespace HummanResorser
{
    [Serializable()]
  public class NoColumnsException : Exception
    {
        public NoColumnsException(String Ex): base(Ex)
      {
      }

    }
    public class ClassDataGridViewDo 
    {
       
        public static void ClumChekArray (string[] Array,DevComponents.DotNetBar.Controls.DataGridViewX Date)
        {
            foreach (string item in Array)
            {
                if (!Date.Columns.Contains(item))
                    throw new NoColumnsException(item);
            }



        }

        internal static void DataGridEnterGridTovilation(object v)
        {
            throw new NotImplementedException();
        }

        internal static void DataGridEnterGridAllValutionename(DataGridViewX dataGridViewX1, List<Valuationname> valuationnamelist)
        {
            dataGridViewX1.Rows.Clear();
            foreach (Valuationname item in valuationnamelist)
            {
                dataGridViewX1.Rows.Add(item.id
                    , item.Name,
                    Valuationname.ValuationnameTypeInt[item.Type]);

            }
        }

        public static void DataGridEnterGridSerc(DataGridViewX dataGridViewX1, Vitl vitl, List<Team> list)
        {
         
            string Team1 = "";
            foreach (Team item in list)
            {
                Team1 += " + " +item.RetunNameString();
            }
            if (Team1.Length != 0)
                Team1 = Team1.Remove(0, 2);

            dataGridViewX1.Rows.Add(vitl.id, vitl.first_name + " " + vitl.Last_name, Team1);

        }

        internal static void DataGridEnterGridQustion(DataGridViewX dataGridViewX1, List<Qustiones> qustioneslist)
        {
            dataGridViewX1.Rows.Clear();
            foreach (Qustiones item in qustioneslist)
            {
                dataGridViewX1.Rows.Add(item.id, item.name);
            }
        }

        public static void DataGridViewShow1Show(DevComponents.DotNetBar.Controls.DataGridViewX DataGridViewX1, List<object> objectlist1)
        {
            int i = 0;

            for (int c = 0; DataGridViewX1.Rows.Count > c; c++  )
                if (Convert.ToInt32(DataGridViewX1.Rows[c].Cells[0].Value)== Convert.ToInt32( objectlist1[0]))
                            goto end;

               
                    DataGridViewX1.Rows.Add(objectlist1[i].ToString(), objectlist1[++i].ToString(), ClassConvert.Convint64(objectlist1[++i]), objectlist1[++i].ToString(), objectlist1[++i].ToString(), objectlist1[++i].ToString(), objectlist1[++i].ToString(), objectlist1[++i].ToString());
                
            end: ;
        }

        internal static void DataGridEnterAsncyGrAllname(DataGridViewX dataGridViewX1, List<vitelAssingInformation> alldatesee)
        {
            foreach (vitelAssingInformation item in alldatesee)
            {
                dataGridViewX1.Rows.Add(item.GetidInformation(), Vitl.VitlIdAndName(item.GetidInformation()).Name, item.GetResut());

            }
           
        }

        internal static void DataGridEnterAsncyGrAllname(DataGridViewX dataGridViewX1, vitelAssingInformation alldatesee)
        {

            for (int i = 0; i < alldatesee.count; i++)
            {


                dataGridViewX1.Rows.Add(Qustiones.Qustioneslist[RetunIndexByIdSech(alldatesee.retuIdQustion(i),Qustiones.Qustioneslist)].name, alldatesee.retuResuit(i));
            }

            

        }

        /// <summary>
        /// إضافة أي عنصر رث من واجه IaddName
        /// </summary>
        /// <param name="DataGridViewButtonXColumn1">عنصر المراد إضافة القائمه منه</param>
        /// <param name="Liststring"></param>
        public static void DataGridAddVuleComBoxEx<T>(DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn DataGridViewComboBoxExColumnAdder, List<T> Genric)
        {
            DataGridViewComboBoxExColumnAdder.Items.Clear();
            if (Genric.GetType().ToString() != "System.Collections.Generic.List`1[System.String]")
            {

                foreach (IaddName strin in Genric)

                    DataGridViewComboBoxExColumnAdder.Items.Add(strin.RetunNameString());
            }
            else
            {
                for (int i = 0; i < Genric.Count; i++)
                {

                    DataGridViewComboBoxExColumnAdder.Items.Add(Genric[i].ToString());
                }
            }
        }
        /// <summary>
        /// إضافة أي عنصر رث من واجه IaddName
        /// </summary>
        /// <param name="ComboBoxEx">عنصر المراد إضافة القائمه منه</param>
        /// <param name="Liststring"></param>
        public static void DataGridAddVuleComBoxEx<T>(DevComponents.DotNetBar.Controls.ComboBoxEx ComboBoxEx, List<T> Genric)
        {
            ComboBoxEx.Items.Clear();
            if (Genric.GetType().ToString() != "System.Collections.Generic.List`1[System.String]")
            {
                foreach (IaddName strin in Genric)

                    ComboBoxEx.Items.Add(strin.RetunNameString());
            }
            else
            {
                for (int i = 0; i < Genric.Count; i++)
                { ComboBoxEx.Items.Add(Genric[i].ToString()); }
            }
        }
        /// <summary>
        /// معالجة الكلاسين أنوع و أسماء الفرق
        /// </summary>
        /// <param name="DataGridViewComboBoxExColumnAdder">متغير المراد إضافة القائمه</param>
        /// <param name="mo">أنواع الفرق</param>
        /// <param name="mo1">أسماء الفرق</param>
        public static void DataGridAddVuleComBoxEx(DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn DataGridViewComboBoxExColumnAdder, List<NameTeamType> mo, List<NameTeam> mo1)
        {
            var fe = from s in mo1
                     join e in mo
                    on s.NameTeamType_Id equals e.id 
                     select new { e.TypeOfTeam, s.nameOftame };
          
            foreach (var strin in fe)
                DataGridViewComboBoxExColumnAdder.Items.Add(strin.TypeOfTeam + " - " + strin.nameOftame);

        }
        public static void DataGridEnterGridToWorkCorser(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<Couress> TeamClassList )
        {

            Grid.Rows.Clear();
            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn id_NameOfCouress = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["id_NameOfCouress"];
            
            for (int i = 0; i < TeamClassList.Count; i++)
                Grid.Rows.Add(TeamClassList[i].id, id_NameOfCouress.Items[RetunIndexByIdSech(TeamClassList[i].id_NameOfCouress, NameOfCouress.NameOfCouresslist)], TeamClassList[i].NumberOfdayregest, TeamClassList[i].Result);

        }

        internal static void DataGridEndtrToCv(DataGridViewX dataGridViewX1, List<CV_Info> cvListAfter)
        {
      
        }

        public static void DataGridEnterGridToWorkNameOfCouress_ta(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<Couress> TeamClassList , List<IdAndName> nameInfrma )
        {

            Grid.Rows.Clear();
            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn id_NameOfCouress = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["id_NameOfCouress"];

            for (int i = 0; i < TeamClassList.Count; i++)
            {
                if (!nameInfrma[i].DeleatOrErrorId)
                Grid.Rows.Add(TeamClassList[i].id, nameInfrma[i].Name, TeamClassList[i].NumberOfdayregest, TeamClassList[i].Result);
            }
        }
        public static void DataGridEnterGridToWorkNameOfCouress_ta(DevComponents.DotNetBar.Controls.DataGridViewX Grid, Couress TeamClassList, IdAndName nameInfrma)
        {


            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn id_NameOfCouress = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["id_NameOfCouress"];

            Grid.Rows.Add(TeamClassList.id,  nameInfrma.Name, TeamClassList.NumberOfdayregest, TeamClassList.Result);

        }
        public static void DataGridEnterGridToWorkNameOfCouress_ta(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<NameOfCouress> TeamClassList)
        {

            Grid.Rows.Clear();
            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn Id_TypeofCouress_ta = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["Id_TypeofCouress_ta"];

            for (int i = 0; i < TeamClassList.Count; i++)
                Grid.Rows.Add(TeamClassList[i].id, TeamClassList[i].dataStart.ToShortDateString(), TeamClassList[i].DataENd.ToShortDateString(), TeamClassList[i].Suport == true ? "مدعومة" : " غير مدعومة ", Id_TypeofCouress_ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList)], TeamClassList[i].Decrption, TeamClassList[i].IntCoures);

        }
        public static void DataGridEnterGridToWorkTeam(DevComponents.DotNetBar.Controls.DataGridViewX Grid , List<Team > TeamClassList )
        {
            
            Grid.Rows.Clear();
            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn TeamJop = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["TeamJop"];
            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn TeamTeam = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["TeamTeam"];
            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn TeamStatus = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["TeamStatus"];

                  for ( int i = 0 ; i < TeamClassList.Count ; i ++ )
                  {
                    
                    
                         Grid.Rows.Add(TeamClassList[i].id, TeamJop.Items[RetunIndexByIdSech(TeamClassList[i].Id_Jop_Ta, Jop.JopStatic)], TeamTeam.Items[RetunIndexByIdSech(TeamClassList[i].id_NameTeam_Ta, NameTeam.NameTeamStatic)], TeamClassList[i].date_Start, TeamClassList[i].Date_End, TeamStatus.Items[TeamClassList[i].Setewation]);

                     }

        }
        public static void DataGridEnterGridToWorkTeam(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<Team> TeamClassList, List<IdAndName> nameInfrma)
        {

            Grid.Rows.Clear();
            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn Id_Jop_Ta = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["Id_Jop_Ta"];
            DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn Setewation = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["Setewation"];
            ///Id_Jop_Ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList)]
            for (int i = 0; i < TeamClassList.Count; i++)
                Grid.Rows.Add(TeamClassList[i].id, nameInfrma[i].Name, ClassConvert.ConvertTostringDateOrNull(TeamClassList[i].date_Start), ClassConvert.ConvertTostringDateOrNull(TeamClassList[i].Date_End), Id_Jop_Ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_Jop_Ta, Jop.JopStatic)], Setewation.Items[TeamClassList[i].Setewation]);

        }
        /// <summary>
        /// هاد شغلتو أنو يرجع قيمة للـ 
        /// index 
        /// المصفوفه list
        /// عن طريق بحث من ID
        /// بشرط أنو يكون يرث من 
        /// IaddName
        /// 
        /// </summary>
        /// <typeparam name="T">كلاس مصفوفه ترث من Iddname</typeparam>
        /// <param name="SechId">بحث عن طريق ID 
        /// قاعدة بيانات
        /// </param>
        /// <param name="MyClaasss">مصفوفه من Class 
        /// مخزن فيها الأنواع
        /// </param>
        /// <returns>Index 
        /// داخل المصفوفه
        /// </returns>
        public static int RetunIndexByIdSech<T> ( int SechId , List<T> MyClaasss)
        {
             
            
             for (int i =0  ;  i < MyClaasss.Count ; i++ )
             {
               IaddName IaddName1 = (IaddName)MyClaasss[i];
               if (IaddName1.RetunIdNumber() == SechId)
                   return i; 
             }
             return -1;

        }
        public static void DataGridEnterGridToWorkNameTeam_Ta(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<NameTeam> TeamClassList)
         {

             Grid.Rows.Clear();
             DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn Id_TypeofCouress_ta = (DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn)Grid.Columns["NameTeamType_Id"];

             ///Id_TypeofCouress_ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList)]
             for (int i = 0; i < TeamClassList.Count; i++)
                 Grid.Rows.Add(TeamClassList[i].id, TeamClassList[i].nameOftame, Id_TypeofCouress_ta.Items[RetunIndexByIdSech(TeamClassList[i].NameTeamType_Id, NameTeamType.NameTeamTypeStatic)]);

         }
        public static void DataGridEnterGridFornameTeamOption(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<NameTeam> TeamClassList)
         {

             Grid.Rows.Clear();


             ///Id_TypeofCouress_ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList)]
             for (int i = 0; i < TeamClassList.Count; i++)
                 Grid.Rows.Add(TeamClassList[i].id, TeamClassList[i].nameOftame, NameTeamType.NameTeamTypeStatic[RetunIndexByIdSech(TeamClassList[i].NameTeamType_Id, NameTeamType.NameTeamTypeStatic)].TypeOfTeam);

         }
        public static void DataGridEnterGridForJopOption(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<Jop> TypeofCouress)
         {

             Grid.Rows.Clear();


             ///Id_TypeofCouress_ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList)]
             for (int i = 0; i < TypeofCouress.Count; i++)
                 Grid.Rows.Add(TypeofCouress[i].id, TypeofCouress[i].NvacherWord, TypeofCouress[i].NvacherWordEng);

         }
        public static void DataGridEnterGridForTypeofCouressOption(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<TypeofCouress> TypeofCouress)
         {

             Grid.Rows.Clear();


             ///Id_TypeofCouress_ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList)]
             for (int i = 0; i < TypeofCouress.Count; i++)
                 Grid.Rows.Add(TypeofCouress[i].id, TypeofCouress[i].NameOfCouress);

         }
        public static void DataGridEnterGridForWereTypeOption(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<WereType> TypeofCouress)
        {

            Grid.Rows.Clear();


            ///Id_TypeofCouress_ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList)]
            for (int i = 0; i < TypeofCouress.Count; i++)
                Grid.Rows.Add(TypeofCouress[i].id, TypeofCouress[i].WareName, TypeofCouress[i].descrption);

        }
        public static void DataGridEnterGridFornameTeamTypeOption(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<NameTeamType> TeamClassList)
         {

             Grid.Rows.Clear();
           
             for (int i = 0; i < TeamClassList.Count; i++)
                 Grid.Rows.Add(TeamClassList[i].id, TeamClassList[i].TypeOfTeam);

         }

        public static void DataGridEnterGridToWorkValuation(DataGridViewX dataGridViewX4, List<Valuation> valuationList)
        {
            dataGridViewX4.Rows.Clear();

            for (int i = 0; i < valuationList.Count; i++)
                dataGridViewX4.Rows.Add(valuationList[i].id, valuationList[i].UsernameName , valuationList[i].datatime.ToShortDateString()  , valuationList[i].GetResut().ToString());
        }

        /// <summary>
        /// للبحث في قواعد SQL
        /// </summary>
        /// <param name="Text">الكلام المراد بحثة في القاعدة</param>
        ///<param name="TrimAll"> تفعيل إزالة الفرغات الزائدة</param>
        /// <returns>إرجاع النص</returns>
        public static string LograthemChangEverAleffToAll(string Text , bool TrimAll =false )
         {
            if ( TrimAll)
               Text = Trimall(Text);

            
             //  Text.Split ( "أ")
             string output = "";
             char[] char1 = { 'أ', 'ا', 'إ', 'آ' };
             string Repals = "[أاإآ]";
             char[] char2 = { 'ة', 'ه' };
             string Repals1 = "[هة]";

             string[] Opreation = Text.Split(' ');
             foreach (string Ope in Opreation)
             {
                 string temp = "";

                 for (int i = 0; i < Ope.Length; i++)
                 {
                     foreach (char charx in char1)
                         if (Ope[i] == charx)
                         {
                             temp += (string)Repals;
                             goto good;
                         }

                     temp += Convert.ToString(Ope[i]);

                 good: ;
                 }
                 if (!string.IsNullOrEmpty(temp))
                 {
                     if (temp[temp.Length - 1] == char2[0] || temp[temp.Length - 1] == char2[1])
                     {
                         temp = temp.Remove(temp.Length - 1, 1);
                         temp += Repals1;
                     }

                 }
                 output += temp + " ";
             }
             output = output.TrimEnd();
             return output;
         }
        /// <summary>
        /// لإزالة الفرغات 
        /// </summary>
        /// <param name="Text">الكلام لإزالة الفرغان</param>
        /// <returns>نص المراد إزالة الفرغات الزائدة</returns>
        public static string Trimall(string Text)
        {
            string text = Text.Trim();

            string[] str = text.Split(Convert.ToChar(System.Windows.Forms.Keys.Space));
            text = "";
            for (int i = 0; i < str.Length; i++)
                if (!string.IsNullOrEmpty(str[i]))
                    text += str[i] + " ";
            text = text.Trim();

            return text;
        }
        public static async void DataGridEnterGridForCV_InfoCV(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<CV_Info> TeamClassList)
        {
            Grid.BeginInvoke((Action)(() => { Grid.Rows.Clear(); 


            ///Id_TypeofCouress_ta.Items[RetunIndexByIdSech(TeamClassList[i].Id_TypeofCouress_ta, TypeofCouress.TypeofCouressList)]

    for (int i = 0; i < TeamClassList.Count; i++)
        //     try
        //    {
        Grid.Rows.Add(
             TeamClassList[i].id,
             TeamClassList[i].FullName,
             TeamClassList[i].Notes,
             TeamClassList[i].GetCodeArch(),
             TeamClassList[i].Id_Study != -1 ? CV_Study.CV_StudyList[ClassDataGridViewDo.RetunIndexByIdSech(TeamClassList[i].Id_Study, CV_Study.CV_StudyList)].Sutdy : "",
             ClassConvert.ConvNumberCombyereToString(TeamClassList[i].Year_sutr),
             TeamClassList[i].Numberphone,
             TeamClassList[i].Date != null ? TeamClassList[i].Date.Value.ToShortDateString() : "",
              TeamClassList[i].ID_TemaNeed != -1 ? CvTeamNeed.CvTeamNeedList[ClassDataGridViewDo.RetunIndexByIdSech(TeamClassList[i].ID_TemaNeed, CvTeamNeed.CvTeamNeedList)].FullName : "",
              TeamClassList[i].Bit);

                
                          }));
          
            //     }
            //    catch( Exception e )
            //       { ErrorClass.SaveErrorFile(e); }
        }
        public static void DataGridEnterGridForFillScil(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<Scileis> TeamClassList)
        {            Grid.Rows.Clear();
                     for (int i = 0; i < TeamClassList.Count; i++)
                     {
                         Grid.Rows.Add(
                             TeamClassList[i].id,
                             TeamClassList[i].NameScil


                            );


                     }
        }
        public static void DataGridEnterGridHaveSsciles(DevComponents.DotNetBar.Controls.DataGridViewX Grid, List<HaveScil> TeamClassList)
        {
            Grid.Rows.Clear();
            for (int i = 0; i < TeamClassList.Count; i++)
            {
                Grid.Rows.Add(
                    TeamClassList[i].id,
                Scileis.ScileislList[ RetunIndexByIdSech(  TeamClassList[i].Scileis_ID,Scileis.ScileislList)].NameScil,
                TeamClassList[i].Star.ToString()


                   );


            }
        }
        public static void DataGridEnterGridForGetdateByID(DevComponents.DotNetBar.Controls.DataGridViewX Grid, Vitl vitl, List<Team> Teamlest, List<Couress> coureslist)
        {

            string listtamestring = "";
            string listtcoures = "";

            foreach (Team item in Teamlest)
                listtamestring += " + "+NameTeam.NameTeamStatic[ClassDataGridViewDo.RetunIndexByIdSech(item.id_NameTeam_Ta, NameTeam.NameTeamStatic)].nameOftame;

            foreach (Couress item in coureslist)
                listtcoures += " + " + NameOfCouress.NameOfCouresslist[ClassDataGridViewDo.RetunIndexByIdSech(item.id_NameOfCouress, NameOfCouress.NameOfCouresslist)].Decrption;


            if (coureslist.Count != 0)
                listtcoures = listtcoures.Remove(0, 2);

            if (Teamlest.Count != 0)
                listtamestring = listtamestring.Remove(0, 2);

                Grid.Rows.Add(
                    vitl.id.ToString()
                , ClassConvert.ConvNonullTostring(vitl.first_name )+ " " + ClassConvert.ConvNonullTostring(vitl.Last_name)
                , ClassConvert.ConvNonullTostring(vitl.first_name)
                , ClassConvert.ConvNonullTostring(vitl.Last_name)
                , ClassConvert.ConvNonullTostring(vitl.Father_name)
                , ClassConvert.ConvNonullTostring(vitl.Mather_name)
                , ClassConvert.ConvNonullTostring(ClassConvert.ConvToIdNational(vitl.natiol_id))
                , vitl.Gender == false ? "ذكر" : vitl.Gender == true ? "إنثى" : ""
                , ClassConvert.ConvNonullTostring(vitl.where_birth)
                , vitl.data_barthday.ToShortDateString()
                , ClassConvert.ConvNonullTostring(vitl.Hanei_whare)
                , ClassConvert.ConvNonullTostring(vitl.Hanei_whare1)
                , ClassConvert.ConvNonullTostring(vitl.adderas)
                , ClassConvert.ConvNonullTostring(vitl.e_mail)
                , ClassConvert.Stutes_Jtma3Tostring(vitl.Stutes_Jtma3, vitl.Gender)
                , vitl.Phone_Ground.ToString()
                , vitl.Phone_Mobile1.ToString()
                , vitl.Phone_Mobile2.ToString()
                , ClassConvert.ConvNonullTostring(vitl.Facebook)
                , ClassConvert.ConvNonullTostring(vitl.Twiter)
                , vitl.whatsApp.ToString()
                , vitl.viper.ToString()
                , ClassConvert.ConvNonullTostring(vitl.study)
                , ClassConvert.yearstudyToString(vitl.yearstudy)
                , vitl.Id_course.ToString()
                , ClassConvert.ConvNonullTostring(vitl.Id_course_Ware)
                , vitl.data_regs.ToShortDateString()
                , ClassConvert.ConvStringBoloed(vitl.Boold_id)
                , ClassConvert.ConvNonullTostring(vitl.Nkname)
                , ClassConvert.ConvNonullTostring(vitl.nameEnglish)
                , ClassConvert.ConvSizeToString(vitl.Z1)
                , vitl.z2.ToString()
                , ClassConvert.ConvSizeToString(vitl.z3)
                , listtamestring
                , listtcoures
                );
           
        }
        public static void DataGridEnterAsncyGetInformation(DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1, List<AsncyGetInformation> AsncyGetInformation)
        {
            dataGridViewX1.Rows.Clear();
            for (int i = 0; i < AsncyGetInformation.Count; i++)
            {
                dataGridViewX1.Rows.Add(
               AsncyGetInformation[i].id .ToString() ,
               AsncyGetInformation[i].nameusername
               , AsncyGetInformation[i].End


                   );


            }
        }
        public static void DataGridEnterGridToWorkWereDelivery(DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX3, List<WereDelivery> WereDeliveryList)
        {
            dataGridViewX3.Rows.Clear();
            for (int i = 0; i < WereDeliveryList.Count; i++)
            {
                dataGridViewX3.Rows.Add(
               WereDeliveryList[i].id.ToString()  ,
            WereType.WereTypeList[ RetunIndexByIdSech( WereDeliveryList[i].Id_WereType,  WereType.WereTypeList) ].RetunNameString()
            , WereDeliveryList[i].dateDeliveryitem == null ? "" : WereDeliveryList[i].dateDeliveryitem.Value.ToShortDateString()
            , WereDeliveryList[i].DateBackitem == null ? "" : WereDeliveryList[i].dateDeliveryitem.Value.ToShortDateString()
            , WereDeliveryList[i].Notes 
                   );


            }
        }
    }
     
    
   
}
