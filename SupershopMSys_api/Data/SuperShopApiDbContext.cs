using Microsoft.EntityFrameworkCore;
using SupershopMSys_api.Model;

namespace SupershopMSys_api.Data
{
    public class SuperShopApiDbContext : DbContext
    {
        public SuperShopApiDbContext(DbContextOptions<SuperShopApiDbContext> options)
            : base(options)
        {
        }
        public DbSet<StockModel> stocks  { get; set; } 

    }
}