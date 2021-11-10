using Dapper;
using ServiceOrderAPI.Application.Models;
using ServiceOrderAPI.Data.Queries.Dapper.Context;
using ServiceOrderAPI.Data.Queries.Dapper.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Data.Queries.Dapper
{
    public class ServiceOrderQueries : IServiceOrderQueries
    {
        private readonly DapperContext _dapperContext;

        public ServiceOrderQueries(DapperContext dapperContext) => _dapperContext = dapperContext;

        public async Task<IEnumerable<ServiceOrder>> GetAllAsync()
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                             description AS ""Description"",
                                             date_service AS ""Date"",
                                             value_service AS ""Value""
                                             FROM service");

            using var connection = _dapperContext.CreateConnection();
            var services = await connection.QueryAsync<ServiceOrder>(query.ToString());
            return services.ToList();
        }

        public async Task<ServiceOrder> GetByIdAsync(int idServiceOrder)
        {
            var query = new StringBuilder($@"SELECT id AS ""Id"",
                                                    description AS ""Description"",
                                                    date_service AS ""Date"",
                                                    value_service AS ""Value""
                                             FROM service
                                             WHERE id = { idServiceOrder }");

            using var connection = _dapperContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ServiceOrder>(query.ToString());
        }
    }
}