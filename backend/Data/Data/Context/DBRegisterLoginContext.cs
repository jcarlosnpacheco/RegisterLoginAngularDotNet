using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using RegisterLoginAPI.Business.Entity;

namespace RegisterLoginAPI.Infra.Data.Context
{
    public class DBRegisterLoginContext : DbContext
    {
        public DBRegisterLoginContext(DbContextOptions<DBRegisterLoginContext> options) :
            base(options)
        {
        }

        public DbSet<RegisterLogin> RegisterLogin { get; set; }
        public DbSet<LoginType> LoginType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RegisterLoginMap());
            modelBuilder.ApplyConfiguration(new LoginTypeMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}