using eCom_api.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model;

public class WishlistModel: BaseEntity
{
    [Key]
    public int WishlistId { get; set; }


    // relationship between entities (tables) 
    public List<ProductModel>? Products { get; set; }
    public int CustomerRefId { get; set; }
    [ForeignKey("CustomerRefId")]
    public CustomerModel? Customer{ get; set; }
     
}
