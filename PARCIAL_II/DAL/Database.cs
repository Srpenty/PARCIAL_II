using PARCIAL_II.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace PARCIAL_II.DAL
{
    public class Database
    {
       public static string getStrConnection()
        {
            return Settings.Default.farmacia1ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(getStrConnection());
            return con;
        }
        public bool testConnection()
        {
            SqlConnection con = this.GetConnection();
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}