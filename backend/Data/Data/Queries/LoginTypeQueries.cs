using Business.Models;
using Dapper;
using RegisterLoginAPI.Business.Entity;
using RegisterLoginAPI.Business.Interfaces.Queries;
using RegisterLoginAPI.Infra.Data.Queries.Dapper.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Infra.Data.Queries
{
    public class LoginTypeQueries : ILoginTypeQueries
    {
        private readonly DapperContext _dapperContext;

        public LoginTypeQueries(DapperContext dapperContext) => _dapperContext = dapperContext;

        public async Task<ICollection<LoginType>> GetAllAsync()
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                             name AS ""Name""
                                             FROM login_type");

            using var connection = _dapperContext.CreateConnection();
            var registers = await connection.QueryAsync<LoginType>(query.ToString());
            return registers.ToList();
        }

        public async Task<LoginType> GetByIdAsync(int idLoginType)
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                                    name AS ""Name""
                                             FROM login_type
                                             WHERE id = { idLoginType }");

            using var connection = _dapperContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<LoginType>(query.ToString());
        }
    }
}