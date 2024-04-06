using ImparCar.Domain.Entities;
using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Domain.Interfaces.Services;

namespace ImparCar.Domain.Services
{
    public class PhotoDomainService : BaseDomainService<Photo>, IPhotoDomainService
    {
        public PhotoDomainService(IUnitOfWork<Photo> unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
