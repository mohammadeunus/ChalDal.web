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
    readonly AdminRepository _adminRepository;
    readonly ITokenService _tokenService;
    public AdminAccountController( AdminRepository adminRepository, ILogger<AdminAccountController> logger, ITokenService tokenService)
    {
        _tokenService = tokenService;
        _adminRepository = adminRepository;
        _logger = logger;
    }


    [HttpPost("admin-register")] // POST: api/admin-account/register 
    public async Task<ActionResult<UserTokenDTO>> AdminRegister([FromBody] AdminRegisterDTO response)
    {
        try
        {
            //check if userName already exist or not.
            if (await _adminRepository.UserExist(response.UserName)) return BadRequest("UserName is taken.");


            //register the user.
            var userTokenHelper = await _adminRepository.RegisterAdmin(response);
            if (userTokenHelper == null) return BadRequest("Data Saving failed, try again.");
            return new UserTokenDTO
            {
                UserName= response.UserName,
                Token = _tokenService.CreateToken(userTokenHelper)
            };
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdminAccountController > AdminRegister > : " + ex.ToString());
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
