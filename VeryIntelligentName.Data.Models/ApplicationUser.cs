﻿using Microsoft.AspNetCore.Identity;

namespace VeryIntelligentName.Data.Models
{

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
