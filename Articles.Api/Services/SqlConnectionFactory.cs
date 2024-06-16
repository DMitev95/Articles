using Microsoft.Data.SqlClient;

namespace Articles.Api.Services
{
    public class SqlConnectionFactory
    {
        private readonly string connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection Create()
        {
            return new SqlConnection(connectionString);
        }
    }
}
