using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.BusinessLayer.DTO;

namespace TestWebAPI.BusinessLayer.Service
{
    public interface IProductService
    {
        Task<ProductDTO> GetProductByName(string productName);

        Task AddProduct(ProductDTO productDTO);

        int GetDownStreamCustomer(NetworkDTO network); 

        Task UpdateProduct(long ProductId, ProductDTO productDTO);   
        Task DeleteProduct(long productId); 
    }
}
