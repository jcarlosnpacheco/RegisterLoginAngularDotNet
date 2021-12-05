using RegisterLoginAPI.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Interfaces.Queries
{
    public interface IRegisterLoginQueries
    {
        Task<ICollection<RegisterLoginModel>> GetAllAsync();

        Task<RegisterLoginModel> GetByIdAsync(int idRegisterLogin);
    }
}