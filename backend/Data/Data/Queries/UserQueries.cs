using Business.Models;
using Dapper;
using RegisterLoginAPI.Business.Interfaces.Queries;
using RegisterLoginAPI.Infra.Data.Queries.Dapper.Context;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Infra.Data.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly DapperContext _dapperContext;

        public UserQueries(DapperContext dapperContext) => _dapperContext = dapperContext;

        public async Task<UserModel> GetAsync(string username, string password)
        {
            var query = new StringBuilder($@"SELECT u.username AS ""UserName"",
                                                    u.role AS ""Role""
                                             FROM public.""user"" u
                                             WHERE username = '{ username.ToLower() }' AND
                                                   password = '{ password }'");

            using var connection = _dapperContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UserModel>(query.ToString());
        }
    }
}