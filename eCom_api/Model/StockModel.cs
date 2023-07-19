using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model
{
    public class StockModel
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public DateTime? LastUpdated { get; set; }
        public string? UpdatedBy{ get; set; }
        public string? CreatedBy{ get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductModel product { get; set; }

    }
}
