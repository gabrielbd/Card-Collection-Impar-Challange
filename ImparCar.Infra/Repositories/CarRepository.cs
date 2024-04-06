using ImparCar.Domain.Entities;
using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImparCar.Infra.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(SqlContexts context) : base(context)
        {
        }
    }
}
