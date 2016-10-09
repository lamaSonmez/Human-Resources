using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    /// <summary>
    /// حفظ معلومات المزامنة
    /// حيث يجلب هل هناك تقيمات تمت أم لا
    /// </summary>
   public class AsncyGetInformation
    {
        public int id
        {
            get;
            private set;
        }
        public string nameusername
        {
            get;
            private set;
        }
        public bool End
        {
            get;
            private set;
        }

        public AsncyGetInformation(int id, string nameusername, bool End)
        {
            this.id = id;
            this.nameusername = nameusername;
            this.End = End;
           
        }

    }
}
