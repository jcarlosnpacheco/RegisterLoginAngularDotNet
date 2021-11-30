using RegisterLoginAPI.Business.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Interfaces.Queries
{
    public interface IRegisterLoginQueries
    {
        Task<ICollection<RegisterLogin>> GetAllAsync();

        Task<RegisterLogin> GetByIdAsync(int idRegisterLogin);
    }
}