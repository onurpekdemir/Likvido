using Likvido.Invoice.Data.Contexts;
using Likvido.Invoice.Data.Repositories.Interfaces;
using Likvido.Invoice.Entities;
using System;

namespace Likvido.Invoice.Data.Repositories.Interfaces
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly InvoiceContext _invoiceContext;
        public CountryRepository(InvoiceContext invoiceContext) : base(invoiceContext)
        {
            _invoiceContext = invoiceContext;
        }

    }
}
