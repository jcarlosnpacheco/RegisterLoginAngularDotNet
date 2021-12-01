using Dapper;
using RegisterLoginAPI.Business.Interfaces.Queries;
using RegisterLoginAPI.Business.Models;
using RegisterLoginAPI.Infra.Data.Queries.Dapper.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Infra.Data.Queries
{
    public class RegisterLoginQueries : IRegisterLoginQueries
    {
        private readonly DapperContext _dapperContext;

        public RegisterLoginQueries(DapperContext dapperContext) => _dapperContext = dapperContext;

        public async Task<ICollection<RegisterLoginModel>> GetAllAsync()
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                             login_name AS ""LoginName"",
                                             password AS ""Password"",
                                             observation AS ""Observation"",
                                             login_type_id AS ""LoginTypeId""
                                             FROM register_login");

            using var connection = _dapperContext.CreateConnection();
            var registers = await connection.QueryAsync<RegisterLoginModel>(query.ToString());
            return registers.ToList();
        }

        public async Task<RegisterLoginModel> GetByIdAsync(int idRegisterLogin)
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                                    login_name AS ""LoginName"",
                                                    password AS ""Password"",
                                                    observation AS ""Observation"",
                                                    login_type_id AS ""LoginTypeId""
                                             FROM register_login
                                             WHERE id = { idRegisterLogin }");

            using var connection = _dapperContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<RegisterLoginModel>(query.ToString());
        }
    }
}