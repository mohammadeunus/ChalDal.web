using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupershopMSys_api.Data;

namespace SupershopMSys_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        readonly SuperShopApiDbContext _Context;
        public StockController(SuperShopApiDbContext context) 
        {
            _Context = context;
        }

        public async Task<IActionResult> GetAllStock()
        {
            var stockFetch = _Context.stocks.ToListAsync();
            return Ok(stockFetch);
        }


    }
}
