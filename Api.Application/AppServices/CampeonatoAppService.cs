using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.AppService;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.PageList;
using Domain.Parameters;

namespace Application.AppServices
{
    public class CampeonatoAppService : ICampeonatoAppServices
        
    {
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoAppService(ICampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }

        public async Task<CampeonatoEntity> Get(Guid id)
        {
            return await _campeonatoService.Get(id);
        }

        public async Task<PagedList<CampeonatoEntity>> GetAll(ParametersPage parametersPage)
        {
            return await _campeonatoService.GetAll(parametersPage);
        }

        public async Task<IEnumerable<CampeonatoEntity>> GetAll()
        {
            return await _campeonatoService.GetAll();
        }

        public async Task<CampeonatoEntity> Post(CampeonatoEntity user)
        {
            try
            {
                var result = await _campeonatoService.Post(user);
                await _campeonatoService.Commit();
                return await _campeonatoService.GetByCod(result.codigoCampeonato);
            }
            catch (Exception)
            {
                _campeonatoService.Dispose();
                throw;
            }
        }

        public async Task<CampeonatoEntity> Put(CampeonatoEntity user)
        {
            var result= await _campeonatoService.Put(user);
            await _campeonatoService.Commit();
            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _campeonatoService.Delete(id);
                await _campeonatoService.Commit();
                return  result;
            }
            catch (Exception)
            {
                _campeonatoService.Dispose();
                throw;
            }
        }

        public IList<CampeonatoEntity> Get(Expression<Func<CampeonatoEntity, bool>> predicate)
        {
            return  _campeonatoService.Get(predicate);
        }

        public async Task<CampeonatoEntity> GetByCod(string codigoCampeonato)
        {
            return await _campeonatoService.GetByCod(codigoCampeonato);
        }
    }
}