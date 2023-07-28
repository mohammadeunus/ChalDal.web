using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using eCom_api.Model.Common;

namespace eCom_api.Model;

[Table("Categories")]
public class CategoryModel: BaseEntity
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<ProductModel>? Product { get; set; }

}