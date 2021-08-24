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

namespace Likvido.Invoice.App.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IApiCaller _apiCaller;
        private readonly IMemoryCache _memCache;

        public InvoiceController(ILogger<InvoiceController> logger, IApiCaller apiCaller, IMemoryCache memCache)
        {
            _logger = logger;
            _apiCaller = apiCaller;
            _memCache = memCache;
        }

        public async Task<IActionResult> Index()
        {
            var apiResult = await _apiCaller.GetAsync<InvoiceListRootViewModel>("Invoices");
            return View(apiResult.Result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Countries = GetCountries();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(InvoiceCreateViewModel model)
        {
            var apiResult = await _apiCaller.Post("Invoices", model);
            return null;
        }

        private IEnumerable<SelectListItem> GetCountries()
        {
            if (!_memCache.TryGetValue("countries", out List<SelectListItem> countries))
            {
                var countryList = new List<SelectListItem>
                {
                    new SelectListItem{ Text="Denmark", Value = "1", Selected = true },
                    new SelectListItem{ Text="Turkey", Value = "2", Selected = false },
                    new SelectListItem{ Text="Germany", Value ="3", Selected = false },
                    new SelectListItem{ Text="Sweden", Value = "4", Selected = false },
                    new SelectListItem{ Text="Norway", Value = "5", Selected = false },
                    new SelectListItem{ Text="Italy", Value = "6", Selected = false },
                    new SelectListItem{ Text="Greece", Value = "7", Selected = false },
                    new SelectListItem{ Text="Finland", Value = "8", Selected = false },
                };

                //Bu satırda belirlediğimiz key'e göre ve ayarladığımız cache özelliklerine göre kategorilerimizi in-memory olarak cache'liyoruz.
                _memCache.Set("countries", countryList);

                return countryList;
            }

            return countries;
        }
    }
}
