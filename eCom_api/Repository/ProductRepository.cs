using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace eCom_api.Repository;

public class ProductRepository
{
    readonly EComApiDbContext _context;
    readonly IWebHostEnvironment _webHostEnvironment;

    public ProductRepository(EComApiDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }
    internal async Task<int> AddNewProduct(ProductModel model)
    { 
        await _context.Products.AddAsync(model);
        await _context.SaveChangesAsync();
        return model.ProductId;
    }
    internal async Task<List<Product4AdminDTO>> GetProductDataListAsync()
    {
        var products = await _context.Products
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
    public ProductModel SearchProduct(int id)
    {
        return _context.Products.FirstOrDefault(d => d.ProductId == id);
    }

}
