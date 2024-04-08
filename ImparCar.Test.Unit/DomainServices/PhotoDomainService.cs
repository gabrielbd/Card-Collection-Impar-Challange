using FluentAssertions;
using ImparCar.Domain.Entities;
using ImparCar.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImparCar.Test.Unit.DomainServices
{
    public class PhotoDomainService
    {
        private readonly IUnitOfWork<Car> _unitOfWork;

        public PhotoDomainService(IUnitOfWork<Car> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var photo = await GenerationPhotoFake();
            var photoAll = await _unitOfWork.PhotoRepository.GetAllAsync();
            photoAll.FirstOrDefault(g => g.Id == photo.Id).Should().NotBeNull();

            await _unitOfWork.PhotoRepository.DeleteAsync(photo.Id);

        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var photo = await GenerationPhotoFake();
            var photoById = await _unitOfWork.PhotoRepository.GetByIdAsync(photo.Id);
            photoById.Should().NotBeNull();

            await _unitOfWork.PhotoRepository.DeleteAsync(photo.Id);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var photo = await GenerationPhotoFake();
            photo.Base64 = Encoding.UTF8.GetBytes("FakeBase64DataTeste");

            await _unitOfWork.PhotoRepository.UpdateAsync(photo);
            var photoById = await _unitOfWork.PhotoRepository.GetByIdAsync(photo.Id);
            photoById.Should().NotBeNull();

            await _unitOfWork.PhotoRepository.DeleteAsync(photo.Id);

        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var photo = await GenerationPhotoFake();
            await _unitOfWork.PhotoRepository.DeleteAsync(photo.Id);

            var photoById = await _unitOfWork.PhotoRepository.GetByIdAsync(photo.Id);
            photoById.Should().BeNull();

        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var photo = await GenerationPhotoFake();
            var photoById = await _unitOfWork.PhotoRepository.GetByIdAsync(photo.Id);
            photoById.Should().NotBeNull();

            await _unitOfWork.PhotoRepository.DeleteAsync(photo.Id);

        }


        private async Task<Photo> GenerationPhotoFake()
        {
            var photo = new Photo
            {
                Id = Guid.NewGuid(),
                Base64 = Encoding.UTF8.GetBytes("FakeBase64Data")
            };
            await _unitOfWork.PhotoRepository.CreateAsync(photo);

            return photo;
        }
    }
}
