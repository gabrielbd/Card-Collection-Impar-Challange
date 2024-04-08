using FluentAssertions;
using ImparCar.Domain.Entities;
using ImparCar.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImparCar.Test.Unit.Repositories
{
    public class CarRepositoryTest
    {
        private readonly SqlContexts _context;

        public CarRepositoryTest(SqlContexts contexts)
        {
            this._context = contexts;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var car = await GenerationCarFake();

            var getAllTask = _context.Set<Car>().ToListAsync();
            await getAllTask; 

            var getAllResult = getAllTask.Result;

            getAllResult.FirstOrDefault(g => g.Id == car.Id).Should().NotBeNull();

            _context.Entry(car).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var car = await GenerationCarFake();

            Car? entity = await _context.Set<Car>().FindAsync(car.Id).AsTask();
            entity.Should().NotBeNull();

            _context.Entry(car).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var car = await GenerationCarFake();
            car.Name = "NAME GAME TEST";

            _context.Set<Car>().Update(car);
            await _context.SaveChangesAsync();

            Car? entity = await _context.Set<Car>().FindAsync(car.Id).AsTask();
            entity.Should().NotBeNull();

            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var car = await GenerationCarFake();

            _context.Entry(car).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            Car? entity = await _context.Set<Car>().FindAsync(car.Id).AsTask();
            entity.Should().BeNull();
        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var car = await GenerationCarFake();
            Car? entity = await _context.Set<Car>().FindAsync(car.Id).AsTask();
            entity.Should().NotBeNull();
            
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        private async Task<Car> GenerationCarFake()
        {
            var photo = new Photo
            {
                Id = Guid.NewGuid(),
                Base64 = Encoding.UTF8.GetBytes("FakeBase64Data")
            };

            await _context.Set<Photo>().AddAsync(photo);
            await _context.SaveChangesAsync();

            var car = new Car
            {
                Name = "CAR TEST",
                Status = "1",
                PhotoId = photo.Id
            };

            await _context.Set<Car>().AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
