using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.BusinessLayer.Domain;
using TestWebAPI.BusinessLayer.DTO;
using TestWebAPI.BusinessLayer.Repository;

namespace TestWebAPI.InfrastructureLayer.Repository
{
    public class ProductRepository : Repository<Product,ProductContext>, IProductRepository
    {
       
        public ProductRepository(ProductContext _context): base(_context)
        {
            
        }

        public Task<ProductDTO> GetProductByName(string productName)
        {
            var product = from products in context.Products
                          where products.Name == productName
                          select new ProductDTO
                          {
                              ProductId = products.ProductId,
                              Name = products.Name
                          };
            return product.AsNoTracking().FirstOrDefaultAsync();

        }
    }
}
