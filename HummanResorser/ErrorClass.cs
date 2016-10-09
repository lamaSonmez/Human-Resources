using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HummanResorser
{
    public class ErrorClass
    {
        public static void SaveErrorFile(Exception e , bool JustShowMessg = false)
        {
            if (!JustShowMessg)
            System.Windows.MessageBox.Show(e.ToString());
            else
                System.Windows.MessageBox.Show(e.Message);
     
        }

        public static void ErrorClassConvert(Exception e)
        {
           
        }
    }
}
