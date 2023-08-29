using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace eCom_api.Controllers.Customer;

public class CustomerProductController : CustomerBaseController
{
    readonly CustomerProductRepository _CustomerProductRepository;
    readonly SearchRepository _SearchRepository;
    readonly ILogger<CustomerProductController> _logger;

    public CustomerProductController(CustomerProductRepository productRepository, SearchRepository searchRepository, ILogger<CustomerProductController> logger)
    {
        _CustomerProductRepository = productRepository;
        _SearchRepository = searchRepository;
        _logger = logger;
    }

    [HttpGet("GetProducts")]
    public async Task<IActionResult> GetProducts(int pageNumber = 1)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LogError($"CustomerProductController > GetProducts > error fetching data: {ex}");
            return StatusCode(500, "An error occurred: " + ex.Message);
        }
    }


    [HttpGet("SearchProductName")]
    public async Task<IActionResult> SearchProductName(string productName, int pageNumber)
    {
        try
        {
            var productResponse = await _SearchRepository.Search(productName, pageNumber);
            return Ok(productResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError($"CustomerProductController > SearchProductName > error fetching data: {ex}");
            return StatusCode(500, "An error occurred: " + ex.Message);
        }

    }

}
