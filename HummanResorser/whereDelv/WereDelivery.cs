using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
    /// <summary>
    /// Main
    /// </summary>
    /// <remarks>إستلامات</remarks>
    public class WereDelivery : DataBase ,IaddName
    {


        public WereDelivery ( int id , int Id_WereType , DateTime? dateDeliveryitem , int id_Information , DateTime? DateBackitem , string Notes)
        {
            this.id = id;
            this.Id_WereType =Id_WereType;
            this.dateDeliveryitem  =dateDeliveryitem ;
            this.id_Information  = id_Information;
            this.DateBackitem=DateBackitem;
            this.Notes = Notes;

        }
        /// <summary>
        /// مادة ID
        /// </summary>
        public int Id_WereType
        {
            get;
            private set;
        }

        /// <summary>
        /// id
        /// </summary>
        public int id
        {
            get;
            private set;
        }

        /// <summary>
        /// تاريخ التسليم
        /// </summary>
        public DateTime? dateDeliveryitem
        {
            get;
            private set;
        }

        /// <summary>
        /// ID معلومات الأساسية
        /// </summary>
        public int id_Information
        {
            get;
            private set;
        }


        /// <summary>
        /// تاريخ الاستعاده
        /// </summary>
        public DateTime? DateBackitem
        {
            get;
            private set;
        }

        /// <summary>
        /// ملاحظات
        /// </summary>
        public string Notes
        {
            get;
            private set;
        }

        public static List<WereDelivery> GetByIdVil(int id)
        {

            List<WereDelivery> Lista = new List<WereDelivery>();
            System.Data.SqlClient.SqlCommand SqlComm = new System.Data.SqlClient.SqlCommand("select [id],[Id_WereType] ,[dateDeliveryitem] ,[id_Information],[DateBackitem],[Notes] FROM [HR_SARC].[dbo].[WereDelivery_ta] where  [id_Information] = @id and [Delete] = 0");
            SqlComm.Parameters.AddWithValue("@id", id);
            Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(SqlComm);
            while (!temp.IsCompleted)
            { }

            List<List<object>> Adw = temp.Result;

            for (int i = 0; i < Adw.Count; i++)
                if (Adw[i].Count != 0)
                    Lista.Add(new WereDelivery(Convert.ToInt32(Adw[i][0]), Convert.ToInt32(Adw[i][1]), ClassConvert.ConvDateTimeNull(Adw[i][2]), Convert.ToInt32(Adw[i][3]), ClassConvert.ConvDateTimeNull(Adw[i][4]), Convert.ToString(Adw[i][5])));

            return Lista;



        }



        public System.Data.SqlClient.SqlCommand updata()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[WereDelivery_ta] SET [Id_WereType] = @Id_WereType,[dateDeliveryitem] = @dateDeliveryitem , [id_Information] =@id_Information , [DateBackitem] =@DateBackitem ,[Notes] = @Notes WHERE id = @id");
            Sqlcom.Parameters.AddWithValue("id", this.id);
            Sqlcom.Parameters.AddWithValue("Id_WereType", this.Id_WereType);
            Sqlcom.Parameters.AddWithValue("dateDeliveryitem", this.dateDeliveryitem);
            Sqlcom.Parameters.AddWithValue("id_Information", this.id_Information);
            Sqlcom.Parameters.AddWithValue("DateBackitem", this.DateBackitem);
            Sqlcom.Parameters.AddWithValue("Notes", this.Notes);
            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand adder()
        {

            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[WereDelivery_ta]([Id_WereType],[dateDeliveryitem] ,[id_Information] ,[DateBackitem] ,[Notes] ,[Delete])VALUES(@Id_WereType,@dateDeliveryitem,@id_Information  ,@DateBackitem,@Notes,@Delete)");
            Sqlcom.Parameters.AddWithValue("id", this.id);
            Sqlcom.Parameters.AddWithValue("Id_WereType", this.Id_WereType);
            if (dateDeliveryitem != null)
            Sqlcom.Parameters.AddWithValue("dateDeliveryitem", this.dateDeliveryitem);
            else
                Sqlcom.Parameters.AddWithValue("dateDeliveryitem", DBNull.Value);

            Sqlcom.Parameters.AddWithValue("id_Information", this.id_Information);
            if (DateBackitem != null)
            Sqlcom.Parameters.AddWithValue("DateBackitem", this.DateBackitem);
            else
                Sqlcom.Parameters.AddWithValue("DateBackitem", DBNull.Value);

            Sqlcom.Parameters.AddWithValue("Notes", this.Notes);
            Sqlcom.Parameters.AddWithValue("Delete", false);
            return Sqlcom;
        }

        public System.Data.SqlClient.SqlCommand Delete()
        {
            System.Data.SqlClient.SqlCommand Sqlcom = new System.Data.SqlClient.SqlCommand("UPDATE [dbo].[Jop_Ta] SET [Delete] = 1 WHERE id = @id");
            Sqlcom.Parameters.AddWithValue("id", this.id);

            return Sqlcom;
        }

        public string RetunNameString()
        {
            return this.Notes;
        }

        public int RetunIdNumber()
        {
            return id;
        }
    }
}
