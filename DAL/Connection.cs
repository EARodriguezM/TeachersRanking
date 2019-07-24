using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connection
    {
        #region SingletonPattern

        private static Connection ConnectionObj = null;
        private Connection() { }
        public static Connection GetInstance()
        {
            if (ConnectionObj == null)
            {
                ConnectionObj = new Connection();
            }
            return ConnectionObj;
        }

        #endregion

        public OracleConnection ConnectionDB()
        {
            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = GetConnectionString();
            return connection;
        }

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CommonUser"].ToString();
        }



    }
}
