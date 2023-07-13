using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupershopMSys_api.Data;
using SupershopMSys_api.Model;

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

        [HttpGet]
        public async Task<IActionResult> GetAllStock()
        {
            var stockFetch = await _Context.stocks.ToListAsync();
            return Ok(stockFetch);
        }


        [HttpPost]
        public async Task<IActionResult> AddInStock([FromBody] StockModel stockAddRequest)
        {
            await _Context.stocks.AddAsync(stockAddRequest);
            await _Context.SaveChangesAsync();
            return Ok();
        }


    }
}
