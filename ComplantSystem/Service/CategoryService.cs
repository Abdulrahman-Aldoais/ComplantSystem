using ComplantSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplantSystem.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly AppCompalintsContextDB _context;

        public CategoryService(AppCompalintsContextDB context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TypeComplaint>> GetAllGategoryCompAsync() => await _context.TypeComplaints.ToListAsync();
        public async Task<IEnumerable<TypeComplaint>> GetAllGategoryCommAsync() => await _context.TypeComplaints.ToListAsync();

        //public async Task<TypeComplaint> GetByIdAsync(string id) => await _context.Set<TypeComplaint>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task AddCategoruComm(TypeComplaint entity)
        {
            await _context.TypeComplaints.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddCategoruComp(TypeComplaint entity)
        {
            await _context.TypeComplaints.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TypeComplaint> GetByIdAsync(string id) => await _context.TypeComplaints.FirstOrDefaultAsync(n => n.Id == id);



        public async Task DeleteAsync(string id)
        {
            var selectedCategory = await _context.TypeComplaints.FirstOrDefaultAsync(n => n.Id == id);
            if (selectedCategory != null)
            {
                _context.TypeComplaints.Remove(selectedCategory);
                await _context.SaveChangesAsync();
            }
        }



        public async Task UpdateAsync(string id, TypeComplaint entity)
        {
            EntityEntry entityEntry = _context.Entry<TypeComplaint>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }




    }
}
