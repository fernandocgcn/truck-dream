using System;

namespace TruckDream.Domain.Entities
{
    public class Truck
    {
        public int Id { get; set; }
        public int ProductionYear { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public int? Horsepower { get; set; }
        public double? Mileage { get; set; }
        public Model Model { get; set; }

        public override bool Equals(object obj)
            => obj is Truck truck && Id == truck.Id;
        public override int GetHashCode() => HashCode.Combine(Id);
    }
}
