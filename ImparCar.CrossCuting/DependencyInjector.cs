using ImparCar.Application.Handlers;
using ImparCar.Application.Interfaces.Handlers;
using ImparCar.Application.Interfaces.Validators;
using ImparCar.Application.Validators;
using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Domain.Interfaces.Services;
using ImparCar.Domain.Services;
using ImparCar.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace ImparCar.CrossCuting
{
    public class DependencyInjector
    {

        public static void Register(IServiceCollection svcCollection)
        {

            // Handler
            svcCollection.AddTransient<ICarHandler, CarHandler>();
            svcCollection.AddTransient<ICarValidator, CarValidator>();


            // Domain
            svcCollection.AddTransient(typeof(IBaseDomainService<>), typeof(BaseDomainService<>));
            svcCollection.AddTransient<ICarDomainService, CarDomainService>();
            svcCollection.AddTransient<IPhotoDomainService, PhotoDomainService>();

            // Repository
            svcCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            svcCollection.AddTransient<ICarRepository, CarRepository>();
            svcCollection.AddTransient<IPhotoRepository, PhotoRepository>();

            // Unit of Work
            svcCollection.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }
    }
}
