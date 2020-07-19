using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.PageList;
using Domain.Parameters;

namespace Domain.Interfaces.AppService.Base
{
    public interface IBaseAppService <T> where T : BaseEntity
    {
        Task<T> Get(Guid id);
       
        Task<PagedList<T>> GetAll(ParametersPage parametersPage);
        Task<IEnumerable<T>> GetAll();
        Task<T> Post(T user);
        Task<T> Put(T user);
        Task<bool> Delete(Guid id);
        public IList<T> Get(Expression<Func<T, bool>> predicate);
    }
}