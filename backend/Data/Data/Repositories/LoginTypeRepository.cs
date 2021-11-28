using Business.Models;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Infra.Data.Repositories
{
    public class LoginTypeRepository : IGenericRepository<LoginTypeModel>
    {
        private readonly DBRegisterLoginContext _context;

        public LoginTypeRepository(DBRegisterLoginContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoginTypeModel>> GetAll()
        {
            return await Task.Run(() => _context.LoginType.ToList());
        }

        public async Task<LoginTypeModel> Get(int id)
        {
            return await Task.Run(() => _context.LoginType.FirstOrDefault(l => l.Id == id));
        }

        public async Task<LoginTypeModel> Create(LoginTypeModel loginType)
        {
            _context.LoginType.Add(loginType);
            await _context.SaveChangesAsync();
            return loginType;
        }

        public async Task<LoginTypeModel> Update(LoginTypeModel loginType)
        {
            _context.LoginType.Update(loginType);
            await _context.SaveChangesAsync();
            return loginType;
        }

        public void Delete(int id)
        {
            var entity = _context.LoginType.FirstOrDefault(l => l.Id == id);

            if (entity is not null)
            {
                _context.LoginType.Remove(entity);
                _context.SaveChangesAsync();
            }
        }
    }
}