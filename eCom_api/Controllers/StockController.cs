using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCom_api.Data;
using eCom_api.Model;

namespace eCom_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        readonly EComApiDbContext _Context;
        public StockController(EComApiDbContext context) 
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
