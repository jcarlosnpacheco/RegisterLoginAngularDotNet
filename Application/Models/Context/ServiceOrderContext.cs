using Microsoft.EntityFrameworkCore;

namespace ServiceOrderAPI.Application.Models.Context
{
    public class ServiceOrderContext : DbContext
    {
        public ServiceOrderContext(DbContextOptions<ServiceOrderContext> options) :
            base(options)
        {
        }

        public DbSet<ServiceOrder> Services { get; set; }
    }
}