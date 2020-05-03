using IoT.Shared.Shared;

namespace IoT.Domain.Entities
{
    public class People : Entity
    {
        public People() :base()
        {
        }

        public string Source { get; set; }
        public double Value { get; set; }
    }
}