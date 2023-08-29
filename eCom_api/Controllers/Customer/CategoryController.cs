using eCom_api.Data;
using eCom_api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Controllers.Customer;

public class CategoryController : CustomerBaseController
{
    readonly ChalDalContext _Context;
    public CategoryController(ChalDalContext context)
    {
        _Context = context;
    }

    [HttpGet("GetAllCategory")]
    public async Task<IActionResult> GetAllCategory()
    {
        var CategoryFetch = await _Context.Categories.ToListAsync();
        return Ok(CategoryFetch);
    }


    [HttpPost("AddInCategory")]
    public async Task<IActionResult> AddInCategory([FromBody] CategoryModel CategoryAddRequest)
    {
        await _Context.Categories.AddAsync(CategoryAddRequest);
        await _Context.SaveChangesAsync();
        return Ok();
    }
}
