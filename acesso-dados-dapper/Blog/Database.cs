using Microsoft.Data.SqlClient;

namespace Blog
{
    public static class Database
    {
        private const string CONNECTION_STRING = @"Server=localhost;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        private readonly static SqlConnection _connection = new(CONNECTION_STRING);

        public static SqlConnection Connection
        {
            get { return _connection; }
        }
    }
}