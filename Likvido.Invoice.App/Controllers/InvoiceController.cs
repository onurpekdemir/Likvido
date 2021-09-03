using AutoMapper;
using Likvido.Invoice.ApiClient;
using Likvido.Invoice.App.ViewModels;
using Likvido.Invoice.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likvido.Invoice.App.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IApiCaller _apiCaller;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public InvoiceController(IApiCaller apiCaller, ICountryService countryService, IMapper mapper)
        {
            _apiCaller = apiCaller;
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var apiResult = await _apiCaller.GetAsync<InvoiceListViewModel>("Invoices");
            return View(apiResult?.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var countries = await _countryService.GetCountries();
            ViewBag.Countries = _mapper.Map<List<SelectListItem>>(countries);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(InvoiceCreateViewModel model)
        {
            bool isValid;
            var validationResult = ValidateInvoice(model, out isValid);
            if (!isValid)
            {
                return validationResult;
            }

            var apiResult = await _apiCaller.Post<InvoiceCreateViewModel>("Invoices", model);
            if (apiResult.Errors != null)
            {
                return BadRequest(string.Join('\n', apiResult.Errors.Select(s => s.Title)));
            }

            return CreatedAtAction(nameof(Add), model);
        }

        private IActionResult ValidateInvoice(InvoiceCreateViewModel model, out bool isValid)
        {
            isValid = false;

            if (model.Date > model.DueDate)
            {
                return BadRequest("Invoice payment date must be equal or greater than invoice date ");
            }

            if (model.Debtor.DebtorType == DebtorType.Private && string.IsNullOrWhiteSpace(model.Debtor.FirstName))
            {
                return BadRequest("You must enter first name for debtor type of private");
            }

            if (model.Debtor.DebtorType == DebtorType.Company && string.IsNullOrWhiteSpace(model.Debtor.CompanyName))
            {
                return BadRequest("You must enter company name for debtor type of company");
            }

            if (model.Lines != null && (model.Lines.Count == 0 || model.Lines.Any(s => string.IsNullOrWhiteSpace(s.Description))))
            {
                return BadRequest("You must enter at least 1 line and fill in the description correctly");
            }

            isValid = true;
            return Ok();
        }

    }
}
