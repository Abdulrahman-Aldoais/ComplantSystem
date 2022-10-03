using ComplantSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplantSystem.Service
{
    public interface ICategoryService
    {
        Task<TypeComplaint> GetByIdAsync(string id);
        Task<TypeCommunication> GetCommunicationByIdAsync(string id);
        Task UpdateAsync(string id, TypeComplaint entity);
        Task DeleteAsync(string id);
        Task DeleteCommAsync(string id);
        Task AddCategoruComp(TypeComplaint entity);
        Task AddCategoruComm(TypeCommunication entity);
        Task<IEnumerable<TypeComplaint>> GetAllGategoryCompAsync();
        Task<IEnumerable<TypeCommunication>> GetAllGategoryCommAsync();
        Task GetNewCompalintsDropdownsValues();
    }
}
