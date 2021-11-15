using Data.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using ServiceOrderAPI.Business.Models;

namespace ServiceOrderAPI.Infra.Data.Context
{
    public class DBServiceOrderContext : DbContext
    {
        public DBServiceOrderContext(DbContextOptions<DBServiceOrderContext> options) :
            base(options)
        {
        }

        public DbSet<ServiceOrderModel> ServiceOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceOrderMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}