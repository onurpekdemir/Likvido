using Likvido.Invoice.Data.Contexts;
using Likvido.Invoice.Data.Repositories.Interfaces;
using Likvido.Invoice.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Likvido.Invoice.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly InvoiceContext _invoiceContext;

        public BaseRepository(InvoiceContext invoiceContext)
        {
            _invoiceContext = invoiceContext;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await this.GetAsync(id);
            _invoiceContext.Set<T>().Remove(entity);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _invoiceContext.Set<T>().FindAsync(id);
        }

        public virtual async Task InsertAsync(T entity)
        {
            await _invoiceContext.Set<T>().AddAsync(entity);
        }

        public virtual async Task<IList<T>> ListAsync()
        {
            return await _invoiceContext.Set<T>().ToListAsync();
        }

        public virtual void Update(T entity)
        {
            _invoiceContext.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
