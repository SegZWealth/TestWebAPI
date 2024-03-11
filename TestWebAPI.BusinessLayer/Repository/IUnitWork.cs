using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.BusinessLayer.Repository
{
    public interface IUnitWork
    {
        IProductRepository Product { get; }
        Task CompleteAsync();
    }
}
