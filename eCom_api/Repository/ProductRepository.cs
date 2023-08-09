using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;

namespace eCom_api.Repository;

public class ProductRepository
{
    readonly ChalDalContext _Context;
    readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(ChalDalContext context, IWebHostEnvironment webHostEnvironment, ILogger<ProductRepository> logger)
    {
        _Context = context;
        _webHostEnvironment = webHostEnvironment;
        _logger = logger;
    }
    internal async Task<int> AddNewProduct(ProductModel model)
    {
        await _Context.Products.AddAsync(model);
        await _Context.SaveChangesAsync();
        return model.ProductId;
    }
    internal async Task<List<Product4AdminDTO>> GetProductDataListAsync()
    {
        var products = await _Context.Products
            .Include(p => p.Stocks)
            .Include(p => p.Category)
            .ToListAsync();

        var productDataList = products.Select(product => new Product4AdminDTO
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
    internal async Task<string> UploadImage(string imagePath, IFormFile file)
    {
        // combining GUID to create unique name before saving in wwwroot
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

        imagePath += Guid.NewGuid().ToString() + "_" + file.FileName;

        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

        await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        return "/" + imagePath;
    }
    public async Task<ProductModel> GetProductById(int id)
    {
        return await _Context.Products.FirstOrDefaultAsync(d => d.ProductId == id);
    } 

    public async Task<string> Search(string searchString)
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

            // Serialize the resultData object to JSON string.
            string jsonString = JsonConvert.SerializeObject(resultData);

            return jsonString;
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"ProductRepository > search > no product found by search: {ex}");
            return "[]"; // Return an empty array if there was an exception.
        }
    }

    public async Task<bool> UpdateEmployee(ProductModel ProductsInput)
    {
        var result = await _Context.Products
            .FirstOrDefaultAsync(e => e.ProductId == ProductsInput.ProductId);


        if (result != null)
        {
            result = ProductsInput;
            await _Context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> DeleteProductById(int inputId)
    {
        var result = await _Context.Products
            .FirstOrDefaultAsync(e => e.ProductId == inputId);

        if (result != null)
        {
            return false;
        }

        _Context.Products.Remove(result);
        var d = await _Context.SaveChangesAsync();
        if (d>0)
        {
            return true;
        }
        return false;

    }


}
