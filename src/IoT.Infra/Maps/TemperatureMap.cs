using IoT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IoT.Infra.Maps
{
    public class TemperatureMap : IEntityTypeConfiguration<Temperature>
    {
        public void Configure(EntityTypeBuilder<Temperature> builder)
        {
             builder
                .HasKey(x => x.Id); 
        }
    }
}