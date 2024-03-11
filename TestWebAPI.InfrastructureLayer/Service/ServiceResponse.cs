using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.BusinessLayer.Service;

namespace TestWebAPI.InfrastructureLayer.Service
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public ServiceResponse()
        {
            ValidationErrors = new Dictionary<string, IEnumerable<string>>();
        }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public T Object { get; set; }
        public Dictionary<string, IEnumerable<string>> ValidationErrors { get; set; }
    }
}
