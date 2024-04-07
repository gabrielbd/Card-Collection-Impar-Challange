using ImparCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImparCar.Domain.Interfaces.Services
{
    public interface ICarDomainService : IBaseDomainService<Car>
    {
        Task<List<Car>> GetAllCarsWithPhotosAsync();
        Task<Car> GetByIdWithPhotoAsync(Guid id);


    }
}
