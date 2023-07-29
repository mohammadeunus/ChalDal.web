using eCom_api.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model;

public class OrderModel : BaseEntity
{
    [Key]
    public int OrderId { get; set; }

    public decimal TotalAmount { get; set; }

    [Required]
    [MaxLength(200)]
    public string ShippingAddress { get; set; }
     
    [Required]
    [MaxLength(50)]
    public string? orderStatus { get; set; }


    // relationship between entities (tables) 
    public int CustomerRefId { get; set; }
    [ForeignKey("CustomerRefId")]
    public CustomerModel? Customer { get; set; }
    public List<CartItemModel>? CartItems { get; set; }
    public List<PaymentModel>? Payments { get; set; }
}
