using Azure;
using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace eCom_api.Repository;

public class AdminRepository
{
    readonly ChalDalContext _context;

    public AdminRepository(ChalDalContext context)
    {
        _context = context;
    }

    public async Task<bool> LoginAdminPasswordMatches(AdminLoginDTO responseDTO)
    {
        var user = await _context.Admins.FirstOrDefaultAsync(x => x.Username == responseDTO.UserName); // returns the record if matches.
          
        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(responseDTO.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return false;
        }
        return true;

    }

    public async Task RegisterAdmin(RegisterAdminDTO response)
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
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new InvalidOperationException("Data Saving failed", ex);
        }
    }
    public async Task<bool> UserExist(string response)
    {
        return await _context.Admins.AnyAsync(x=>x.Username ==response);
    }
}
