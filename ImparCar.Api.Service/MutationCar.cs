using ImparCar.Application.Interfaces.Handlers;
using ImparCar.Application.Requests.Car;
using ImparCar.Application.Response.Car;
using Microsoft.AspNetCore.Mvc;


namespace ImparCar.Api.Service
{
    public class MutationCar
    {
        public async Task<CreateCarResponse> CriarCardCarro([Service] ICarHandler handler, CreateCarRequest request)
        {
            return await handler.CreateAsync(request);
        }
        public async Task<UpdateCarResponse> EditarCardCarro([Service] ICarHandler handler, UpdateCarRequest request)
        {
            return await handler.UpdateAsync(request);
        }
        public async Task<bool> DeletedCar ([Service] ICarHandler handler,  Guid id)
        {
            await handler.DeleteAsync(id);
            return true;
        }
    }
}
