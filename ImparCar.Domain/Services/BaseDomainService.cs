using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Domain.Interfaces.Services;

namespace ImparCar.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
     where TEntity : class
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;

        public BaseDomainService(IUnitOfWork<TEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var data = await _unitOfWork.BaseRepository.CreateAsync(entity);
            return data;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var data = await _unitOfWork.BaseRepository.UpdateAsync(entity);
            return data;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _unitOfWork.BaseRepository.GetAllAsync();
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            return _unitOfWork.BaseRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.BaseRepository.DeleteAsync(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
