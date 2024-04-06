using FluentValidation;
using ImparCar.Application.Interfaces.Validators;
using ImparCar.Application.Requests.Car;

namespace ImparCar.Application.Validators
{
    public class CarValidator : AbstractValidator<CreateCarRequest>, ICarValidator
    {
        public CarValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Nome");

            RuleFor(t => t.Base64)
                .NotEmpty()
                .NotNull()
                .WithName("Foto");
        }
    }
}
