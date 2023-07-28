using eCom_api.Model.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model;

public class ProductModel : BaseEntity
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(200)]
    [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Invalid characters, Alphabets allowed(a-z,A-Z)")]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { get; set; }


    [NotMapped]
    public IFormFile? imageFile { get; set; }
    [Required]
    [MaxLength(200)]
    public string ImageUrl { get; set; }
     

    [Required]
    [MaxLength(100)]
    public string? Brand { get; set; }

    [Required]
    [MaxLength(100)] 

    [Column(TypeName = "decimal(5,2)")]
    [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100")]
    public decimal? DiscountPercentage { get; set; } 
    public DateTime? DiscountStartDate { get; set; } 
    public DateTime? DiscountEndDate { get; set; } 
    public bool IsDiscounted { get; set; }


    // relationship between entities (tables) 
    public List<ReviewModel>? Reviews { get; set; } // product can have multiple reviews from different users
    public List<StockModel>? Stocks { get; set; } // product can have multiple stock, cause each stock has its expiration date

    public int CategoryRefId { get; set; } // product will have only one category. 
    [ForeignKey("CategoryRefId")]
    public CategoryModel? Category { get; set; }

}
