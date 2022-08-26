using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ComplantSystem.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        private readonly DateTime createdDate;

        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName,
            DateTime createdDate)
            : base(roleName)
        {
            base.Name = roleName;
            this.createdDate = createdDate;
        }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
