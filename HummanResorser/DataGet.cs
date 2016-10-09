using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HummanResorser
{
    public abstract class DataGet : DataBase
    {


        public abstract System.Data.SqlClient.SqlCommand updata();

        public abstract System.Data.SqlClient.SqlCommand adder();

        public abstract System.Data.SqlClient.SqlCommand Delete();

        /// <summary>
        /// أمر بحث عن طريق ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract System.Data.SqlClient.SqlCommand GetFromId(int id);

    }




}
