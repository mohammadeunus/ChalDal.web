using eCom_api.Data;
using eCom_api.Repository; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace eCom_api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class CustomerProductController : ControllerBase
{
    readonly CustomerProductRepository _CustomerProductRepository;

    public CustomerProductController(CustomerProductRepository productRepository)
    {
        _CustomerProductRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(int pageNumber = 1)
    {
        int pageSize = 15; // Default page size

        var totalProducts = _CustomerProductRepository.GetTotalProductsCount(); // Get the total number of products

        // Calculate the total number of pages for pagination links
        var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

        // Ensure pageNumber is within a valid range (1 to totalPages)
        pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));

        // You can return the productsOnPage and pagination details as JSON response
        var response = _CustomerProductRepository.GetProductsByPage(pageNumber, pageSize);

        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> SearchProductName(string ProductName)
    {
        var result = await _CustomerProductRepository.Search(ProductName);

        if (string.IsNullOrEmpty(result))
        {
            return BadRequest("no product found");
        }
        else
        {
            return Content(result, "application/json");
        }
    }


}
