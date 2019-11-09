using System;

namespace IoT.Shared.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            //CreateDate = TimeZoneInfo.ConvertTime(DateTime.Now,                TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            CreateDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}