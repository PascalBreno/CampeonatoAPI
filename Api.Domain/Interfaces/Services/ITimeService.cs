using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Services.Base;

namespace Domain.Interfaces.Services
{
    public interface ITimeService : IBaseService<TimeEntity>
    {
        Task<TimeEntity> SelectCodigoAsync(string sigla);
    }
}