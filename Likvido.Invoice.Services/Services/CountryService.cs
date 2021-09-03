using AutoMapper;
using Likvido.Invoice.Data.Repositories.Interfaces;
using Likvido.Invoice.Entities;
using Likvido.Invoice.Services.Constants;
using Likvido.Invoice.Services.DomainModels;
using Likvido.Invoice.Services.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likvido.Invoice.Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memCache;

        public CountryService(ICountryRepository countryRepository, IMapper mapper, IMemoryCache memCache)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _memCache = memCache;
        }

        public async Task<List<CountryDomainModel>> GetCountries()
        {
            if (!_memCache.TryGetValue(CacheKeys.COUNTRY, out List<CountryDomainModel> countries))
            {
                var countryList = await _countryRepository.ListAsync();
                var countryDomainModelList = _mapper.Map<List<CountryDomainModel>>(countryList.OrderBy(s => s.Name));

                _memCache.Set(CacheKeys.COUNTRY, countryDomainModelList);

                return countryDomainModelList;
            }

            return countries;
        }
    }
}
