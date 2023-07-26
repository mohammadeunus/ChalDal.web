using eCom_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCom_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserProductController : ControllerBase
    {

        readonly EComApiDbContext _Context;
        public UserProductController(EComApiDbContext Context)
        {
            _Context = Context;
        }
    }

}
