namespace eCom_api.DTOs
{
    public class Product4CustomerDTO
    {  
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Brand { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public DateTime? DiscountStartDate { get; set; }
        public DateTime? DiscountEndDate { get; set; }
        public bool IsDiscounted { get; set; }
        public decimal? SellingPrice { get; set; }
        public int? Quantity { get; set; }
    }
}
