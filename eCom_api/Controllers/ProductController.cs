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
public class ProductController : ControllerBase
{ 
    readonly ProductRepository _productRepository;

    public ProductController(ProductRepository productRepository)
    { 
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var productDataList = await _productRepository.GetProductDataListAsync();
        return Ok(productDataList);
    }
    [HttpGet]
    public IActionResult GetProductById(int id)
    {
        var productDataList = _productRepository.GetProductById(id);
        return Ok(productDataList);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveByProductId(int id)
    {
        if (id == 0)
        {
            return BadRequest("empty id");
        }
        if (await _productRepository.DeleteProductById(id))
        {
            return Ok();
        }
        return BadRequest("operation failed");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductModel productModelObj)
    {
        if (productModelObj == null)
        {
            return BadRequest();
        }
        if (await _productRepository.UpdateEmployee(productModelObj) )
        {
            return Ok(productModelObj);
        }
        return BadRequest("operation failed");
    }


    [HttpGet]
    public async Task<IActionResult> SearchProductName(string ProductName)
    {
        var result = await _productRepository.Search(ProductName);

        if (string.IsNullOrEmpty(result))
        {
            return BadRequest("no product found");
        }
        else
        {
            return Content(result, "application/json");
        }
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
            productModelObj.ImageUrl = await _productRepository.UploadImage("Assets/images/products/", productModelObj.imageFile);

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
    
}
