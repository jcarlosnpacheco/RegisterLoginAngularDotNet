using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace RegisterLoginAPI.Infra.Data.Queries.Dapper.Context
{
    //TODO - https://code-maze.com/using-dapper-with-asp-net-core-web-api/
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("RegisterLoginDB");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}