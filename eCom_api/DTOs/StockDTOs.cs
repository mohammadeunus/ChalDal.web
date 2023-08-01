namespace eCom_api.DTOs;

public class StockDTOs
{ 
    public int StockId { get; set; }
    public int Quantity { get; set; }

    public decimal CostPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public int ProductRefId { get; set; }
}
