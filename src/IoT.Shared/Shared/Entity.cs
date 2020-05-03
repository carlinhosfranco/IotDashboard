using System;
namespace IoT.Shared.Shared
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}