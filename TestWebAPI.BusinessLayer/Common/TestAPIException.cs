using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.BusinessLayer.Common
{
    public class TestAPIException : Exception
    {
        public string ErrorCode { get; set; }

        public TestAPIException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
