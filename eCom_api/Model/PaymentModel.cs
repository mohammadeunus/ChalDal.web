using eCom_api.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model;

public class PaymentModel : BaseEntity
{
    [Key]
    public int PaymentId { get; set; }


    [Required]
    [MaxLength(100)]
    public string PaymentMethod { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    [Required]
    [MaxLength(50)]
    public string PaymentStatus { get; set; }


    // relationship between entities (tables) 
    public int OrderRefId { get; set; }
    [ForeignKey("OrderRefId")]
    public OrderModel? Order { get; set; }

}
