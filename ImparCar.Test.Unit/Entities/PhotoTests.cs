using ImparCar.Domain.Entities;
using Xunit;

namespace ImparCar.Tests
{
    public class PhotoTests
    {
        [Fact]
        public void CanCreatePhotoInstance()
        {
            var photo = new Photo();
            Assert.NotNull(photo);
        }

        [Fact]
        public void CanSetPhotoProperties()
        {
            var photo = new Photo();
            var id = Guid.NewGuid();
            var base64 = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 };
            var car = new Car();

            photo.Id = id;
            photo.Base64 = base64;
            photo.Car = car;

            Assert.Equal(id, photo.Id);
            Assert.Equal(base64, photo.Base64);
            Assert.Equal(car, photo.Car);
        }
    }
}