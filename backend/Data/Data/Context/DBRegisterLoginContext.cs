using Business.Models;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using RegisterLoginAPI.Business.Models;

namespace RegisterLoginAPI.Infra.Data.Context
{
    public class DBRegisterLoginContext : DbContext
    {
        public DBRegisterLoginContext(DbContextOptions<DBRegisterLoginContext> options) :
            base(options)
        {
        }

        public DbSet<RegisterLoginModel> RegisterLogin { get; set; }
        public DbSet<LoginTypeModel> LoginType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RegisterLoginMap());
            modelBuilder.ApplyConfiguration(new LoginTypeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}