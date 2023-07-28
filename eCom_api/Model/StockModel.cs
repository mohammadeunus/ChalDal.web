using eCom_api.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCom_api.Model
{
    public class StockModel: BaseEntity
    {
        [Key]
        public int StockId { get; set; }
        public int Quantity { get; set; }

        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }


        // relationship between entities (tables) 
        public int ProductRefId { get; set; }
        [ForeignKey("ProductRefId")]
        public ProductModel? product { get; set; }

    }
}
