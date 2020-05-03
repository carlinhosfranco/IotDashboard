using IoT.Shared.Shared;

namespace IoT.Domain.Entities
{
    public class Temperature : Entity
    {
        public Temperature() :base()
        {
        }
        public string Source { get; set; }
        public double Value { get; set; }
    }
}