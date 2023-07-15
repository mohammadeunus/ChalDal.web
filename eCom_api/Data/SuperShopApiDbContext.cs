using Microsoft.EntityFrameworkCore;
using eCom_api.Model;

namespace eCom_api.Data
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