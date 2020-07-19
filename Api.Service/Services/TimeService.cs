using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application;
using Application.ViewModel.Time;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.PageList;
using Domain.Parameters;
using Microsoft.EntityFrameworkCore.Design;

namespace Service.Services
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _repository;

        public TimeService(ITimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<TimeEntity> SelectCodigoAsync(string sigla)
        {
            return await _repository.SelectCodigoAsync(sigla);
        }
        public async Task<TimeEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<PagedList<TimeEntity>> GetAll(ParametersPage parametersPage)
        {
            return await _repository.SelectPaged(parametersPage);
        }

        public async Task<IEnumerable<TimeEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<TimeEntity> Post(TimeEntity user)
        {
            var result = await _repository.InsertAsync(user);
            await _repository.Commit();
            return result;
        }

        public async Task<TimeEntity> Put(TimeEntity user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<bool> Delete(Guid id)
        { 
            return await _repository.DeleteAsync(id);
        }

        public IList<TimeEntity> Get(Expression<Func<TimeEntity, bool>> predicate)
        {
            return _repository.Get(predicate);
        }

        public async Task Commit()
        {
            await _repository.Commit();
        }

        public void Dispose()
        {
             _repository.Dispose();
        }
    }
}