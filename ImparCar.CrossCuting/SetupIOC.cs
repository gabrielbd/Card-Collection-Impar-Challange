using ImparCar.Infra.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ImparCar.CrossCuting
{
    public static class SetupIOC
    {
        public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("ImparCar");

            builder.Services.AddDbContext<SqlContexts>(options => options.UseSqlServer(connectionString));
        }

        public static void AddAutoMapperServicess(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }


    }
}
