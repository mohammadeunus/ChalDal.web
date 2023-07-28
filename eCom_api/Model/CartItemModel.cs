using eCom_api.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model;

public class CartItemModel : BaseEntity
{
    [Key]
    public int CartItemId { get; set; }
    public int Quantity { get; set; } 


    // relationship between entities (tables) 
    public int ProductRefId { get; set; }
    [ForeignKey("ProductRefId")]
    public ProductModel? Products{ get; set; }
    public int CustomerRefId { get; set; }
    [ForeignKey("CustomerRefId")]
    public CustomerModel? Customer { get; set; }
}
