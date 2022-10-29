using System.Configuration;
using System.Data.SqlClient;

namespace AptUni.logicLayer
{
    public class DatabaseConnection
    {
        public SqlConnection SQL_Connnection()
        {
            // Create SQL Connection

            SqlConnection con = new SqlConnection();

            con.ConnectionString = ConfigurationManager.ConnectionStrings["AptUniConnectionString"].ConnectionString;

            con.Open();

            return con;
        }
    }
}