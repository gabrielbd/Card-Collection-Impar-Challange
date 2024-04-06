using FluentValidation.Results;

namespace ImparCar.Application.Response.Car
{
    public class CreateCarResponse
    {
        public Guid IdCar { get; set; }
        public Guid IdPhoto { get; set; }
        public string? Name { get; set; }
        public List<ValidationFailure>? Errors { get; set; }

    }
}
