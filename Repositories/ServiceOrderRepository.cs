using ServiceOrderAPI.Application.Models;
using ServiceOrderAPI.Application.Models.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderAPI.Repositories
{
    public class ServiceOrderRepository : IRepository<ServiceOrder>
    {
        private readonly ServiceOrderContext _context;

        public ServiceOrderRepository(ServiceOrderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceOrder>> GetAll()
        {
            return await Task.Run(() => _context.Services.ToList());
        }

        public async Task<ServiceOrder> Get(int id)
        {
            return await Task.Run(() => _context.Services.FirstOrDefault(s => s.Id == id));
        }

        public async Task<ServiceOrder> Add(ServiceOrder service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<ServiceOrder> Edit(ServiceOrder service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public void Delete(int id)
        {
            var entity = _context.Services.FirstOrDefault(s => s.Id == id);

            if (entity is not null)
            {
                _context.Services.Remove(entity);
                _context.SaveChangesAsync();
            }
        }
    }
}