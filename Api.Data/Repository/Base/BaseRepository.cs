using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository.Base;
using Domain.PageList;
using Domain.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Base
{
    public class BaseRepository<T>: IRepository<T> where T: BaseEntity
    {
        protected readonly MyContext _context;
        private readonly DbSet<T> _dataset;

        protected BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }
        public async Task<T> InsertAsync(T item)
        {
            if (item.isDeleted) return null;
            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();
            item.isDeleted = false;
            item.CreateAt = DateTime.UtcNow;
            _context.Entry(item).State = EntityState.Added; 
            await _dataset.AddAsync(item);

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(item.Id) && !x.isDeleted);
            if (result == null) return null;
            item.UpdateAt = DateTime.UtcNow;
            item.CreateAt = result.CreateAt;
                
            _context.Entry(result).State = EntityState.Modified;
            _context.Entry(result).CurrentValues.SetValues(item);

            return item;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id) && !x.isDeleted);
                if (result == null) return false;
                result.isDeleted = true;
                result.DateDeletedAt = DateTime.Now;
                _context.Entry(result).State = EntityState.Modified;
                _context.Entry(result).CurrentValues.SetValues(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return true;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            return await _dataset.SingleOrDefaultAsync(x => x.Id.Equals(id) && !x.isDeleted);
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(x => x.Id.Equals(id) && !x.isDeleted);
        }
        public async Task<IEnumerable<T>> SelectAsync(ParametersPage parametersPage)
        {
            return await _dataset.Where(x=>!x.isDeleted).Skip((parametersPage.PageNumber - 1) * parametersPage.PageSize)
                .Take(parametersPage.PageSize).AsNoTracking().
                ToListAsync();
        }
        
        public async Task<PagedList<T>> SelectPaged(ParametersPage parametersPage)
        {
            return  await Task.FromResult(PagedList<T>.ToPagedList( _dataset.Where(x=>!x.isDeleted).AsNoTracking(),
                parametersPage.PageNumber,
                parametersPage.PageSize));
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataset.Where(x=>!x.isDeleted).ToListAsync();
        }

        public IList<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dataset.Where(predicate).Where(x => !x.isDeleted).AsNoTracking().ToList();
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}