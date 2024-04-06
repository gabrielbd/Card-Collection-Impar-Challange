namespace ImparCar.Domain.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid PhotoId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public Photo? Photo { get; set; }

    }
}
