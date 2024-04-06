

namespace ImparCar.Application.Response.Car
{
    public class CarResponse
    {
        public string? Name { get; set; }
        public Guid IdCar { get; set; }
        public string? Status { get; set; }
        public Guid IdPhoto { get; set; }
        public string? Base64 { get; set; }
    }
}
