using System;

namespace TruckDream.Domain.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
            => obj is Model model && Id == model.Id;
        public override int GetHashCode() => HashCode.Combine(Id);
    }
}
