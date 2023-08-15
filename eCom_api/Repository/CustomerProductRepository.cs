using eCom_api.Data;
using eCom_api.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace eCom_api.Repository;

public class CustomerProductRepository
{
    readonly ChalDalContext _Context; 
    private readonly ILogger<ProductRepository> _logger;
     
    public CustomerProductRepository(ChalDalContext context , ILogger<ProductRepository> logger)
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


    public async Task<string> Search(string searchString,int pageNumber)
    {
        try
        {

            if (_Context.Products == null)
            {
                return "[]";
            }

            var products = from m in _Context.Products
                           select m; //The query is not executed at this point; it merely sets up the query expression.

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }

            var productDataList = products.Select(product => new Product4CustomerDTO
            {
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand,
                DiscountPercentage = product.DiscountPercentage,
                DiscountStartDate = product.DiscountStartDate,
                DiscountEndDate = product.DiscountEndDate,
                IsDiscounted = product.IsDiscounted,
                SellingPrice = product.Stocks.SellingPrice,
                Quantity = product.Stocks.Quantity
            }).ToList();

            // Create a new anonymous object with only the "result" data.
            var resultData = new { result = productDataList };
            var resultData3 = new { productDataList };
            var resultData2 = productDataList;

            // Serialize the resultData object to JSON string.
            string jsonString = JsonConvert.SerializeObject(resultData);
            string jsonString2 = JsonConvert.SerializeObject(resultData2);
            string jsonString3 = JsonConvert.SerializeObject(resultData3);

            return jsonString;
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"ProductRepository > search > no product found by search: {ex}");
            return "[]"; // Return an empty array if there was an exception.
        }
    }

}
