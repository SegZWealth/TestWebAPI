using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.BusinessLayer.Domain;
using TestWebAPI.BusinessLayer.DTO;

namespace TestWebAPI.BusinessLayer.Repository
{
    public interface IProductRepository : IRepository<Product> 
    {
        Task<ProductDTO> GetProductByName(string productName);
    }
}
