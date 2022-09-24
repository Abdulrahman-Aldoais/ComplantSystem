
using AutoMapper;
using ComplantSystem.Configuration;
using ComplantSystem.Data.Base;
using ComplantSystem.Hubs;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using ComplantSystem.Service;
using ComplantSystem.Service.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ComplantSystem
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews()
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);


            services.AddDbContext<AppCompalintsContextDB>(
        b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
              //.UseLazyLoadingProxies()
              );

            //services.Configure<IdentityOptions>(opts =>
            //{
            //    opts.User.RequireUniqueEmail = true;
            //    opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
            //    opts.Password.RequiredLength = 8;
            //    opts.Password.RequireNonAlphanumeric = true;
            //    opts.Password.RequireLowercase = false;
            //    opts.Password.RequireUppercase = true;
            //    opts.Password.RequireDigit = true;

            //    //opts.SignIn.RequireConfirmedEmail = true;

            //    opts.Lockout.AllowedForNewUsers = true;
            //    opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            //    opts.Lockout.MaxFailedAccessAttempts = 3;
            //});


            // Add services to the container.

            services.AddScoped<ICompalintRepository, CompalintRepository>();
            services.AddScoped<IManagementUsers, ManagementUsers>();
            services.AddScoped<IRegionsRepo, RegionsRepo>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILocationRepo<Governorate>, GovernorateRepo>();
            services.AddScoped<ILocationRepo<Directorate>, DirectorateRepo>();
            services.AddScoped<ILocationRepo<SubDirectorate>, SubDirectorateRepo>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options => options.SignIn.RequireConfirmedAccount = true)

                .AddEntityFrameworkStores<AppCompalintsContextDB>()
                .AddDefaultTokenProviders();

            services.AddAdminServices();
            services.AddSignalR();


            // Add services to the container.

            //services.AddCustomConfiguredAutoMapper();

            services.AddAutoMapper(typeof(Startup));



            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews();
            services.AddRazorPages();



        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //Http >> Https 
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            //app.UseSession();


            //Authentication & Authorization



            app.UseAuthentication();
            //Account/Login            >> Url , Route.
            //Posts/Detials/5/11/2020

            app.UseRouting();
            app.UseMiddleware<GetRoutingMiddleware>();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<NotefcationHub>("/notefy");
            });

            UsersConfiguration.SeedUsersAndRolesAsync(app).Wait();






        }
    }
}
