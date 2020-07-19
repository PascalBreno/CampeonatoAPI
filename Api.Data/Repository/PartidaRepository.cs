using Data.Context;
using Data.Repository.Base;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Repository
{
    public class PartidaRepository : BaseRepository<PartidaEntity>, IPartidaRepository
    {
        public PartidaRepository(MyContext context) : base(context)
        {
        }
    }
}