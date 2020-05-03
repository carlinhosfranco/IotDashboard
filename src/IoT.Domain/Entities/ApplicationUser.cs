using System;
using Microsoft.AspNetCore.Identity;

namespace IoT.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
        }
        
        
    }
}