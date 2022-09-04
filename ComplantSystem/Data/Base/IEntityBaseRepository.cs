using ComplantSystem.Data.ViewModels;
using ComplantSystem.Models.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Models.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties);
        Task<T> GetByIdAsync(string id);
        Task<SelectDataDropdownsVM> GetNewCompalintsDropdownsValues();
        Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues();

        Task<ApplicationUser> FindIdentityNumber(string identity);
        Task<ApplicationUser> FindPhoneNumber(string phone);
        Task AddNewSolutionCompalintAsync(string id, T entity);
        Task AddUser(T entity);
        Task AddAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);

    }
}
