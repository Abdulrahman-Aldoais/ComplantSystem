using Microsoft.AspNetCore.Identity;
using System;

namespace ComplantSystem.Models
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}