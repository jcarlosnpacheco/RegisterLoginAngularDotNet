using ServiceOrderAPI.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Repositories
{
    public class ServiceOrderRepository : IRepository<ServiceOrder>
    {
        private static Dictionary<int, ServiceOrder> serviceOrder = new Dictionary<int, ServiceOrder>();

        public async Task<IEnumerable<ServiceOrder>> GetAll()
        {
            return await Task.Run(() => serviceOrder.Values.ToList());
        }

        public async Task<ServiceOrder> Get(int id)
        {
            return await Task.Run(() => serviceOrder.GetValueOrDefault(id));
        }

        public async Task<ServiceOrder> Add(ServiceOrder service)
        {
            return await Task.Run(() =>
            {
                var id = serviceOrder.Count + 1;
                service.Id = id;
                serviceOrder.Add(id, service);
                return service;
            });
        }

        public async Task Edit(ServiceOrder service)
        {
            await Task.Run(() =>
            {
                serviceOrder.Remove(service.Id);
                serviceOrder.Add(service.Id, service);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => serviceOrder.Remove(id));
        }
    }
}