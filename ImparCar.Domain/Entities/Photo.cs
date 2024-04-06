namespace ImparCar.Domain.Entities
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string? Base64 { get; set; }
        public Car? Car { get; set; }

    }
}
