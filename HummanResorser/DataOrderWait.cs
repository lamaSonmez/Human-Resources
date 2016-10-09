using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
namespace HummanResorser
{
    public partial class DataOrderWait : DevComponents.DotNetBar.RibbonForm
    {
        public static string sqlconction = "Data Source=SARC-1-HP\\M1992;Initial Catalog=HR_SARC;Integrated Security=True"; 
        public static SqlConnection SqlConnection1 = new SqlConnection();
        public List<Vitl> Vitl1;
        private static System.Threading.CancellationToken CancellationToken1 = new System.Threading.CancellationToken();
        /// <summary>
        /// فتح و تأكيد إتصال
        /// </summary>
        public static void OpenConction ()
        {
           
           if (SqlConnection1.State != System.Data.ConnectionState.Open)
           {
               SqlConnection1.ConnectionString = sqlconction;
               try
               {
                   SqlConnection1.OpenAsync(CancellationToken1);
                   while (SqlConnection1.State!= System.Data.ConnectionState.Open) { }
                  
               
               } catch(Exception e)
               {
                   MessageBoxEx.Show(e.ToString());
               
               }

           }


        }

        public DataOrderWait()
        {
            InitializeComponent();
           
        }


      
    }

}
