using FluentAssertions;
using ImparCar.Domain.Entities;
using ImparCar.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Xunit;

namespace ImparCar.Test.Unit.Repositories
{
    public class PhotoRepositoryTest
    {
        private readonly SqlContexts _context;

        public PhotoRepositoryTest(SqlContexts context)
        {
            _context = context;
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
            var photo = await GenerationPhotoFake();

            var getAllTask = _context.Set<Photo>().ToListAsync();
            await getAllTask;

            var getAllResult = getAllTask.Result;

            getAllResult.FirstOrDefault(g => g.Id == photo.Id).Should().NotBeNull();

            _context.Entry(photo).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var photo = await GenerationPhotoFake();

            Photo? entity = await _context.Set<Photo>().FindAsync(photo.Id).AsTask();
            entity.Should().NotBeNull();

            _context.Entry(photo).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var photo = await GenerationPhotoFake();
            photo.Base64 = Encoding.UTF8.GetBytes("FakeBase64DataTeste");

            _context.Set<Photo>().Update(photo);
            await _context.SaveChangesAsync();

            Photo? entity = await _context.Set<Photo>().FindAsync(photo.Id).AsTask();
            entity.Should().NotBeNull();

            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task TestDeletAsync()
        {
            var photo = await GenerationPhotoFake();

            _context.Entry(photo).State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            Photo? entity = await _context.Set<Photo>().FindAsync(photo.Id).AsTask();
            entity.Should().BeNull();
        }


        [Fact]
        public async Task TestByIdAsync()
        {
            var photo = await GenerationPhotoFake();
            Photo? entity = await _context.Set<Photo>().FindAsync(photo.Id).AsTask();
            entity.Should().NotBeNull();

            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        private async Task<Photo> GenerationPhotoFake()
        {
            var photo = new Photo
            {
                Id = Guid.NewGuid(),
                Base64 = Encoding.UTF8.GetBytes("FakeBase64Data")
            };

            await _context.Set<Photo>().AddAsync(photo);
            await _context.SaveChangesAsync();
            
            return photo;
        }
    }
}
