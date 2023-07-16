using eCom_api.Model;

namespace eCom_api.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string? Description { get; set; }

    }
}
