using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.database
{
    public class Adapter
    {

       

        private SqlConnection _sqlconn;
        public SqlConnection sqlconn
        {
            set { _sqlconn = value; }
            get { return _sqlconn; }
        }
        
        protected void openConnection()
        {
            
            string conn = "Server=localhost\\SqlExpress;Database=tp2_net;Integrated Security=true;"; 
            sqlconn = new SqlConnection(conn);
            sqlconn.Open();
        }
        protected void closeConnection()
        {
            sqlconn.Close();
            sqlconn = null;
        }


    }
}
