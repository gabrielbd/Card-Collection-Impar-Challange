using FluentValidation;
using ImparCar.Application.Requests.Car;

namespace ImparCar.Application.Interfaces.Validators
{
    public interface ICarValidator : IValidator<CreateCarRequest>
    {
    }
}
