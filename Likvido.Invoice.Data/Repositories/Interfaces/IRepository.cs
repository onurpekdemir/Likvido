using Likvido.Invoice.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Likvido.Invoice.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);
        Task<IList<T>> ListAsync();
        Task InsertAsync(T entity);
        Task Delete(int id);
        void Update(T entity);
    }
}
