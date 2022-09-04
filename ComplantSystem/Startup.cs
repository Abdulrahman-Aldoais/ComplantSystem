
using AutoMapper;
using ComplantSystem.Configuration;
using ComplantSystem.Data.Base;
using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using ComplantSystem.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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


            services.AddDbContext<AppCompalintsContextDB>(
        b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
              //.UseLazyLoadingProxies()
              )
              .AddIdentity<ApplicationUser, ApplicationRole>()
              .AddDefaultUI()
              .AddEntityFrameworkStores<AppCompalintsContextDB>()
              .AddDefaultTokenProviders();



            // Add services to the container.

            services.AddScoped<ICompalintRepository, CompalintRepository>();
            services.AddScoped<IManagementUsers, ManagementUsers>();
            services.AddScoped<IRegionsRepo, RegionsRepo>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILocationRepo<Governorate>, GovernorateRepo>();
            services.AddScoped<ILocationRepo<Directorate>, DirectorateRepo>();
            services.AddScoped<ILocationRepo<SubDirectorate>, SubDirectorateRepo>();
            services.AddScoped<ILocationRepo<Village>, VillageRepo>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAdminServices();


            // Add services to the container.

            //services.AddCustomConfiguredAutoMapper();

            services.AddAutoMapper(typeof(Startup));

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/Identity/Account/Login";
            //});

            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.AddAuthorization(options =>
            //{

            //    options.AddPolicy("Beneficiarie",
            //        authBuilder =>
            //        {
            //            authBuilder.RequireRole("Beneficiarie");
            //        });

            //});



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
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            //Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                endpoints.MapRazorPages();
            });

            UsersConfiguration.SeedUsersAndRolesAsync(app).Wait();






        }
    }
}
