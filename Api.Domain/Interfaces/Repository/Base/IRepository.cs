using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.PageList;
using Domain.Parameters;

namespace Domain.Interfaces.Repository.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync(ParametersPage parametersPage);
        Task<IEnumerable<T>> SelectAsync();
        public Task<bool> ExistAsync(Guid id);
        Task<PagedList<T>> SelectPaged(ParametersPage parametersPage);
        public IList<T> Get(Expression<Func<T, bool>> predicate);
        Task Commit();
        void Dispose();
    }
}