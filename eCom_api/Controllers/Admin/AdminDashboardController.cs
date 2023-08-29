using Microsoft.AspNetCore.Mvc;
using eCom_api.Data;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Controllers.Admin;
public class AdminDashboardController : AdminBaseController
{
    private readonly ChalDalContext _context;
    readonly ILogger<AdminDashboardController> _logger;

    public AdminDashboardController(ChalDalContext context, ILogger<AdminDashboardController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetTopProducts()
    {
        try
        {
            // Call the stored procedure using FromSqlRaw
            var topProducts = _context.TrendingProducts?.FromSqlRaw("EXEC GetTopProducts").ToList();
            return Ok(topProducts);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdminDashboardController > GetTopProducts: "+ ex.ToString());
            return StatusCode(500, "Error retrieving top products: ");
        }
    }
}
