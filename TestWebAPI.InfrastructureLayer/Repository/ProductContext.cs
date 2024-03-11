using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.BusinessLayer.Domain;

namespace TestWebAPI.InfrastructureLayer.Repository
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
