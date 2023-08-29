﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCom_api.Controllers
{
    [Route("api/admin/")]
    [ApiController]
    [Authorize]
    public class AdminBaseController : ControllerBase
    {
    }
}
