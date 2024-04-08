using ImparCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImparCar.Test.Unit.Entities
{
    public class CarTests
    {
        [Fact]
        public void CanCreateCarInstance()
        {
            var car = new Car();
            Assert.NotNull(car);
        }

        [Fact]
        public void CanSetCarProperties()
        {
            var car = new Car();
            var id = Guid.NewGuid();
            var photoId = Guid.NewGuid();
            var name = "Test Car";
            var status = "Active";
            var photo = new Photo();

            car.Id = id;
            car.PhotoId = photoId;
            car.Name = name;
            car.Status = status;
            car.Photo = photo;

            Assert.Equal(id, car.Id);
            Assert.Equal(photoId, car.PhotoId);
            Assert.Equal(name, car.Name);
            Assert.Equal(status, car.Status);
            Assert.Equal(photo, car.Photo);
        }
    }
}
