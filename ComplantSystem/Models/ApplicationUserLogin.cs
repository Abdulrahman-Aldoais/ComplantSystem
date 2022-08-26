using Microsoft.AspNetCore.Identity;
using System;

namespace ComplantSystem.Models
{
    public class ApplicationUserLogin :IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
        
    }
}
