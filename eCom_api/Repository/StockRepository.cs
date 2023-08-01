using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Interfaces;
using eCom_api.Model;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Repository;

public class StockRepository : ICRUDRepository<StockModel>
{
    ILogger<StockRepository> _Logger;
    EComApiDbContext _Context; 
    public StockRepository(EComApiDbContext context, ILogger<StockRepository> logger)
    { 
        _Logger = logger;
        _Context = context;
    }
    public async Task<bool> AddEntity(StockModel entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException();
        }

        try
        { 
            await _Context.Stocks.AddAsync(entity);
            var check = await _Context.SaveChangesAsync();

            return check > 0; // Return true if changes were saved successfully, otherwise false.
        }
        catch (Exception ex)
        {
            _Logger.LogInformation("addEntity from stockRepository failed: "+ex.ToString());
            // Handle the exception or log it, and return false to indicate failure.
            return false;
        }

    }

    public async Task<bool> DeleteEntity(int entityId)
    {
        try
        {
            var result = await _Context.Stocks
               .FirstOrDefaultAsync(e => e.StockId == entityId);

            if (result != null)
            {
                return false;
            }

            _Context.Stocks.Remove(result);
            var check = await _Context.SaveChangesAsync();

            return check > 0; // Return true if changes were saved successfully, otherwise false.
        }
        catch (Exception ex)
        {
            _Logger.LogInformation("DeleteEntity from stockRepository failed: " + ex.ToString()); 
            return false;
        }

    }

    public async Task<IEnumerable<StockModel>> GetEntities()
    {
        try
        {
            return await _Context.Stocks.ToListAsync();
        }
        catch (Exception ex)
        {
            _Logger.LogInformation("GetEntities from stockRepository failed: " + ex.ToString()); 
            return Enumerable.Empty<StockModel>();
        }
    }

    public async Task<StockModel> GetEntityById(int entityId)
    {
        try
        {
            return await _Context.Stocks.FirstOrDefaultAsync(d => d.StockId == entityId);
        }
        catch (Exception ex)
        {
            _Logger.LogInformation("GetEntityById from stockRepository failed: " + ex.ToString());
            return new StockModel();
        }
    }

    public async Task<bool> UpdateEntity(StockModel entity)
    {
        try
        {
            var result = await _Context.Stocks
                 .FirstOrDefaultAsync(e => e.StockId == entity.StockId);

            if (result != null)
            {
                return false;
            }

            result = entity;
            var check = await _Context.SaveChangesAsync();

            return check > 0; // Return true if changes were saved successfully, otherwise false. 
        }
        catch (Exception ex)
        {
            _Logger.LogInformation("UpdateEntity from stockRepository failed: " + ex.ToString()); 
            return false;
        }
         
    }

}