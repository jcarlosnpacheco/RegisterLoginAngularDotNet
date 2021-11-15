using ServiceOrderAPI.Business.Models;
using ServiceOrderAPI.Business.Interfaces.Repositories;
using ServiceOrderAPI.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Infra.Data.Repositories
{
    public class ServiceOrderRepository : IGenericRepository<ServiceOrderModel>
    {
        private readonly DBServiceOrderContext _context;

        public ServiceOrderRepository(DBServiceOrderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceOrderModel>> GetAll()
        {
            return await Task.Run(() => _context.ServiceOrder.ToList());
        }

        public async Task<ServiceOrderModel> Get(int id)
        {
            return await Task.Run(() => _context.ServiceOrder.FirstOrDefault(s => s.Id == id));
        }

        public async Task<ServiceOrderModel> Create(ServiceOrderModel serviceOrder)
        {
            _context.ServiceOrder.Add(serviceOrder);
            await _context.SaveChangesAsync();
            return serviceOrder;
        }

        public async Task<ServiceOrderModel> Update(ServiceOrderModel serviceOrder)
        {
            _context.ServiceOrder.Update(serviceOrder);
            await _context.SaveChangesAsync();
            return serviceOrder;
        }

        public void Delete(int id)
        {
            var entity = _context.ServiceOrder.FirstOrDefault(s => s.Id == id);

            if (entity is not null)
            {
                _context.ServiceOrder.Remove(entity);
                _context.SaveChangesAsync();
            }
        }
    }
}