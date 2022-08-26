using AutoMapper;
using AutoMapper.QueryableExtensions;
using ComplantSystem.Const;
using ComplantSystem.Data;
using ComplantSystem.Data.ViewModels;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComplantSystem.Service
{
    public class UserService : IUserService
    {
        private readonly AppCompalintsContextDB contex;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly AppCompalintsContextDB context;
        public string Error { get; set; }
        public int returntype { get; set; }

        public UserService(
            AppCompalintsContextDB contex,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            AppCompalintsContextDB _context
            )
        {
            this.contex = contex;
            this.mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            context = _context;
        }



        public async Task AddAsync(AdminUserViewModel userVM, string CurrentUserLoginId)
        {
            var currentuser = _userManager.Users.First(u => u.Id == CurrentUserLoginId);

            var newUser = new ApplicationUser()
            {
                FullName = userVM.FullName,
                UserName = userVM.IdentityNumber,
                Email = userVM.IdentityNumber,
                PhoneNumber = userVM.PhoneNumber,
                GovernorateId = userVM.GovernorateId,
                DirectorateId = userVM.DirectorateId,
                SubDirectorateId = userVM.SubDirectorateId,
                IsBlocked = userVM.IsBlocked,
                SocietyId = userVM.SocietyId,
                ProfilePicture = userVM.ProfilePicture,

                RoleId = 2,


            };



            var user = await _userManager.FindByEmailAsync(newUser.IdentityNumber);
            if (user != null)
            {
                returntype = 1;
                Error = "المستخدم موجود مسبقا بهذا الايميل";
                return;
            }

            var newUserResponse = await _userManager.CreateAsync(newUser, userVM.Password);

            if (newUserResponse.Succeeded)
            {

                await _userManager.AddToRoleAsync(newUser, UserRoles.Beneficiarie);


                await _userManager.AddPasswordAsync(newUser, userVM.Password);



            }

            else
            {
                returntype = 2;

                Error = "كلمة السر يجب ان تكون ارقام و حروف و رموز";
                return;
            }


        }
        public async Task AddAsync(AdminUserViewModel userVM, string currentName, string currentId)
        {

            var newUser = new ApplicationUser()
            {
                FullName = userVM.FullName,
                UserName = userVM.IdentityNumber,
                Email = userVM.IdentityNumber,
                IdentityNumber = userVM.IdentityNumber,
                PhoneNumber = userVM.PhoneNumber,
                GovernorateId = userVM.GovernorateId,
                DirectorateId = userVM.DirectorateId,
                SubDirectorateId = userVM.SubDirectorateId,
                IsBlocked = userVM.IsBlocked,
                SocietyId = userVM.SocietyId,
                ProfilePicture = userVM.ProfilePicture,
                RoleId = userVM.userRoles,
                EmailConfirmed = userVM.IsBlocked,
                PhoneNumberConfirmed = userVM.IsBlocked,
                UserId = currentId,
                originatorName = currentName,



            };



            var user = await _userManager.FindByEmailAsync(newUser.IdentityNumber);
            if (user != null)
            {
                returntype = 1;
                Error = "المستخدم موجود مسبقا بهذا الايميل";
                return;
            }

            var newUserResponse = await _userManager.CreateAsync(newUser, userVM.Password);

            if (newUserResponse.Succeeded)
            {
                if (userVM.userRoles == 1)
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminGeneralFederation);

                }
                else if (userVM.userRoles == 2)
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminGovernorate);
                }
                else if (userVM.userRoles == 3)
                {

                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminDirectorate);
                }
                else if (userVM.userRoles == 4)
                {

                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminSubDirectorate);
                }
                else if (userVM.userRoles == 5)
                {

                    await _userManager.AddToRoleAsync(newUser, UserRoles.AdminVillages);
                }
                else if (userVM.userRoles == 6)
                {

                    await _userManager.AddToRoleAsync(newUser, UserRoles.Beneficiarie);
                }
                await _userManager.AddPasswordAsync(newUser, userVM.Password);



            }

            else
            {
                returntype = 2;

                Error = "كلمة السر يجب ان تكون ارقام و حروف و رموز";
                return;
            }


        }

        public async Task<OperationResult> TogelBlockUserAsync(string UserId)
        {
            var existedUser = await contex.Users.FindAsync(UserId);
            if (existedUser == null)
            {
                return OperationResult.NotFond();
            }
            existedUser.IsBlocked = !existedUser.IsBlocked;
            contex.Update(existedUser);
            await contex.SaveChangesAsync();
            return OperationResult.Successeded();
        }

        public IQueryable<ApplicationUser> GetAllUserBlockedAsync(string byuserId)
        {
            var result = contex.Users.Where(u => u.IsBlocked && u.UserId == byuserId)
                .Include(s => s.Governorate)
                .Include(g => g.Directorate)
                .Include(d => d.SubDirectorate);
            return result;
        }

        public IQueryable<AdminUserViewModel> Search(string term)
        {
            var result = contex.Users.Where(
                u => u.IdentityNumber == term
                || u.UserName == term).ProjectTo<AdminUserViewModel>(
                mapper.ConfigurationProvider);
            return result;
        }

        public async Task<int> UserRegistrationCountAsync()
        {
            var count = await contex.Users.CountAsync();
            return count;
        }

        public async Task<int> UserRegistrationCountAsync(int month)
        {
            var year = DateTime.Today.Year;
            var count = await contex.Users.CountAsync(u => u.CreatedDate.Month == month && u.CreatedDate.Year == year);
            return count;
        }


        public async Task ChaingeStatusAsync(string id, bool isBlocked)
        {
            var selectedItem = await contex.Users.FindAsync(id);
            if (selectedItem != null)
            {
                selectedItem.IsBlocked = isBlocked;
                contex.Update(selectedItem);
                await contex.SaveChangesAsync();
            }
        }


        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var profile = await context.Users.FindAsync(userId);
            if (profile != null)
            {
                //AutoMapper 
                var compalintDetails = context.Users
                .Include(s => s.Governorate)
                .Include(g => g.Directorate)
                .Include(d => d.SubDirectorate)


                .FirstOrDefaultAsync(c => c.Id == userId);
                //var compalintDetails = from m in _context.UploadsComplainte select m;
                return await compalintDetails;
            }
            return null;
        }


        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(string identityUser)
        {

            return await context.Set<ApplicationUser>().Where(i => i.UserId == identityUser)
                .Include(g => g.Governorate)
                .Include(g => g.Directorate)
                .Include(g => g.SubDirectorate)
                .ToListAsync();
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = context.Set<ApplicationUser>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<ApplicationUser> GetByIdAsync(string id) => await context.Set<ApplicationUser>()
            .Include(g => g.Governorate)
            .Include(g => g.Directorate)
            .Include(g => g.SubDirectorate)
            .FirstOrDefaultAsync(n => n.Id == id);

        public async Task<ApplicationUser> GetByIdAsync(string id, params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = context.Set<ApplicationUser>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(string id, EditUserViewModel entity)
        {
            var updatedUser = await _userManager.FindByIdAsync(id);
            var roleId = await _userManager.GetRolesAsync(updatedUser);
            if (updatedUser == null)
                return;
            else
            {

                updatedUser.FullName = entity.FullName;
                updatedUser.PhoneNumber = entity.PhoneNumber;

                updatedUser.IdentityNumber = entity.IdentityNumber;
                updatedUser.CreatedDate = DateTime.Now;
                updatedUser.DateOfBirth = entity.DateOfBirth;
                await _userManager.UpdateAsync(updatedUser);

            }

            await context.SaveChangesAsync();
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllBenefAsync()
        {
            return await context.Set<ApplicationUser>().Where(b => b.RoleId == 6)
                .Include(g => g.Governorate)
                .Include(g => g.Directorate)
                .Include(g => g.SubDirectorate)
                .ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllBenefAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = context.Set<ApplicationUser>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public IQueryable<ApplicationUser> GetAllUserBlockedAsync(params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }
    }
}
