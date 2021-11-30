using RegisterLoginAPI.Business.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Interfaces.Queries
{
    public interface ILoginTypeQueries
    {
        Task<ICollection<LoginType>> GetAllAsync();

        Task<LoginType> GetByIdAsync(int idLoginType);
    }
}