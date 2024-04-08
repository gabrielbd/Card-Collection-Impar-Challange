using ImparCar.Application.Handlers;
using ImparCar.Application.Interfaces.Handlers;
using ImparCar.Domain.Interfaces.Repositories;
using ImparCar.Domain.Interfaces.Services;
using ImparCar.Domain.Services;
using ImparCar.Infra.Contexts;
using ImparCar.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImparCar.Test.Unit
{
    public class Setup : Xunit.Di.Setup
    {
        protected override void Configure()
        {
            ConfigureServices((context, services) =>
            {
                // Configure your services here
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.Tests.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();
                var connectionString = root.GetSection("ConnectionStrings").GetSection("ImparCar").Value;
               
                services.AddDbContext<SqlContexts>(options => options.UseSqlServer(connectionString));

                services.AddTransient<ICarHandler, CarHandler>();
                services.AddTransient(typeof(IBaseDomainService<>), typeof(BaseDomainService<>));
                services.AddTransient<ICarDomainService, CarDomainService>();
                services.AddTransient<IPhotoDomainService, PhotoDomainService>();
                services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                services.AddTransient<ICarRepository, CarRepository>();
                services.AddTransient<IPhotoRepository, PhotoRepository>();
                services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            });
        }
    }
}