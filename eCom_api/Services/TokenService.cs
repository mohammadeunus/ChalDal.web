﻿using eCom_api.DTOs;
using eCom_api.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCom_api.Services;

public class TokenService : ITokenService
{
    readonly ILogger<ITokenService> _logger;
    readonly SymmetricSecurityKey _key; // one that is used both to encrypt and decrypt information.
    public TokenService(IConfiguration config, ILogger<ITokenService> logger)
    {
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        _logger = logger;
    }
    public string CreateToken(UserLoginDTO adminLoginDTO)
    {
        try
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, adminLoginDTO.UserName)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
        catch (Exception ex)
        {
            _logger.LogInformation("TokenService > CreateToken > : " + ex.ToString());
            return null;
        }

    }
}
