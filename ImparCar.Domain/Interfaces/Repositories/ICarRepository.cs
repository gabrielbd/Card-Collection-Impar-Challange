using ImparCar.Domain.Entities;

namespace ImparCar.Domain.Interfaces.Repositories
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<List<Car>> GetAllCarsWithPhotosAsync();
        Task<Car> GetByIdWithPhotoAsync(Guid id);
    }
}
