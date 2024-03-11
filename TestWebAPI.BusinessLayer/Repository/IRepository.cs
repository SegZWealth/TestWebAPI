using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.BusinessLayer.Repository
{
    public interface IRepository <TEntity> where TEntity : class
    {
        TEntity Get(long Id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
