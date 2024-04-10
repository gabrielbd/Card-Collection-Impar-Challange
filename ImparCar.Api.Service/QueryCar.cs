using HotChocolate.Data;
using ImparCar.Application.Interfaces.Handlers;
using ImparCar.Application.Response.Car;
using ImparCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImparCar.Api.Service
{
    public class QueryCar
    {
        [UseFiltering]
        public async Task<CarResponse> ConsultarPorId([Service] ICarHandler handler, Guid id)
        {
            return await handler.GetByIdAsync(id);
        }

        [UseFiltering]
        public async Task<List<CarResponse>> ConsultarTodos([Service] ICarHandler handler)
        {
            return await handler.GetAllListAsync();
        }

        [UseFiltering]
        public async Task<List<CarResponse>> ConsultarTodosPagination([Service] ICarHandler handler, int page, int pageSize)
        {
            var offset = (page - 1) * pageSize;
            var todos = await handler.GetAllListAsync();
            return todos.Skip(offset).Take(pageSize).ToList();
        }

    }
}
