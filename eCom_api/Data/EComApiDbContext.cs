using eCom_api.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Data
{
    public class EComApiDbContext : IdentityDbContext
    {
        public EComApiDbContext(DbContextOptions<EComApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<StockModel> stocks { get; set; }
    }
}