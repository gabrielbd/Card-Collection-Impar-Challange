using FluentValidation.Results;

namespace ImparCar.Application.Response.Car
{
    public class UpdateCarResponse
    {
        public string? Name { get; set; }
        public Guid IdCar { get; set; }
        public string? Status { get; set; }
        public Guid IdPhoto { get; set; }
        public string? Base64 { get; set; }
        public List<ValidationFailure>? Errors { get; set; }


    }
}
