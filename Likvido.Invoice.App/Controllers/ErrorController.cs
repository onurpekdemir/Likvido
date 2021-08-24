using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Likvido.Invoice.App.Models;
using Likvido.Invoice.ApiClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace Likvido.Invoice.App.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController()
        {

        }
        [Route("error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exceptionMessage = context.Error.Message; // Your exception
            ViewBag.ErrorMessage = exceptionMessage;

            return View();
        }
    }
}
