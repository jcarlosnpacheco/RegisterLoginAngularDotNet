using RegisterLoginAPI.Business.Models;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Infra.Data.Repositories
{
    public class RegisterLoginRepository : IGenericRepository<RegisterLoginModel>
    {
        private readonly DBRegisterLoginContext _context;

        public RegisterLoginRepository(DBRegisterLoginContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegisterLoginModel>> GetAll()
        {
            return await Task.Run(() => _context.RegisterLogin.ToList());
        }

        public async Task<RegisterLoginModel> Get(int id)
        {
            return await Task.Run(() => _context.RegisterLogin.FirstOrDefault(r => r.Id == id));
        }

        public async Task<RegisterLoginModel> Create(RegisterLoginModel registerLogin)
        {
            _context.RegisterLogin.Add(registerLogin);
            await _context.SaveChangesAsync();
            return registerLogin;
        }

        public async Task<RegisterLoginModel> Update(RegisterLoginModel registerLogin)
        {
            _context.RegisterLogin.Update(registerLogin);
            await _context.SaveChangesAsync();
            return registerLogin;
        }

        public void Delete(int id)
        {
            var entity = _context.RegisterLogin.FirstOrDefault(r => r.Id == id);

            if (entity is not null)
            {
                _context.RegisterLogin.Remove(entity);
                _context.SaveChangesAsync();
            }
        }
    }
}