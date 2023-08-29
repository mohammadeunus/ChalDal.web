using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCom_api.Data;
using eCom_api.Model;
using eCom_api.Repository;

namespace eCom_api.Controllers.Admin;

public class StockController : AdminBaseController
{
    readonly StockRepository _StockRepo;
    public StockController(StockRepository StockRepo)
    {
        _StockRepo = StockRepo;
    }

    [HttpGet("GetStocks")]
    public async Task<IActionResult> GetStocks()
    {
        var stockFetch = await _StockRepo.GetEntities();
        return Ok(stockFetch);
    }


    [HttpPost("AddStock")]
    public async Task<IActionResult> AddStock([FromBody] StockModel stockRequest)
    {
        if (await _StockRepo.AddEntity(stockRequest))
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("DeleteStock")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        if (await _StockRepo.DeleteEntity(id))
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpPut("UpdateStock")]
    public async Task<IActionResult> UpdateStock(StockModel stockRequest)
    {
        if (await _StockRepo.UpdateEntity(stockRequest))
        {
            return Ok();
        }
        return BadRequest();
    }

}
