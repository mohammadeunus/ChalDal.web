﻿using eCom_api.Model;
using eCom_api.Repository; 
using Microsoft.AspNetCore.Mvc; 

namespace eCom_api.Controllers.Admin;

public class ProductController : AdminBaseController
{
    readonly ProductRepository _productRepository;

    public ProductController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("GetAllProduct")]
    public async Task<IActionResult> GetAllProduct()
    {
        var productDataList = await _productRepository.GetProductDataListAsync();
        return Ok(productDataList);
    }
    [HttpGet("GetProductById")]
    public IActionResult GetProductById(int id)
    {
        var productDataList = _productRepository.GetProductById(id);
        return Ok(productDataList);
    }

    [HttpDelete("RemoveByProductId")]
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

    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(ProductModel productModelObj)
    {
        if (productModelObj == null)
        {
            return BadRequest();
        }
        if (await _productRepository.UpdateEmployee(productModelObj))
        {
            return Ok(productModelObj);
        }
        return BadRequest("operation failed");
    }


    [HttpPost("AddInProduct")]
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
