using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.BusinessLayer.Domain;
using TestWebAPI.BusinessLayer.DTO;
using TestWebAPI.BusinessLayer.Repository;
using TestWebAPI.BusinessLayer.Service;

namespace TestWebAPI.InfrastructureLayer.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitWork _uow;
        public ProductService(IUnitWork uow)
        {
            _uow = uow;
        }
        public async Task<ProductDTO> GetProductByName(string productName)
        {
            return await _uow.Product.GetProductByName(productName);
        }

        public async Task AddProduct(ProductDTO _product)
        {
            _uow.Product.Add(new Product { ProductId = _product.ProductId, Name = _product.Name });
            await _uow.CompleteAsync();
        }

        public int GetDownStreamCustomer(NetworkDTO network)
        {
            List<int> downStreamNodes = new();
            int downstreamCustomer = 0;
            Dictionary <int, int> nodeCustomers = network.Network.Customers.ToDictionary(x=>x.Node,x=>x.NumberOfCustomers);
            foreach (var branch in network.Network.Branches)
            {
                if ((branch.StartNode == network.SelectedNode || downStreamNodes.Contains(branch.StartNode)) && !downStreamNodes.Contains(branch.EndNode))
                {
                    downStreamNodes.Add(branch.EndNode);
                }
            }
            

            foreach(var node in downStreamNodes)
            {
                if (nodeCustomers.ContainsKey(node))
                    downstreamCustomer += nodeCustomers[node];
            }

            return downstreamCustomer;
        }

        public async Task UpdateProduct(long ProductId, ProductDTO productDTO)
        {
            var product = _uow.Product.Get(ProductId);
            if (product == null) { return; }
            product.Name = productDTO.Name;
            await _uow.CompleteAsync();
        }

        public async Task DeleteProduct(long productId)
        {
            var product = _uow.Product.Get(productId);
            if (product == null) { return; }

            _uow.Product.Remove(product);
            await _uow.CompleteAsync();
        }
    }
}
