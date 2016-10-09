using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HummanResorser
{
    /// <summary>
    /// الشكل الإساسي لتعديل و إضافة و الحذف
    /// </summary>
    /// <remarks>الشكل الإساسي لتعديل و إضافة و الحذف</remarks>
    public interface DataBase
    {




        System.Data.SqlClient.SqlCommand updata();
      
        System.Data.SqlClient.SqlCommand adder();

        System.Data.SqlClient.SqlCommand Delete();


    }
 
}
