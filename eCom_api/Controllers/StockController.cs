using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCom_api.Data;
using eCom_api.Model;
using eCom_api.Repository;

namespace eCom_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    readonly StockRepository _StockRepo;
    public StockController(StockRepository StockRepo) 
    {
        _StockRepo = StockRepo; 
    }

    [HttpGet]
    public async Task<IActionResult> GetStocks()
    {
        var stockFetch = await _StockRepo.GetEntities();
        return Ok(stockFetch);
    }


    [HttpPost]
    public async Task<IActionResult> AddStock([FromBody] StockModel stockRequest)
    {
        if (await _StockRepo.AddEntity(stockRequest))
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStock(int id)
    {
        if (await _StockRepo.DeleteEntity(id))
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateStock(StockModel stockRequest)
    {
        if (await _StockRepo.UpdateEntity(stockRequest))
        {
            return Ok();
        }
        return BadRequest();
    }

}
