using Dapper;
using RegisterLoginAPI.Business.Models;
using RegisterLoginAPI.Infra.Data.Queries.Dapper.Context;
using RegisterLoginAPI.Business.Interfaces.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;

namespace RegisterLoginAPI.Infra.Data.Queries
{
    public class LoginTypeQueries : ILoginTypeQueries
    {
        private readonly DapperContext _dapperContext;

        public LoginTypeQueries(DapperContext dapperContext) => _dapperContext = dapperContext;

        public async Task<ICollection<LoginTypeModel>> GetAllAsync()
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                             name AS ""Name""
                                             FROM login_type");

            using var connection = _dapperContext.CreateConnection();
            var registers = await connection.QueryAsync<LoginTypeModel>(query.ToString());
            return registers.ToList();
        }

        public async Task<LoginTypeModel> GetByIdAsync(int idLoginType)
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                                    name AS ""Name""
                                             FROM login_type
                                             WHERE id = { idLoginType }");

            using var connection = _dapperContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<LoginTypeModel>(query.ToString());
        }
    }
}