using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Infra.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImparCar.Infra.Repositories
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
    where TEntity : class
    {
        private readonly SqlContexts _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(SqlContexts context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
            await _transaction!.CommitAsync();
        }
        public async Task RollBackAsync()
        {
            await _transaction!.RollbackAsync();
        }

        public IBaseRepository<TEntity> BaseRepository => new BaseRepository<TEntity>(_context);
        public ICarRepository CarRepository => new CarRepository(_context);
        public IPhotoRepository PhotoRepository => new PhotoRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
