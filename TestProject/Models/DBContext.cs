using System;
using System.Web;
using System.Data.SqlClient;
using System.Data.Common;

namespace TestProject.Models
{
    public class DBContext
    {
        static DBContext context;
        private SqlConnection connection;
        private SqlCommand command;

        public static DBContext GetInstance()
        {
            if (context == null)
            {
                context = new DBContext();
                context.Init();
                return context;
            }
            else
            {
                return context;
            }
        }

        public void Init()
        {
            connection = new SqlConnection(@"Server=(localdb)\Projects;Database=QulixDatabase;Trusted_Connection=True;");
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
        }

        public SqlDataReader GetDataFromDB(string query)
        {
            command.CommandText = query;
            return command.ExecuteReader();
        }

        private DBContext() {}
        private DBContext(DBContext context) {}
    }
}