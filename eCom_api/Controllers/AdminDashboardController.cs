using Microsoft.AspNetCore.Mvc;
using eCom_api.Data;
using Microsoft.EntityFrameworkCore;
using eCom_api.Model;

namespace YourApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AdminDashboardController : ControllerBase
    {
        private readonly EComApiDbContext _context;

        public AdminDashboardController(EComApiDbContext context)
        {
            _context = context;
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
                return StatusCode(500, "Error retrieving top products: " + ex.Message);
            }
        }
    }
}
