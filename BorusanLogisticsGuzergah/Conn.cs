using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorusanLogisticsGuzergah
{
    public class Conn
    {
        public static SqlConnection dbLocal = new SqlConnection();
        public static string LocalDataSource = "(LocalDb)\\MSSQLLocalDB";
        public static string LocalDatabase = "BLGDB";
        //public static string LocalAttachDbFilename = "|DataDirectory|\\BLGDB.mdf"; 
        public static string LocalAttachDbFilename = @"C:\bldb\BLGDB.mdf"; //@"C:\Users\mcy\source\repos\BorusanLogisticsGuzergah\BorusanLogisticsGuzergah\bin\Debug\BLGDB.mdf";
        public static bool ConnDBLocal(bool Connection)
        {
            try
            {
                if (Connection)
                {
                    string conn = "data source=" + Conn.LocalDataSource + ";AttachDbFilename=" + Conn.LocalAttachDbFilename + ";Initial Catalog=" + Conn.LocalDatabase + ";Integrated Security=True;";
                    Conn.dbLocal.ConnectionString = conn;
                    Conn.dbLocal.Open();
                    return true;
                }
                else
                {
                    Conn.dbLocal.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //ExceptionMessage = ex.Message;
                return false;
            }
        }
    }


}
