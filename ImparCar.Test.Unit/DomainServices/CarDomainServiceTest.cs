using FluentAssertions;
using ImparCar.Domain.Entities;
using ImparCar.Domain.Interfaces.Repositories;
using System.Text;
using Xunit;

namespace ImparCar.Test.Unit.DomainServices
{
    public class CarDomainServiceTest
    {
        private readonly IUnitOfWork<Car> _unitOfWork;

        public CarDomainServiceTest(IUnitOfWork<Car> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var car = await GenerationCarFake();
            var carAll = await _unitOfWork.CarRepository.GetAllAsync();
            carAll.FirstOrDefault(g => g.Id == car.Id).Should().NotBeNull();

            await _unitOfWork.CarRepository.DeleteAsync(car.Id);

        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var car = await GenerationCarFake();
            var carById = await _unitOfWork.CarRepository.GetByIdAsync(car.Id);
            carById.Should().NotBeNull();

            await _unitOfWork.CarRepository.DeleteAsync(car.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var car = await GenerationCarFake();
            car.Name = "NAME CAR TEST";

            await _unitOfWork.CarRepository.UpdateAsync(car);
            var carById = await _unitOfWork.CarRepository.GetByIdAsync(car.Id);
            carById.Should().NotBeNull();

            await _unitOfWork.CarRepository.DeleteAsync(car.Id);

        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var car = await GenerationCarFake();
            await _unitOfWork.CarRepository.DeleteAsync(car.Id);

            var carById = await _unitOfWork.CarRepository.GetByIdAsync(car.Id);
            carById.Should().BeNull();

        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var car = await GenerationCarFake();
            var carById = await _unitOfWork.CarRepository.GetByIdAsync(car.Id);
            carById.Should().NotBeNull();

            await _unitOfWork.CarRepository.DeleteAsync(car.Id);

        }


        private async Task<Car> GenerationCarFake()
        {
            var photo = new Photo
            {
                Id = Guid.NewGuid(),
                Base64 = Encoding.UTF8.GetBytes("FakeBase64Data")
            };

            await _unitOfWork.PhotoRepository.CreateAsync(photo);

            var car = new Car
            {
                Name = "CAR TEST",
                Status = "1",
                PhotoId = photo.Id,
                Photo = photo
            };

            await _unitOfWork.CarRepository.CreateAsync(car);
            return car;
        }
    }
}

