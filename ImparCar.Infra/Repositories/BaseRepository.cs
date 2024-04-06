using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImparCar.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly SqlContexts _context;

        public BaseRepository(SqlContexts context)
            : base()
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {

            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            TEntity? entity = await _context.Set<TEntity>().FindAsync(id).AsTask();
            return entity;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task DeleteAsync(Guid id)
        {
            var data = await _context.Set<TEntity>().FindAsync(id).AsTask();
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
