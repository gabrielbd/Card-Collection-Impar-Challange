using ImparCar.Application.Requests.Car;
using ImparCar.Application.Response.Car;

namespace ImparCar.Application.Interfaces.Handlers
{
    public interface ICarHandler
    {
        Task<CreateCarResponse> CreateAsync(CreateCarRequest request);
        Task<UpdateCarResponse> UpdateAsync(UpdateCarRequest request);
        Task DeleteAsync(Guid id);
        Task<List<CarResponse>> GetAllListAsync();
        Task<CarResponse> GetByIdAsync(Guid id);
    }
}
