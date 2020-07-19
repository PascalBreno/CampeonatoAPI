using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.AppService;
using Domain.Interfaces.Services;
using Domain.PageList;
using Domain.Parameters;

namespace Application.AppServices
{
    public class TimeAppService : ITimeAppService
    {
        private readonly ITimeService _timeService;

        public TimeAppService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public async Task<TimeEntity> Get(Guid id)
        {
            return await _timeService.Get(id);
        }
        public async Task<TimeEntity> SelectCodigoAsync(string sigla)
        {
            return await _timeService.SelectCodigoAsync(sigla);
        }

        public async Task<PagedList<TimeEntity>> GetAll(ParametersPage parametersPage)
        {
            return await _timeService.GetAll(parametersPage);
        }

        public async Task<IEnumerable<TimeEntity>> GetAll()
        {
            return await _timeService.GetAll();
        }

        public async Task<TimeEntity> Post(TimeEntity timeEntity)
        {
            try
            {
                var result = await _timeService.Post(timeEntity);
                await _timeService.Commit();
                return result;
            }
            catch (Exception)
            {
                 _timeService.Dispose();
                throw;
            }
        }

        public async Task<TimeEntity> Put(TimeEntity timeEntity)
        {
            try
            {
                var result = await _timeService.Put(timeEntity);
                await _timeService.Commit();
                return result;
            }
            catch (Exception)
            {
                _timeService.Dispose();
                throw;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _timeService.Delete(id);
                await _timeService.Commit();
                return result;
            }
            catch (Exception)
            {
                _timeService.Dispose();
                throw;
            }
        }

        public IList<TimeEntity> Get(Expression<Func<TimeEntity, bool>> predicate)
        {
            return _timeService.Get(predicate);
        }
    }
}