using Likvido.Invoice.Services.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Likvido.Invoice.Services.Services.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDomainModel>> GetCountries();
    }
}
