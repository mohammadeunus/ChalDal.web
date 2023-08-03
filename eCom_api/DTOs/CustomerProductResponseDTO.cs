namespace eCom_api.DTOs
{
    public class CustomerProductModel
    {
        public string? Name { get; set; } 
        public string? ImageUrl { get; set; }     
        public decimal? SellingPrice { get; set; }
        public int? Weight { get; set; }
    }

    public class CustomerProductResponseDTO
    {
        public List<CustomerProductModel>? CustomerProductList { get; set;}
        public int totalRecords { get; set; }
        public bool Succeeded { get; set; }
    }
}
  