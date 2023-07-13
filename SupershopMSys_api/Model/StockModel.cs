using System.ComponentModel.DataAnnotations;

namespace SupershopMSys_api.Model
{
    public class StockModel
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public DateTime LastUpdated { get; set; }
        public string? UpdatedBy{ get; set; }
        public string? CreatedBy{ get; set; }
    }
}
