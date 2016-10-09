using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
 public   class MegBox
    {
     public static void Show (string Stri)
     {
         DevComponents.DotNetBar.MessageBoxEx.Show(Stri);

     }
     public static void Show(string Stri , System.Windows.Forms.Form F)
     {
         DevComponents.DotNetBar.MessageBoxEx.Show(F,Stri);

     }
    

    }
}
