using eCom_api.Data;
using eCom_api.DTOs;
using eCom_api.Model;
using Microsoft.EntityFrameworkCore;

namespace eCom_api.Repository
{
    public class SearchRepository
    {
        readonly ChalDalContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public SearchRepository(ChalDalContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<CustomerProductResponseDTO> Search(string searchString, int pageNumber)
        {
            try
            {
                EnsureProductsExist();

                var productsQuery = GetProductQuery(searchString);
                var productDataList = await GetProductDataListAsync(productsQuery);

                var pageSize = 15;
                var prod4CustomerProductResponseDTO = GetPagedProductDataList(productDataList, pageNumber, pageSize);

                var productResponseData = CreateProductResponse(prod4CustomerProductResponseDTO, productDataList.Count);

                return productResponseData;
            }
            catch (Exception ex)
            {
                LogException(searchString,ex);
                throw new Exception($"error occured while searching: {searchString}", ex);
            }
        }

        private void EnsureProductsExist()
        {
            if (_context.Products == null)
            {
                throw new Exception("Products not found");
            }
        }

        private IQueryable<ProductModel> GetProductQuery(string searchString)
        {
            var products = from m in _context.Products select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name!.Contains(searchString));
            }

            return products;
        }

        private async Task<List<CustomerProductModelDTO>> GetProductDataListAsync(IQueryable<ProductModel> productsQuery)
        {
            return await productsQuery
                .Select(product => new CustomerProductModelDTO
                {
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    Weight = product.Weight,
                    SellingPrice = product.Stocks.SellingPrice,
                })
                .ToListAsync();
        }

        private List<CustomerProductModelDTO> GetPagedProductDataList(List<CustomerProductModelDTO> productDataList, int pageNumber, int pageSize)
        {
            return productDataList
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        private CustomerProductResponseDTO CreateProductResponse(List<CustomerProductModelDTO> pagedProductDataList, int totalRecords)
        {
            return new CustomerProductResponseDTO
            {
                CustomerProductList = pagedProductDataList,
                totalRecords = totalRecords,
                Succeeded = totalRecords > 0
            };
        }

        private void LogException(string searchString, Exception ex)
        {
            _logger.LogError($"SearchRepository > Search > Error searching '{searchString}': {ex}");
        }

    }
}
