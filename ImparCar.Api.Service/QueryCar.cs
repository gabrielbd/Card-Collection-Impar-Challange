using ImparCar.Application.Interfaces.Handlers;
using ImparCar.Application.Requests.Car;
using ImparCar.Application.Response.Car;

namespace ImparCar.Api.Service
{
    public class QueryCar
    {
        public async Task<CarResponse> ConsultarPorId([Service] ICarHandler handler, Guid id)
        {
            return await handler.GetByIdAsync(id);
        }
        public async Task<List<CarResponse>> ConsultarTodos([Service] ICarHandler handler)
        {
            return await handler.GetAllListAsync();
        }
    }
}
