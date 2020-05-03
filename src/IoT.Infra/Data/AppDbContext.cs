using System;
using IoT.Domain.Entities;
using IoT.Infra.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IoT.Infra.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Temperature> Temperatures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration( new TemperatureMap());

            base.OnModelCreating(builder);
        }

    }
}