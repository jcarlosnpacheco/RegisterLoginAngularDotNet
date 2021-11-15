using ServiceOrderAPI.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Business.Interfaces.Queries
{
    public interface IServiceOrderQueries
    {
        Task<IEnumerable<ServiceOrderModel>> GetAllAsync();

        Task<ServiceOrderModel> GetByIdAsync(int idServiceOrder);
    }
}