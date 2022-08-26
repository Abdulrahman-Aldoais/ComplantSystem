using ComplantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem
{
    public interface IManagementUsers
    {
        IQueryable<ApplicationUser> GetAllUsersAsync();
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(params Expression<Func<ApplicationUser, object>>[] includeproperties);

    }
}
