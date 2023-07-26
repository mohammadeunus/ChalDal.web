using Microsoft.EntityFrameworkCore;
using eCom_api.Model;

namespace eCom_api.Data
{
    public class EComApiDbContext : DbContext
    {
        public EComApiDbContext(DbContextOptions<EComApiDbContext> options)
            : base(options)
        {
        }
        public DbSet<StockModel>? stocks { get; set; }
        public DbSet<ProductModel>? product { get; set; }
        public DbSet<CategoryModel>? category { get; set; }
        public DbSet<TrendingProductModel>? trendingProducts { get; set; }

    }
}