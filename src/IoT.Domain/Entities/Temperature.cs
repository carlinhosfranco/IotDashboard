using IoT.Shared.Entities;

namespace IoT.Domain.Entities
{
    public class Temperature : Entity
    {
        public string Source { get; set; }
        public double Value { get; set; }
    }
}