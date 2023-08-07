using eCom_api.Data;
using eCom_api.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Repository;

public class CustomerProductRepository
{
    readonly EComApiDbContext _Context; 
    private readonly ILogger<ProductRepository> _logger;
     
    public CustomerProductRepository(EComApiDbContext context , ILogger<ProductRepository> logger)
    {
        _Context = context; 
        _logger = logger;

    }
    public int GetTotalProductsCount()
    {
        return _Context.Products.Count(); // Get the total number of products
    }

    public CustomerProductResponseDTO GetProductsByPage(int pageNumber, int pageSize)
    {
        var prod = _Context.Products
            .OrderBy(p => p.ProductId) // Order the products by a suitable property (e.g., ProductID)
            .Skip((pageNumber - 1) * pageSize) // Skip the desired number of rows based on the page number
            .Take(pageSize) // Take the number of rows corresponding to the page size
            .Include(p => p.Stocks)
            .Include(p => p.Category)
            .ToList(); // Execute the query and fetch the data into a list

        var productDataList = prod.Select(product => new CustomerProductModel
        {
            Name = product.Name,
            SellingPrice = product.Stocks?.SellingPrice,
            Weight = product.Weight,
            ImageUrl = product.ImageUrl
        }).ToList();

        // Create a single instance of CustomerProductResponseDTO and set its properties
        var productResponseData = new CustomerProductResponseDTO
        {
            CustomerProductList = productDataList,
            totalRecords = GetTotalProductsCount(),
            Succeeded = productDataList.Count() > 0 ? true : false
        };

        return productResponseData;
    }

}
