using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Services.Base;

namespace Domain.Interfaces.Services
{
    public interface ICampeonatoService : IBaseService<CampeonatoEntity>
    {
        Task<CampeonatoEntity> GetByCod(string codigoCampeonato);
    }
}