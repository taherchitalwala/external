using alvazaratAPI53.Models.specificJamaat;
using Dapper;

namespace alvazaratAPI53.Repositories.specificJamaat
{
    public class specificJamaatRepository : IspecificJamaatRepository 
    {
        private readonly DbConnectionBank _connectionString;

        public specificJamaatRepository(DbConnectionBank configuration)
        {
            _connectionString = configuration;
        }

        public async Task<IEnumerable<specificJamaatList>> GetspecificJamaat(string? param1 = null)
        {
            using var conn = _connectionString.CreateBurhaniSQLConnection();
            var parameters = new
            {
                action = "get_specific_jamaat",
                param1 = param1
            };
            string sql = @"external_api_jamaats";
            return await conn.QueryAsync<specificJamaatList>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
