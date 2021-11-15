using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Business.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T item);

        Task<T> Update(T item);

        void Delete(int id);
    }
}