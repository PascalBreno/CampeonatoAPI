using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.PageList;
using Domain.Parameters;
using Microsoft.EntityFrameworkCore.Design;

namespace Service.Services
{
    public class CampeonatoService : ICampeonatoService, IDisposable
    {
        private readonly ICampeonatoRepository _repository;
        private readonly IPartidaService _partidaService;
        private readonly ITimeService _timeservice;
        private readonly IPontuacaoCampeonatoRepository _pontuacaoCampeonatoRepository;

        public CampeonatoService(ICampeonatoRepository repository, IPartidaService service, ITimeService timeservice,
            IPontuacaoCampeonatoRepository pontuacaoCampeonatoRepository)
        {
            _repository = repository;
            _partidaService = service;
            _timeservice = timeservice;
            _pontuacaoCampeonatoRepository = pontuacaoCampeonatoRepository;
        }

        public async Task<CampeonatoEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<CampeonatoEntity> GetByCod(string codigoCampeonato)
        {
            return await _repository.SelectCodigoAsync(codigoCampeonato);
        }

        public async Task<PagedList<CampeonatoEntity>> GetAll(ParametersPage parametersPage)
        {
            return await _repository.SelectPaged(parametersPage);
        }
  public async Task<IEnumerable<CampeonatoEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<CampeonatoEntity> Post(CampeonatoEntity campeonato)
        {
            try
            {
                var pontuacaoCampeonatoList = new List<PontuacaoCampeonatoEntity>();
                var result = await _repository.InsertAsync(campeonato);
                var times = _timeservice.GetAll();
                foreach (var time in times.Result)
                {
                    PontuacaoCampeonatoEntity pontuacao = new PontuacaoCampeonatoEntity
                    {
                        time = time, codigoCampeonato = result.codigoCampeonato
                    };
                    pontuacaoCampeonatoList.Add(await _pontuacaoCampeonatoRepository.InsertAsync(pontuacao));
                }

                var random = new Random();
                List<PartidaEntity> partidas = new List<PartidaEntity>();
                foreach (var time in times.Result)
                {
                    foreach (var time2 in times.Result)
                    {
                        if (time == time2) continue;
                        if (partidas.Any(x =>
                            (x.timeA == time && x.timeB == time2) || (x.timeA == time2 && x.timeB == time))) continue;
                        PartidaEntity partida = new PartidaEntity
                        {
                            timeA = time, timeB = time2, golsA = random.Next(0, 7), golsB = random.Next(0, 7)
                        };
                        DateTime DataPermitida = DataCampeonato();
                        partida.data = DataPermitida;
                        partida.codigoCampeonato = result.codigoCampeonato;
                        var resultPartida = await _partidaService.Post(partida);
                        if (resultPartida != null)
                            partidas.Add(partida);
                    }
                }

                var pontuacaoList = await adicionarPartidaPontuacao(partidas, pontuacaoCampeonatoList);
                campeonato.partidas = partidas;
                result.campeao = pontuacaoList.OrderByDescending(x => x.pontuacaoTime).Select(x => x.time).FirstOrDefault();
                result.vici = pontuacaoList.OrderByDescending(x => x.pontuacaoTime).Select(x => x.time).ElementAt(2);
                result.terceiro = pontuacaoList.OrderByDescending(x => x.pontuacaoTime).Select(x => x.time).ElementAt(3);
                result.dataFinal = partidas.OrderBy(x => x.data).LastOrDefault()?.data;
                await _repository.UpdateAsync(result);
                return result;
            }
            catch (Exception)
            {
                _repository.Dispose();
            }
            return null;
        }

        private async Task<List<PontuacaoCampeonatoEntity>> adicionarPartidaPontuacao(IEnumerable<PartidaEntity> partidas, List<PontuacaoCampeonatoEntity> pontuacaoCampeonatoList)
        {
            
            foreach (var partida in partidas.Select((value, i) => new { i, value }))
            {
                PontuacaoCampeonatoEntity first;
                IEnumerable<PontuacaoCampeonatoEntity> pontuacaoCampeonatoEntities = pontuacaoCampeonatoList.ToList();
                if (pontuacaoCampeonatoEntities.Any(x => x.time == partida.value.timeA))
                {
                    first = pontuacaoCampeonatoEntities.FirstOrDefault(x => x.time == partida.value.timeA);

                    if (first != null)
                        first.pontuacaoTime +=
                            partida.value.golsA != partida.value.golsB ? (partida.value.golsA > partida.value.golsB ? 3 : 0) : 1;
                    await _pontuacaoCampeonatoRepository.UpdateAsync(first);
                    pontuacaoCampeonatoList[pontuacaoCampeonatoList.FindIndex(x=>x.time==first?.time)] =first;
                }

                if (pontuacaoCampeonatoEntities.All(x => x.time != partida.value.timeB)) continue;
                {
                    first = pontuacaoCampeonatoEntities.FirstOrDefault(x => x.time == partida.value.timeB);

                    if (first != null)
                        first.pontuacaoTime +=
                            partida.value.golsB != partida.value.golsA ? (partida.value.golsB > partida.value.golsA ? 3 : 0) : 1;
                    await _pontuacaoCampeonatoRepository.UpdateAsync(first);
                    pontuacaoCampeonatoList[pontuacaoCampeonatoList.FindIndex(x=>x.time==first?.time)] =first;
                }


            }

            return pontuacaoCampeonatoList;
        }

        //Funcao que verifica uma data random permitida dentro do periodo de um ano
        private static DateTime DataCampeonato()
        {
            var random = new Random();
            var dateTime = DateTime.Now;
            dateTime = dateTime.AddDays(random.Next(0, 365));
            return dateTime;
        }

        public async Task<CampeonatoEntity> Put(CampeonatoEntity user)
        {
            return await _repository.UpdateAsync(user);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public IList<CampeonatoEntity> Get(Expression<Func<CampeonatoEntity, bool>> predicate)
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