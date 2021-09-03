using AutoMapper;
using Likvido.Invoice.Data.Repositories.Interfaces;
using Likvido.Invoice.Entities;
using Likvido.Invoice.Services.Profiles;
using Likvido.Invoice.Services.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Likvido.Invoice.Services.Test
{
    public class CountryTest
    {

        [Fact]
        public async Task Should_Return_All_Countries()
        {
            var countries = new List<Country>()
            {
                new Country{Id = 1, Name = "Denmark", CreatedDate = new DateTime(2018,01,01), CreatedBy = 1, IsSelected = true},
                new Country{Id = 2, Name = "Turkey", CreatedDate = new DateTime(2018,01,02), CreatedBy = 1, IsSelected = false},
                new Country{Id = 3, Name = "Sweden", CreatedDate = new DateTime(2018,01,02), CreatedBy = 1, IsSelected = false},
                new Country{Id = 4, Name = "Spain", CreatedDate = new DateTime(2018,01,03), CreatedBy = 1, IsSelected = false},
            };

            int expectedCount = 4;

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDomainModelProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();

            var cache = new MemoryCache(new MemoryCacheOptions());

            var _countryRepoMock = new Mock<ICountryRepository>();
            _countryRepoMock
                .As<IRepository<Country>>()
                .Setup(x => x.ListAsync())
                .ReturnsAsync(countries).Verifiable();

            var countryService = new CountryService(_countryRepoMock.Object, mapper, cache);

            var countryServiceResultMock = await countryService.GetCountries();
            
            _countryRepoMock.Verify();
            
            Assert.NotNull(countryServiceResultMock);
            Assert.NotEmpty(countryServiceResultMock);
            Assert.Equal(expectedCount, countryServiceResultMock.Count());

        }
    }
}
