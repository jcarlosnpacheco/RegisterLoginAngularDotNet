using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Business.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<ICollection<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T item);

        Task<T> Update(T item);

        void Delete(int id);
    }
}