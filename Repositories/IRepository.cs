using ServiceOrderAPI.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Add(T item);

        Task<T> Edit(T item);

        void Delete(int id);
    }
}