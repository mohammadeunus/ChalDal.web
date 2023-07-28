using eCom_api.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace eCom_api.Model;

public class CustomerModel : UserBase
{
    [Key]
    public int CustomerId { get; set; }
    [DataType(DataType.PhoneNumber)]
    [Phone]
    public string? PhoneNumber { get; set; }

    [MaxLength(200)]
    public string? ShippingAddress { get; set; }
    public List<ReviewModel>? Reviews { get; set; }
}
