using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.BusinessLayer.Utils
{
    public static class HttpHelpers
    {
        public static string GetStatusCode(this HttpStatusCode statusCode)
        {
            return statusCode.ToString();
        }
    }
}
