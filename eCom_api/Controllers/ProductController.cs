using eCom_api.Data;
using eCom_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        readonly SuperShopApiDbContext _Context;
        public productController(SuperShopApiDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var productFetch = await _Context.product.ToListAsync();
            return Ok(productFetch);
        }


        [HttpPost]
        public async Task<IActionResult> AddInProduct([FromBody] ProductModel productAddRequest)
        {
            await _Context.product.AddAsync(productAddRequest);
            await _Context.SaveChangesAsync();
            return Ok();
        }
    }
}
