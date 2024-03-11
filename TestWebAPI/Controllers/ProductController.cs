using Microsoft.AspNetCore.Mvc;
using TestWebAPI.BusinessLayer.DTO;
using TestWebAPI.BusinessLayer.Service;
using TestWebAPI.InfrastructureLayer.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebAPI.Controllers
{

    public class ProductController : BaseController
    {
        private readonly IProductService _prodServ;
        private readonly ILogger _logger;
        public ProductController(IProductService prodServ, ILogger<ProductController> logger)
        {
            _prodServ = prodServ;
            _logger = logger;
        }
        // GET: api/<ProductController>
        [Route("get-product-by-name/{name}")]
        [HttpGet]
        public async Task<IServiceResponse<ProductDTO>> GetProductByName(string name)
        {
            return await HandleAPIOperations(async () =>
            {
                var response = await _prodServ.GetProductByName(name);
                return new ServiceResponse<ProductDTO>
                {
                    Object = response
                };
            });
            // return await _prodServ.GetProductByName(name);
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task Post(ProductDTO _product)
        {
            await _prodServ.AddProduct(_product);
        }


        [HttpPost]

        [Route("get-down-stream")]
        public int GetDownStreamCustomer(NetworkDTO _network)
        {
          return   _prodServ.GetDownStreamCustomer(_network);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{ProductId}")]
        public async Task Put(long ProductId, ProductDTO _product)
        {
            await _prodServ.UpdateProduct(ProductId, _product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{ProductId}")]
        public async Task Delete(long ProductId)
        {
            await _prodServ.DeleteProduct(ProductId);
        }
    }
}
