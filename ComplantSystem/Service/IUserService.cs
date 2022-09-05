using ComplantSystem.Data;
using ComplantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Service
{
    public interface IUserService
    {
        public string Error { get; set; }
        public int returntype { get; set; }
        Task<IEnumerable<ApplicationUser>> GetAllAsync(string identityUser);
        Task<IEnumerable<ApplicationUser>> GetAllBenefAsync();
        Task<IEnumerable<ApplicationUser>> GetAllBenefAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties);
        Task AddBenefAsync(AddUserViewModel entity, string originatorName, string CurrentUserLoginId);
        Task AddAsync(AddUserViewModel entity, string originatorName, string userId);
        Task<IEnumerable<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties);
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ApplicationUser> GetByIdAsync(string id, params Expression<Func<ApplicationUser, object>>[] includeProperties);

        Task UpdateAsync(string id, EditUserViewModel entity);

        //Task<IEnumerable<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] includeproperties);
        IQueryable<ApplicationUser> GetAllUserBlockedAsync(string byuserId);
        IQueryable<ApplicationUser> GetAllUserBlockedAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties);

        Task<ApplicationUser> GetUserByIdAsync(string userId);
        //Task<ApplicationUser> GetByIdAsync(string id, params Expression<Func<ApplicationUser, object>>[] includeProperties);
        IQueryable<UserViewModels> Search(string term);
        Task<OperationResult> TogelBlockUserAsync(string UserId);
        Task<int> UserRegistrationCountAsync();
        Task<ApplicationUser> EnableAndDisbleUser(string id);
        Task ChaingeStatusAsync(string id, bool status);
        Task<int> UserRegistrationCountAsync(int month);
        //Task<SelectDataDropdownsVM> GetNewCompalintsDropdownsValues();
        Task InitializeAsync();
    }
}
