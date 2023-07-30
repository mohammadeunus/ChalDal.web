using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Model;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Repository;

public class ProductRepository
{
    EComApiDbContext _context;
    public ProductRepository(EComApiDbContext context)
    {
        _context = context;
    }
    public async Task<int> AddNewProduct(ProductModel model)
    { 
        await _context.Products.AddAsync(model);
        await _context.SaveChangesAsync();
        return model.ProductId;
    }
    public async Task<List<ProductAdminDTO>> GetProductDataListAsync()
    {
        var products = await _context.Products
            .Include(p => p.Stocks)
            .Include(p => p.Category)
            .ToListAsync();

        var productDataList = products.Select(product => new ProductAdminDTO
        {
            ProductId = product.ProductId,
            CreatedBy = product.CreatedBy,
            CreatedDate = product.CreatedDate,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Brand = product.Brand,
            DiscountPercentage = product.DiscountPercentage,
            DiscountStartDate = product.DiscountStartDate,
            DiscountEndDate = product.DiscountEndDate,
            IsDiscounted = product.IsDiscounted, 
            SellingPrice = product.Stocks?.SellingPrice,
            Quantity = product.Stocks?.Quantity,
            CategoryName = product.Category?.Name
        }).ToList();

        return productDataList;
    }
}
