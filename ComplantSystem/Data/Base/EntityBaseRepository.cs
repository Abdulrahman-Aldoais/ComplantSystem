using ComplantSystem.Data.ViewModels;
using ComplantSystem.Models.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Models.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppCompalintsContextDB _context;

        public EntityBaseRepository(AppCompalintsContextDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeproperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeproperties.Aggregate(query, (current, includeproperty) => current.Include(includeproperty));
            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task AddUser(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<T> GetByIdAsync(string id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);


        public async Task<SelectDataDropdownsVM> GetNewCompalintsDropdownsValues()
        {
            var response = new SelectDataDropdownsVM()
            {

                StatusCompalints = await _context.StatusCompalints.OrderBy(n => n.Name).ToListAsync(),
                TypeComplaints = await _context.TypeComplaints.OrderBy(n => n.Type).ToListAsync(),

            };

            return response;

        }

        public async Task<SelectDataCommuncationDropdownsVM> GetAddCommunicationDropdownsValues()
        {
            var response = new SelectDataCommuncationDropdownsVM()
            {

                ApplicationUsers = await _context.Users.OrderBy(n => n.FullName).Where(r => r.RoleId != 5).ToListAsync(),
                TypeCommunications = await _context.TypeCommunications.OrderBy(n => n.Type).ToListAsync(),

            };

            return response;

        }





        public async Task AddNewSolutionCompalintAsync(string id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }



        public async Task UpdateAsync(string id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUser> FindIdentityNumber(string identity)
        {
            var useridentity = _context.Users.Where(a => a.IdentityNumber == identity).FirstOrDefault();
            //var userIdnntity = await _context.UploadsComplaintes.FindAsync(identity);
            if (identity != null)
            {
                return useridentity;
            }
            return null;

        }

        public async Task<ApplicationUser> FindPhoneNumber(string phone)
        {
            var userPhone = _context.Users.Where(a => a.PhoneNumber == phone).FirstOrDefault();
            //var userIdnntity = await _context.UploadsComplaintes.FindAsync(identity);
            if (userPhone != null)
            {
                return userPhone;
            }
            return null;
        }

        public async Task DeleteAsync(string id)
        {
            var entity = _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(await entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


    }
}
