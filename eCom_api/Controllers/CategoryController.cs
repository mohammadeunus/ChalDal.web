using eCom_api.Data;
using eCom_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly SuperShopApiDbContext _Context;
        public CategoryController(SuperShopApiDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var CategoryFetch = await _Context.category.ToListAsync();
            return Ok(CategoryFetch);
        }


        [HttpPost]
        public async Task<IActionResult> AddInCategory([FromBody] CategoryModel CategoryAddRequest)
        {
            await _Context.category.AddAsync(CategoryAddRequest);
            await _Context.SaveChangesAsync();
            return Ok();
        }
    }
}
