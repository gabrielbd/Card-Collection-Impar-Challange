using ImparCar.Application.Interfaces.Handlers;
using ImparCar.Application.Requests.Car;
using ImparCar.Application.Response.Car;


namespace ImparCar.Api.Service
{
    public class MutationCar
    {
        public async Task<CreateCarResponse> CriarCard([Service] ICarHandler handler, CreateCarRequest request)
        {
            return await handler.CreateAsync(request);
        }
        public async Task<UpdateCarResponse> EditarCard([Service] ICarHandler handler, UpdateCarRequest request)
        {
            return await handler.UpdateAsync(request);
        }
        public async Task<bool> DeletedCard ([Service] ICarHandler handler,  Guid id)
        {
            await handler.DeleteAsync(id);
            return true;
        }
    }
}
