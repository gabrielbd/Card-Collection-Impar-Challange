using ImparCar.Domain.Entities;
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
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        private readonly SqlContexts _contexts;
        public CarRepository(SqlContexts context) : base(context)
        {
            _contexts = context;
        }

        public Task<List<Car>> GetAllCarsWithPhotosAsync()
        {
            return _contexts.Car.Include(c => c.Photo).ToListAsync();
        }

        public async Task<Car> GetByIdWithPhotoAsync(Guid id)
        {
            return await _contexts.Car.Include(c => c.Photo).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
