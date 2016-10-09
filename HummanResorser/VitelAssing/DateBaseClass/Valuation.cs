using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace HummanResorser
{
 public class Valuation :DataBase
    {
        public int id { get; private set; }
        public int Id_Information { get; private set; }
        public string UsernameName { get; private set; }
        public int id_ValuationForm { get; private set; }
        public XDocument Xml { get; private set; }

        public DateTime datatime { get; private set; }

        public static List<Valuation> GetByIdVil(int idinformation)
        {
            List<Valuation> Lista = new List<Valuation>();

            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [id]  ,[Id_Information] ,[Id_Information_Write] ,[id_ValuationForm]  ,[XmlResult] ,[DateSave] FROM [HR_SARC].[dbo].[Valuation_ta] where [Id_Information] = "+ idinformation.ToString()));
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new Valuation(Convert.ToInt32(Adw[i][0]), Convert.ToInt32(Adw[i][1]), Convert.ToString(Adw[i][2]), Convert.ToInt32(Adw[i][3]), XDocument.Parse(Adw[i][4].ToString()), Convert.ToDateTime(Adw[i][5])));

            return Lista;


        }
        public Valuation (int id , int Id_Information , string UsernameName , int id_ValuationForm, XDocument Xml, DateTime datatime)
        {
            this.id = id;
            this.Id_Information = Id_Information;
            this.UsernameName = UsernameName;
            this.id_ValuationForm = id_ValuationForm;
            this.Xml = Xml;
            this.datatime = datatime;

        }
        public float GetResut()
        {
            XElement Resuit1 = Xml.Root.Element("Resuit") ;
            List<XElement>   Resuit =  Resuit1.Elements().ToList();
            List <ValuationForm> mark = ValuationForm.GetAllbyIdValuationname(this.id_ValuationForm);
            float AllMark = 0;
            float Mark = 0;
            for (int i = 0; i < Resuit.Count; i++)
            {
                AllMark += (Convert.ToSingle( Resuit[i].Value) * (mark[i].mark / 100f));
                Mark += (mark[i].mark / 100f);
            }

            AllMark /= Mark;
            return AllMark;
        }
        public SqlCommand updata()
        {
            throw new NotImplementedException();
        }

        public SqlCommand adder()
        {
            SqlCommand SqlCommand1 = new SqlCommand("INSERT INTO [dbo].[Valuation_ta]([Id_Information],[Id_Information_Write],[id_ValuationForm],[XmlResult],[DateSave],[Delete])VALUES(@Id_Information,@Id_Information_Write,@id_ValuationForm,@XmlResult,@DateSave,@Delete)");

            SqlParameter param = new SqlParameter("@XmlResult", SqlDbType.Xml);
            param.Value = new SqlXml(new XmlTextReader(Xml.Root.ToString(), XmlNodeType.Document, null));
            SqlCommand1.Parameters.Add(param);

            SqlCommand1.Parameters.AddWithValue("Id_Information", this.Id_Information);
            SqlCommand1.Parameters.AddWithValue("id_ValuationForm", this.id_ValuationForm);
            SqlCommand1.Parameters.AddWithValue("Id_Information_Write", this.UsernameName);
            SqlCommand1.Parameters.AddWithValue("DateSave", this.datatime);
            SqlCommand1.Parameters.AddWithValue("Delete", false);
            return SqlCommand1;



        }

        public SqlCommand Delete()
        {
            throw new NotImplementedException();
        }
    }
}
