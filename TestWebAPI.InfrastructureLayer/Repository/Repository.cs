using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.BusinessLayer.Repository;

namespace TestWebAPI.InfrastructureLayer.Repository
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {

        protected TContext context;
        private DbSet<TEntity> _dbSet;
        public Repository(TContext _context)
        {
            context=_context;   
            _dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public TEntity Get(long Id)
        {
            return _dbSet.Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _dbSet.ToList();
        }

        public void Remove(TEntity entity)
        {
           _dbSet.Remove(entity);
        }
    }
}
