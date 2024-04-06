using ImparCar.Domain.Entities;
using ImparCar.Infra.Contexts;

namespace ImparCar.Infra.Types
{
    public class CarType : ObjectType<Car>
    {
        protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
        {
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Status);
            descriptor.Field("photo")
                .ResolveWith<CarResolvers>(x => x.GetPhoto(default!, default!))
                .UseDbContext<SqlContexts>();
        }
    }

    public class CarResolvers
    {
        public async Task<Photo> GetPhoto(Car car, [ScopedService] SqlContexts context)
        {
            return await context.Photo.FindAsync(car.PhotoId);
        }
    }
}