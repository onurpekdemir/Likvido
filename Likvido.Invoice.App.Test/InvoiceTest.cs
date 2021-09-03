using AutoMapper;
using Likvido.Invoice.ApiClient;
using Likvido.Invoice.ApiClient.Settings;
using Likvido.Invoice.App.Controllers;
using Likvido.Invoice.App.ViewModels;
using Likvido.Invoice.Data.Repositories.Interfaces;
using Likvido.Invoice.Entities;
using Likvido.Invoice.Services.Profiles;
using Likvido.Invoice.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Likvido.Invoice.App.Test
{
    public class InvoiceTest
    {
        public readonly InvoiceController _controller;

        public InvoiceTest()
        {
            var _countryRepoMock = new Mock<ICountryRepository>();
            _countryRepoMock
                .As<IRepository<Country>>()
                .Setup(x => x.ListAsync())
                .ReturnsAsync(new List<Country>()).Verifiable();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainModelToViewModel());
            });
            var mapper = mapperConfiguration.CreateMapper();

            var cache = new MemoryCache(new MemoryCacheOptions());

            var countryService = new CountryService(_countryRepoMock.Object, mapper, cache);

            var apiConfiguration = new OptionsWrapper<ApiSettings>(new ApiSettings
            {
                Key = "DDqItrNJ4mFwosMB/mIYhspootAfaMrhcaWWbGuUUKA=",
                Uri = "https://api.likvido.com/api/v1/"
            });
            var apiCaller = new ApiCaller(apiConfiguration);

            _controller = new InvoiceController(apiCaller, countryService, mapper);
        }


        [Fact]
        public async Task Should_Return_Invoice_View_With_InvoiceList()
        {
            var result = await _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<InvoiceListViewModel>>(
                viewResult.ViewData.Model);

            Assert.Single(model);
        }

        [Fact]
        public async Task Should_Add_Invoice_WhenPrivateDebtor()
        {
            var invoice = new InvoiceCreateViewModel
            {
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(10),
                Debtor = new Debtor
                {
                    DebtorType = DebtorType.Private,
                    FirstName = "Onur",
                    LastName = "Pekdemir"
                },
                Lines = new List<Line>
                {
                    new Line{ Description = "test", DiscountType = DiscountType.Percent, DiscountValue = 2, Quantity = 3, UnitNetPrice = 5, VatRate = 8 }
                }
            };

            var result = await _controller.Add(invoice);
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task Should_Add_Invoice_WhenCompanyDebtor()
        {
            var invoice = new InvoiceCreateViewModel
            {
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(10),
                Debtor = new Debtor
                {
                    DebtorType = DebtorType.Company,
                    CompanyName = "smoke_test",
                },
                Lines = new List<Line>
                {
                    new Line{ Description = "test", DiscountType = DiscountType.Percent, DiscountValue = 2, Quantity = 3, UnitNetPrice = 5, VatRate = 8 }
                }
            };

            var result = await _controller.Add(invoice);
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task Should_Return_BadRequest_WhenAddingInvalidField()
        {
            var result = await _controller.Add(new InvoiceCreateViewModel());
            Assert.IsType<BadRequestObjectResult>(result);
        }


    }
}
