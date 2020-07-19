using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application;
using Application.ViewModel.Partida;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.PageList;
using Domain.Parameters;
using Microsoft.EntityFrameworkCore.Design;

namespace Service.Services
{
    public class PartidaService : IPartidaService
    {
        private readonly IPartidaRepository _repository;

        public PartidaService(IPartidaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartidaEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<PagedList<PartidaEntity>> GetAll(ParametersPage parametersPage)
        {
            return await _repository.SelectPaged(parametersPage);
        }

        public async Task<IEnumerable<PartidaEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<PartidaEntity> Post(PartidaEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<PartidaEntity> Put(PartidaEntity user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<bool> Delete(Guid id)
        { 
            return await _repository.DeleteAsync(id);
        }

        public IList<PartidaEntity> Get(Expression<Func<PartidaEntity, bool>> predicate)
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