using alvazaratAPI53.Models.Masters;
using Dapper;

namespace alvazaratAPI53.Repositories.Masters
{
    public class allJamaatRepository: IallJamaatRepository 
    {
        private readonly DbConnectionBank _connectionString;

        public allJamaatRepository (DbConnectionBank configuration)
        {
            _connectionString = configuration;
        }

        public async Task<IEnumerable<allJamaatList>> GetAllJamaats(string? param1 = null)
        {
            using var conn = _connectionString.CreateBurhaniSQLConnection();
            var parameters = new
            {
                action = "get_all_jamaats",
                param1 = param1
            }; 
            string sql = @"external_api_jamaats";
            return await conn.QueryAsync<allJamaatList>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
