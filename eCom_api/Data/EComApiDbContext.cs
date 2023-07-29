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
        public DbSet<AdminModel>? Admins { get; set; }
        public DbSet<CartItemModel>? CartItems { get; set; }
        public DbSet<CategoryModel>? Categories { get; set; }
        public DbSet<CustomerModel>? Customers { get; set; }
        public DbSet<OrderModel>? Orders { get; set; }
        public DbSet<PaymentModel>? Payments { get; set; }
        public DbSet<ProductModel>? Products { get; set; }
        public DbSet<ReviewModel>? Reviews { get; set; }
        public DbSet<StockModel>? Stocks { get; set; }
        public DbSet<TrendingProductModel>? TrendingProducts { get; set; }
        public DbSet<WishlistModel>? WishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasOne(p => p.Stocks)
                      .WithMany()
                      .HasForeignKey(p => p.StockRefId)
                      .OnDelete(DeleteBehavior.NoAction); // Specify the cascading behavior

                entity.HasOne(p => p.Category)
                      .WithMany()
                      .HasForeignKey(p => p.CategoryRefId);
            });

            base.OnModelCreating(modelBuilder);
        }


    }

}