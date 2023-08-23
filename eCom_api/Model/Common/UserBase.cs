using System.ComponentModel.DataAnnotations;

namespace eCom_api.Model.Common;

public class UserBase: BaseEntity
{ 
    [Required]
    [MaxLength(100)]
    public string Username { get; set; }

    [MaxLength(100)]
    [DataType(DataType.Password)]
    public byte[] PasswordHash { get; set; }


    [MaxLength(100)]
    [DataType(DataType.Password)]
    public byte[] PasswordSalt { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }
     
}
