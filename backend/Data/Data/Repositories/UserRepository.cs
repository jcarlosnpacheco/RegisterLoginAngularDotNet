using Business.Entity;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Infra.Data.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private readonly DBRegisterLoginContext _context;

        public UserRepository(DBRegisterLoginContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public void Delete(int id)
        {
            var entity = _context.User.FirstOrDefault(u => u.Id == id);

            if (entity is not null)
            {
                _context.User.Remove(entity);
                _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await Task.Run(() => _context.User.ToList());
        }

        public async Task<User> Get(int id)
        {
            return await Task.Run(() => _context.User.FirstOrDefault(u => u.Id == id));
        }
    }
}