using eCom_api.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model;

public class ReviewModel : BaseEntity
{
    [Key] 
    public int ReviewId { get; set; }
     
    public string? Comment { get; set; }

    public int? Rating { get; set; }


    // relationship between entities (tables) 
    public int ProductRefId { get; set; }
    [ForeignKey("ProductRefId")]
    public ProductModel? Product { get; set; }

    public int CustomerRefId { get; set; }
    [ForeignKey("CustomerModel")]
    public CustomerModel? Customer { get; set; }
}
