using Microsoft.AspNetCore.Identity;
using System;

namespace ComplantSystem.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}
}
