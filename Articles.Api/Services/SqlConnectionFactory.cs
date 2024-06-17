using Microsoft.Data.SqlClient;

namespace Articles.Api.Services
{
    public class SqlConnectionFactory
    {
        private readonly string connectionString;

        //We are setting the conection string here
        public SqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //Here we are creating new conection to the data base
        public SqlConnection Create()
        {
            return new SqlConnection(connectionString);
        }
    }
}
