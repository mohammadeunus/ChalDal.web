using eCom_api.Data;
using eCom_api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class productController : ControllerBase
    {
        readonly EComApiDbContext _Context;
        public productController(EComApiDbContext context)
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
        [HttpPost]
        public string UploadImage([FromForm] IFormFile file)
        {
            try
            {
                // getting file original name
                string FileName = file.FileName;

                // combining GUID to create unique name before saving in wwwroot
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;

                // getting full path inside wwwroot/images
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", FileName);

                // copying file
                file.CopyTo(new FileStream(imagePath, FileMode.Create));

                return "File Uploaded Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
