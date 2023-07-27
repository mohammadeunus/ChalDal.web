using eCom_api.Data;
using eCom_api.Model;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Repository
{
    public class ProductRepository
    {
        EComApiDbContext _context;
        public ProductRepository(EComApiDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewProduct(ProductModel model)
        { 
            await _context.product.AddAsync(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }
    }
}
