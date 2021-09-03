using Likvido.Invoice.Data.Contexts;

namespace Likvido.Invoice.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InvoiceContext _invoiceContext;

        public UnitOfWork(InvoiceContext invoiceContext)
        {
            _invoiceContext = invoiceContext;
        }

        public int Save()
        {
            return _invoiceContext.SaveChanges();
        }
    }
}
