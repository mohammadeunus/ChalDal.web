using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public int PopularityCount { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? CreatedDate { get; set; }

        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        [MaxLength(50)]
        public string? UpdatedBy { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel? Category { get; set; }

    }
}
