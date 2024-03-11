using log4net;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;
using TestWebAPI.BusinessLayer.Common;
using TestWebAPI.BusinessLayer.Service;
using TestWebAPI.BusinessLayer.Utils;
using TestWebAPI.InfrastructureLayer.Service;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        public async Task<ServiceResponse<T>> HandleAPIOperations<T>(Func<Task<ServiceResponse<T>>> action, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string method = "")
        {
            var _logger = LogManager.GetLogger(typeof(BaseController));

            _logger.Info($">>> ENTERS ({method}) and Line number {lineNumber} >>> ");
            var serviceResponse = new ServiceResponse<T>
            {
                Code = HttpHelpers.GetStatusCode(HttpStatusCode.OK),
                ShortDescription = "SUCCESS"
            };
            try
            {
                if (!ModelState.IsValid)
                    throw new TestAPIException(HttpHelpers.GetStatusCode(HttpStatusCode.BadRequest), "There were some errors in your input");
                var response = await action.Invoke();
                serviceResponse.Object = response.Object;
            }
            catch (TestAPIException ex)
            {
                serviceResponse.Code = ex.ErrorCode;
                serviceResponse.ShortDescription = ex.Message;

                if (!ModelState.IsValid)
                {
                    serviceResponse.ValidationErrors = ModelState.ToDictionary(
                        m =>
                        {
                            var tokens = m.Key.Split('.');
                            return tokens.Length > 0 ? tokens[tokens.Length - 1] : tokens[0];
                        },
                        m => m.Value.Errors.Select(e => e.Exception?.Message ?? e.ErrorMessage)
                    );
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Code = HttpHelpers.GetStatusCode(HttpStatusCode.InternalServerError);
                serviceResponse.ShortDescription = ex.Message;
            }
            return serviceResponse;
        }

    }
}
