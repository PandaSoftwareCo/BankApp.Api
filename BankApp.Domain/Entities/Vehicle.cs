namespace BankApp.Domain.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; }
        public int Year { get; set; }
        public ICollection<Mileage>? Mileage { get; set; } = new HashSet<Mileage>();
    }
}
