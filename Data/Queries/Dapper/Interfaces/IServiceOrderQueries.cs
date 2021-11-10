using ServiceOrderAPI.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Data.Queries.Dapper.Interfaces
{
    public interface IServiceOrderQueries
    {
        Task<IEnumerable<ServiceOrder>> GetAllAsync();

        Task<ServiceOrder> GetByIdAsync(int idServiceOrder);
    }
}