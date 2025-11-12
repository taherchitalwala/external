using System.Data;
using Microsoft.Data.SqlClient;

namespace alvazaratAPI53.Repositories
{
    public class DbConnectionBank
    {
        private readonly string _connectionString;
        private readonly string _connectionStringBurhani;
        public DbConnectionBank (IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("DefaultConnection missing in appsettings.json");

            _connectionStringBurhani = config.GetConnectionString("DefaultConnection_Burhani")
                ?? throw new InvalidOperationException("DefaultConnection_Burhani missing in appsettings.json");
        }
            
        public IDbConnection CreateSQLConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public IDbConnection CreateBurhaniSQLConnection()
        {
            return new SqlConnection(_connectionStringBurhani);
        }
    }
}
