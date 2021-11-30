using Business.Models;
using RegisterLoginAPI.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Interfaces.Queries
{
    public interface ILoginTypeQueries
    {
        Task<ICollection<LoginTypeModel>> GetAllAsync();

        Task<LoginTypeModel> GetByIdAsync(int idLoginType);
    }
}