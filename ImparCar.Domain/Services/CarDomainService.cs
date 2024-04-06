using ImparCar.Domain.Entities;
using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Domain.Interfaces.Services;

namespace ImparCar.Domain.Services
{
    public class CarDomainService : BaseDomainService<Car>, ICarDomainService
    {
        public CarDomainService(IUnitOfWork<Car> unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
