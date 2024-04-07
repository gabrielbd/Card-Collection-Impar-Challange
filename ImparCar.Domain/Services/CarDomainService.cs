using ImparCar.Domain.Entities;
using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Domain.Interfaces.Services;

namespace ImparCar.Domain.Services
{
    public class CarDomainService : BaseDomainService<Car>, ICarDomainService
    {
        private readonly IUnitOfWork<Car> _unitOfWork;
        public CarDomainService(IUnitOfWork<Car> unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Car>> GetAllCarsWithPhotosAsync()
        {
            return await _unitOfWork.CarRepository.GetAllCarsWithPhotosAsync();
        }

        public async Task<Car> GetByIdWithPhotoAsync(Guid id)
        {
            return await _unitOfWork.CarRepository.GetByIdWithPhotoAsync(id);
        }
    }
}
