using RegisterLoginAPI.Business.Entity;
using RegisterLoginAPI.Business.Interfaces.Repositories;
using RegisterLoginAPI.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterLoginAPI.Infra.Data.Repositories
{
    public class RegisterLoginRepository : IGenericRepository<RegisterLogin>
    {
        private readonly DBRegisterLoginContext _context;

        public RegisterLoginRepository(DBRegisterLoginContext context)
        {
            _context = context;
        }

        public async Task<RegisterLogin> Create(RegisterLogin registerLogin)
        {
            _context.RegisterLogin.Add(registerLogin);
            await _context.SaveChangesAsync();
            return registerLogin;
        }

        public async Task<RegisterLogin> Update(RegisterLogin registerLogin)
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