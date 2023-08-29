using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Interfaces;
using eCom_api.Model;
using eCom_api.Model.Common;
using eCom_api.Repository;
using eCom_api.Services;
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
    readonly IAdminRepository _adminRepository;
    public AdminAccountController( IAdminRepository adminRepository, ILogger<AdminAccountController> logger)
    {
        _adminRepository = adminRepository;
        _logger = logger;
    }


    [HttpPost("admin-register")] // POST: api/admin-account/register 
    public async Task<IActionResult> AdminRegister([FromBody] AdminRegisterDTO response)
    {
        try
        {
            //check if userName already exist or not.
            if (await _adminRepository.UserExist(response.UserName)) return BadRequest("UserName is taken.");


            //register the user.
            var newUserTokenHelper = await _adminRepository.RegisterAdmin(response);
            if (newUserTokenHelper == null) return BadRequest("Data Saving failed, try again.");

            //generate token.
            var newToken = await _adminRepository.generateToken(newUserTokenHelper);
            if (newToken == null) return BadRequest("Token generation failed, try loggin in.");

            return Ok(newToken);
            
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdminAccountController > AdminRegister > : " + ex.ToString());
            return BadRequest("Data Saving failed");
        }
    }



    [HttpPost("admin-login")] // POST: api/admin-account/login 
    public async Task<IActionResult> AdminLogin([FromBody] UserLoginDTO response)
    {
        try
        {
            //check if userName in database.
            if (!await _adminRepository.UserExist(response.UserName)) return Unauthorized("Invalid UserName.");

            //UserName Found > match pass in database.
            var passMatched = await _adminRepository.LoginAdmin(response);
            if (passMatched == null) return Unauthorized("Invalid Password."); // return if password doesn't match.

            //generate token.
            var newToken = await _adminRepository.generateToken(passMatched);
            if (newToken == null) return BadRequest("Token generation failed, try loggin in.");

            return Ok(newToken);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdminAccountController > AdminLogin > : " + ex.ToString());
            return BadRequest("Data Saving failed");
        }
    }

}
