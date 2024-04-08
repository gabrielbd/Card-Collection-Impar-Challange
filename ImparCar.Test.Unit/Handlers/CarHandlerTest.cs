using FluentAssertions;
using ImparCar.Domain.Entities;
using ImparCar.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImparCar.Test.Unit.Handlers
{
    public class CarHandlerTest
    {
        private readonly ICarDomainService _carDomainService;
        private readonly IPhotoDomainService _photoDomainService;

        public CarHandlerTest(ICarDomainService carDomainService, IPhotoDomainService photoDomainService)
        {
            _carDomainService = carDomainService;
            _photoDomainService = photoDomainService;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var car = await GenerationCarFake();
            var carAll = await _carDomainService.GetAllAsync();
            carAll.FirstOrDefault(g => g.Id == car.Id).Should().NotBeNull();

            await _carDomainService.DeleteAsync(car.Id);
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var car = await GenerationCarFake();
            var carById = await _carDomainService.GetByIdAsync(car.Id);
            carById.Should().NotBeNull();

            await _carDomainService.DeleteAsync(car.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var car = await GenerationCarFake();
            car.Name = "NAME CAR TEST";

            await _carDomainService.UpdateAsync(car);
            var carById = await _carDomainService.GetByIdAsync(car.Id);
            carById.Should().NotBeNull();

            await _carDomainService.DeleteAsync(car.Id);
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var car = await GenerationCarFake();
            await _carDomainService.DeleteAsync(car.Id);

            var carById = await _carDomainService.GetByIdAsync(car.Id);
            carById.Should().BeNull();

        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var car = await GenerationCarFake();
            var carById = await _carDomainService.GetByIdAsync(car.Id);
            carById.Should().NotBeNull();

            await _carDomainService.DeleteAsync(car.Id);

        }



        private async Task<Car> GenerationCarFake()
        {
            var photo = new Photo
            {
                Id = Guid.NewGuid(),
                Base64 = Encoding.UTF8.GetBytes("FakeBase64Data")
            };
            await _photoDomainService.CreateAsync(photo);

            var car = new Car
            {
                Name = "CAR TEST",
                Status = "1",
                PhotoId = photo.Id,
                Photo = photo
            };
            await _carDomainService.CreateAsync(car);
            return car;
        }

    }
}
