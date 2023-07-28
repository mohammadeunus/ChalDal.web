using System.ComponentModel.DataAnnotations;

namespace eCom_api.Model.Common;

public class UserBase: BaseEntity
{
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Username { get; set; }

    [DataType(DataType.Password)]
    public string PasswordHash { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; }
     
}
