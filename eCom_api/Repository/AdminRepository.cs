using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Interfaces;
using eCom_api.Model;
using eCom_api.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace eCom_api.Repository;

public class AdminRepository : IAdminRepository
{
    readonly ChalDalContext _context;
    readonly ILogger<AdminRepository> _logger;
    readonly ITokenService _tokenService;


    public AdminRepository(ChalDalContext context, ILogger<AdminRepository> logger, ITokenService tokenService)
    {
        _tokenService = tokenService;
        _context = context;
        _logger = logger;
    }

    public async Task<UserLoginDTO> LoginAdmin(UserLoginDTO responseDTO)
    {
        try
        {
            var user = await _context.Admins.FirstOrDefaultAsync(x => x.Username == responseDTO.UserName); // returns the record if matches.

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(responseDTO.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }
            var newUserTokenHelperDTO = new UserLoginDTO() { UserName = responseDTO.UserName, Password = responseDTO.Password};
            return newUserTokenHelperDTO;
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdminRepository > LoginAdmin > : " + ex.ToString());
            return null;
        }
        
    }

    public async Task<UserLoginDTO> RegisterAdmin(AdminRegisterDTO response)
    {
        try
        {
            using var hmac = new HMACSHA512();
            var user = new AdminModel
            {
                Username = response.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(response.Password)),
                PasswordSalt = hmac.Key,
                Email = response.Email,
                IsDeleted = false,
                CreatedBy = "Mubin",
                CreatedDate = DateTime.Now,
            };
            _context.Admins.Add(user);
            await _context.SaveChangesAsync();
            return new UserLoginDTO()
            {
                UserName= response.UserName,
                Password = response.Password
            };
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdminRepository > AdminRegister > : " + ex.ToString());
            return null;
        }
    }
    public async Task<bool> UserExist(string response)
    {
        try
        {
            return await _context.Admins.AnyAsync(x => x.Username == response);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdminRepository > UserExist > : " + ex.ToString());
            return false;
        }
    }

    public async Task<UserTokenDTO> generateToken(UserLoginDTO userLoginDTO)
    {
        try
        {
            var d = _tokenService.CreateToken(userLoginDTO);
            var generatedToken = new UserTokenDTO
            {
                UserName = userLoginDTO.UserName,
                Token = d
            };

            return generatedToken;
        }
        catch (Exception ex)
        {
            _logger.LogInformation("AdminRepository > generateToken > : " + ex.ToString());
            return null;
        }

    }
}
