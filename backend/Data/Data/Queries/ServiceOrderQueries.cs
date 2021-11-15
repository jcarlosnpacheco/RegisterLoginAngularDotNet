using Dapper;
using ServiceOrderAPI.Business.Models;
using ServiceOrderAPI.Infra.Data.Queries.Dapper.Context;
using ServiceOrderAPI.Business.Interfaces.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Infra.Data.Queries
{
    public class ServiceOrderQueries : IServiceOrderQueries
    {
        private readonly DapperContext _dapperContext;

        public ServiceOrderQueries(DapperContext dapperContext) => _dapperContext = dapperContext;

        public async Task<IEnumerable<ServiceOrderModel>> GetAllAsync()
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                             description AS ""Description"",
                                             date_service AS ""Date"",
                                             value_service AS ""Value""
                                             FROM service");

            using var connection = _dapperContext.CreateConnection();
            var services = await connection.QueryAsync<ServiceOrderModel>(query.ToString());
            return services.ToList();
        }

        public async Task<ServiceOrderModel> GetByIdAsync(int idServiceOrder)
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                                    description AS ""Description"",
                                                    date_service AS ""Date"",
                                                    value_service AS ""Value""
                                             FROM service
                                             WHERE id = { idServiceOrder }");

            using var connection = _dapperContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ServiceOrderModel>(query.ToString());
        }
    }
}