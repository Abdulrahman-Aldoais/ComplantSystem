using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using System.Linq;
using System.Threading.Tasks;

namespace ComplantSystem.Data.Base
{
    public interface ICompalintRepository : IEntityBaseRepository<UploadsComplainte>
    {
        public string Error { get; set; }
        public int returntype { get; set; }
        IQueryable<UploadsComplainte> GetAll();
        Task UpdatedbCompAsync(UploadsComplainte data);
        Task<UploadsComplainte> FindAsync(string id);
        Task<UploadsComplainte> FindAsync(string id, string userId);
        IQueryable<UploadsComplainte> Search(string term);
        Task<UploadsComplainte> GetCompalintById(string id);
        Task AddSolutionForCompalint(UploadsComplainte data);

        IQueryable<UploadsComplainte> GetBy(string userId);


        IQueryable<UploadsComplainte> GetAllRejectedComplaints(string userId);
        //Task CreateAsync(InputCompmallintVM model);
        Task CreateAsync2(InputCompmallintVM model);

        Task GetAllGategoryCompAsync();

    }
}
