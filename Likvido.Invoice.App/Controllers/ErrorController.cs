using Likvido.Invoice.ApiClient.Errors;
using Likvido.Invoice.App.ViewModels;
using Likvido.Invoice.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Likvido.Invoice.App.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILog _logger;

        public ErrorController(ILog logger)
        {
            _logger = logger;
        }

        [Route("error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (context.Error.GetType() == typeof(ApiException))
            {
                var apiException = context.Error as ApiException;
                //an error occured in the API
                var apiError = new ErrorViewModel
                {
                    ErrorType = ErrorType.API,
                    Message = apiException.Message,
                    Details = apiException.Details
                };

                _logger.Error($"API Error | \n Message: {apiError.Message} \n Details: {apiError.Details}");

                return View(apiError);
            }

            var applicationException = context.Error;
            var applicationError = new ErrorViewModel
            {
                ErrorType = ErrorType.Application,
                Message = applicationException.Message,
                Details = applicationException.StackTrace
            };

            _logger.Error($"Application Error | \n Message: {applicationError.Message} \n Details: {applicationError.Details}");

            return View(applicationError);
        }
    }
}
