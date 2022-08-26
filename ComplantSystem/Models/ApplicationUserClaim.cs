using Microsoft.AspNetCore.Identity;
using System;

namespace ComplantSystem.Models
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }

}



