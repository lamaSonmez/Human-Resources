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
    public class WereType : DataBase , IaddName
    {
        public static List<WereType> WereTypeList = new List<WereType>();

        
        public WereType(int id, string WareName, string descrption)
        {
            // TODO: Complete WereType initialization
            this.id = id;
            this.WareName = WareName;
            this.descrption = descrption;
        }
        /// <summary>
        /// أسم المادة
        /// </summary>
        public int id
        {
            get;
            private set;
        }

        /// <summary>
        /// أسم المادة
        /// </summary>
        public string WareName
        {
            get;
           private set;
        }

        /// <summary>
        /// وصف الماده
        /// </summary>
        public string descrption
        {
            get;
            private set;
        }
    
public System.Data.SqlClient.SqlCommand updata()
{

    System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand(" UPDATE [dbo].[WereType_ta] SET [WareName] = @WareName,[descrption] = @descrption   WHERE id =@id");
    SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("id", this.id));
    SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("WareName", this.WareName));
    SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("descrption", this.descrption));

    return SqlCommand1;
}

public System.Data.SqlClient.SqlCommand adder()
{

    System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand("INSERT INTO [dbo].[WereType_ta] ([WareName]  ,[descrption] ,[Delete])  VALUES (@WareName,@descrption , @Delete)");
    SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("WareName", this.WareName));
    SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("descrption", this.descrption));
    SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("Delete", false));
    return SqlCommand1;
}
       
public System.Data.SqlClient.SqlCommand Delete()
{
    System.Data.SqlClient.SqlCommand SqlCommand1 = new System.Data.SqlClient.SqlCommand(" UPDATE [dbo].[WereType_ta] SET [Delete] = 1   WHERE id =@id");
   

    return SqlCommand1;
}



public static List<WereType> GetAll()
{

    List<WereType> Lista = new List<WereType>();

    Task<List<List<object>>> temp = Sqldatabasethrding.GetSql(new System.Data.SqlClient.SqlCommand("SELECT [Id],[WareName],[descrption] FROM [HR_SARC].[dbo].[WereType_ta] where [Delete] = 0 "));
    while (!temp.IsCompleted)
    { }

    List<List<object>> Adw = temp.Result;

    for (int i = 0; i < Adw.Count; i++)
        if (Adw[i].Count != 0)
            Lista.Add(new WereType(Convert.ToInt32(Adw[i][0]), Convert.ToString(Adw[i][1]), Convert.ToString(Adw[i][2])));

    return Lista;
}


         public string RetunNameString()
        {
            return this.WareName + " " + this.descrption;
        }
              public int RetunIdNumber()
        {
            return id;
        }

    }
   
   

}
