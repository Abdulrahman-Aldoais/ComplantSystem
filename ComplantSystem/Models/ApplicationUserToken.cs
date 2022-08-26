using Microsoft.AspNetCore.Identity;
using System;

namespace ComplantSystem.Models
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }

}
