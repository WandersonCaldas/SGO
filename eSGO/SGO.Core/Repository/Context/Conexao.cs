using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SGO.Core.Repository.Context
{
    public class Conexao
    {
        private static Conexao s_objDBConnect;
        private static IDbConnection s_objConnection;

        protected Conexao()
        {            
            s_objConnection = new MySqlConnection();
            s_objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
            s_objConnection.Open();
        }

        public static Conexao GetInstance()
        {
            if (s_objDBConnect == null)
            {
                s_objDBConnect = new Conexao();
                return s_objDBConnect;
            }
            if (s_objDBConnect.GetConnection.State == ConnectionState.Closed)
            {
                s_objDBConnect = new Conexao();
                return s_objDBConnect;
            }

            return s_objDBConnect;
        }

        public IDbConnection GetConnection
        {
            get
            {
                return s_objConnection;
            }
        }
    }
}
