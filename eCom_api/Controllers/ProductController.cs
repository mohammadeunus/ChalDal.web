using eCom_api.Data;
using eCom_api.Model;
using eCom_api.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class productController : ControllerBase
{
    readonly EComApiDbContext _Context;
    readonly IWebHostEnvironment _webHostEnvironment;
    readonly ProductRepository _productRepository;

    public productController(EComApiDbContext context, IWebHostEnvironment webHostEnvironment, ProductRepository productRepository)
    {
        _Context = context;
        _webHostEnvironment = webHostEnvironment;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var productFetch = await _Context.product.ToListAsync();
        return Ok(productFetch);
    }


    [HttpPost]
    public async Task<IActionResult> AddInProduct([FromBody] ProductModel productModelObj)
    {
        if (productModelObj == null)
        {
            return BadRequest("Product data is null.");
        }
        if (!ModelState.IsValid)
        {
            return Ok("pls pass valid data");
        }
        try
        { 
            productModelObj.ImageUrl = await UploadImage("images/products/", productModelObj.imageFile);

            int id = await _productRepository.AddNewProduct(productModelObj);
            if (id > 0)
            {
                return Ok(new { ProductId = id, Message = "Product added successfully." });
            }
            else
            {
                return BadRequest("Failed to add product.");
            }

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    private async Task<string> UploadImage(string imagePath, IFormFile file)
    {
        // combining GUID to create unique name before saving in wwwroot
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

        imagePath += Guid.NewGuid().ToString() + "_" + file.FileName;

        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);

        await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        return "/" + imagePath;
    }
}
