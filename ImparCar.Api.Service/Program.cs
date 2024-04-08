using ImparCar.Api.Service;
using ImparCar.CrossCuting;
using ImparCar.Infra.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

DependencyInjector.Register(builder.Services);
SetupIOC.AddEntityFrameworkServices(builder);
SetupIOC.AddAutoMapperServicess(builder);

builder.Services.AddGraphQLServer()
    .AddQueryType<QueryCar>()
    .AddMutationType<MutationCar>()
    .AddType<CarType>()
    .AddType<PhotoType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGraphQL();
});

app.Run();

public partial class Program { }