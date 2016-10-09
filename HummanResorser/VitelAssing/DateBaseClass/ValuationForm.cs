using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    class ValuationForm : DataBase
    {
        public int id { get; private set; }

        public int id_Valuationname_Ta { get;  set; }
        public int id_qustion { get; private set; }
        public int mark { get; private set; }

        public ValuationForm(int id, int id_Valuationname_Ta, int id_qustion, int mark)
        {
            this.id = id;
            this.id_Valuationname_Ta = id_Valuationname_Ta;
            this.id_qustion = id_qustion;
            this.mark = mark;


        }
        public static List<ValuationForm> GetAllbyIdValuationname ( int id )
        {

            List<ValuationForm> Lista = new List<ValuationForm>();

            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [id],[id_Valuationname_Ta],[id_qustion] ,[mark] ,[Delete] FROM [HR_SARC].[dbo].[ValuationForm] where [Delete] = 0 and  [id_Valuationname_Ta] = " + id.ToString()));
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new ValuationForm(Convert.ToInt32(Adw[i][0]), Convert.ToInt32(Adw[i][1]), Convert.ToInt32(Adw[i][2]) , Convert.ToInt32(Adw[i][3])));

            return Lista;

        }


       public SqlCommand adder()
        {
            System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[ValuationForm] ([id_Valuationname_Ta] ,[id_qustion] ,[mark] ,[Delete]) VALUES(@id_Valuationname_Ta,@id_qustion ,@mark,@Delete)");
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id_Valuationname_Ta", id_Valuationname_Ta));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id_qustion", id_qustion));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("mark", mark));
            SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));
            return SqlCommand1;
        }

        public SqlCommand Delete()
        {
            throw new NotImplementedException();
        }

        public SqlCommand updata()
        {
            throw new NotImplementedException();
        }
    }
}
