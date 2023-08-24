using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Model;
using eCom_api.Model.Common;
using eCom_api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace eCom_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminAccountController : ControllerBase
{ 
    readonly ILogger<AdminAccountController> _logger;
    readonly AdminRepository _adminRepository;
    public AdminAccountController( AdminRepository adminRepository, ILogger<AdminAccountController> logger)
    {
        _adminRepository = adminRepository;
        _logger = logger;
    }


    [HttpPost("admin-register")] // POST: api/admin-account/register 
    public async Task<ActionResult> AdminRegister([FromBody] RegisterAdminDTO response)
    {
        try
        {
            //check if userName already exist or not.
            if (await _adminRepository.UserExist(response.UserName)) return BadRequest("UserName is taken.");


            //register the user.
            await _adminRepository.RegisterAdmin(response);
            return Ok("User Registered Successfully");
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.ToString());
            return BadRequest("Data Saving failed");
        }
    }



    [HttpPost("admin-login")] // POST: api/admin-account/login 
    public async Task<IActionResult> AdminLogin([FromBody] AdminLoginDTO response)
    {
        try
        {

            //check if userName already exist or not.
            if (!await _adminRepository.UserExist(response.UserName)) return Unauthorized("Invalid UserName.");

            //UserName Found > next step: check pass
            bool passMatched = await _adminRepository.LoginAdminPasswordMatches(response);

            if (passMatched)
            {
                return Ok("User logged in.");
            }
            return Unauthorized("Invalid Password.");
                /*(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });*/
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.ToString());
            return BadRequest("Data Saving failed");
        }
    }

}
