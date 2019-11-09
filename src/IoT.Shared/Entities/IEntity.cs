using System;

namespace IoT.Shared.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreateDate { get; set; }
    }
}