using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.BusinessLayer.Repository;

namespace TestWebAPI.InfrastructureLayer.Repository
{
    public class UnitWork : IUnitWork
    {
        private ProductContext _productContext;
        Dictionary<Type, object> _unitOfWorkCache = new();
        public UnitWork(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public IProductRepository Product => Get(() => new ProductRepository(_productContext)); 

        

        public async Task CompleteAsync()
        {
            using var transaction = _productContext.Database.BeginTransaction();
            try
            {
                await _productContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }

        private T Get<T>(Func<T> _repo)
        {
            object _input;
            var key = typeof(T);
            if (_unitOfWorkCache.TryGetValue(key, out _input))
            {
                return (T)_input;
            }
            _input = _repo.Invoke();
            _unitOfWorkCache[key] = _input;
            return (T)_input;
        }

    

    }
}
