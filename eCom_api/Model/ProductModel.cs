using eCom_api.Model.Common;
using Microsoft.AspNetCore.Mvc;
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

    [NotMapped]
    public IFormFile? imageFile { get; set; } 
    [MaxLength(200)]
    public string? ImageUrl { get; set; }
    public int Weight { get; set; }
     
     
    [MaxLength(100)]
    public string? Brand { get; set; }
     
    [MaxLength(100), MinLength(0)]
    public decimal? DiscountPercentage { get; set; } 
    public DateTime? DiscountStartDate { get; set; } 
    public DateTime? DiscountEndDate { get; set; } 
    public bool IsDiscounted { get; set; }


    // relationship between entities (tables) 
    public List<ReviewModel>? Reviews { get; set; } // product can have multiple reviews from different users
     
    public StockModel? Stocks { get; set; } 

    public int CategoryRefId { get; set; } // product will have only one category. 
    [ForeignKey("CategoryRefId")]
    public CategoryModel? Category{ get; set; }
}
