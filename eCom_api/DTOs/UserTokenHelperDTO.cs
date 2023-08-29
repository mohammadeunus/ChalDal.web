using System.ComponentModel.DataAnnotations;

namespace eCom_api.DTOs;

public class UserTokenHelperDTO
{
    public string Username { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
}
