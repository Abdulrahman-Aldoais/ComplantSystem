﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComplantSystem.Models
{
    public class AppCompalintsContextDB : IdentityDbContext<



         ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken


        //ApplicationUser,
        //ApplicationRole, string


        >
    {
        public AppCompalintsContextDB(DbContextOptions<AppCompalintsContextDB> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UploadsComplainte>()
               .Property(u => u.Size)
               .HasColumnType("decimal(18, 4)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppCompalintsContextDB).Assembly);

            modelBuilder.HasDefaultSchema("notdbo");


            modelBuilder.HasDefaultSchema("Identity");
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            modelBuilder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("UserTokens");
            });



            modelBuilder.Entity<ApplicationUser>(c =>
            {
                c.HasOne(e => e.Governorate)
                .WithMany(e => e.Users)
                .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(e => e.Directorate)
              .WithMany(e => e.Users)
              .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(e => e.SubDirectorate)
              .WithMany(e => e.Users)
              .OnDelete(DeleteBehavior.Restrict);

            });


            modelBuilder.Entity<UploadsComplainte>(u =>
            {
                u.HasOne(e => e.Governorate)
                .WithMany(e => e.UploadsComplaintes)
                .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(e => e.Directorate)
             .WithMany(e => e.UploadsComplaintes)
             .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(e => e.SubDirectorate)
             .WithMany(e => e.UploadsComplaintes)
             .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<UsersCommunication>(u =>
            {
                u.HasOne(e => e.Governorate)
                 .WithMany(e => e.UsersCommunications)
                 .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(e => e.Directorate)
             .WithMany(e => e.UsersCommunications)
             .OnDelete(DeleteBehavior.Restrict);

                u.HasOne(e => e.SubDirectorate)
             .WithMany(e => e.UsersCommunications)
             .OnDelete(DeleteBehavior.Restrict);

            });




            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                //b.HasMany(e => e.RoleClaims)
                //    .WithOne(e => e.Role)
                //    .HasForeignKey(rc => rc.RoleId)
                //    .IsRequired();
            });

            modelBuilder.Entity<UploadsComplainte>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<BenefCommunication>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<Beneficiarie>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Proposal>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TypeComplaint>().Property(i => i.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<TypeComplaint>().Property(i => i.Id).HasDefaultValueSql("NEWID()");




        }


        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }
        public DbSet<ApplicationUserToken> UserTokens { get; set; }
        public DbSet<ApplicationUserClaim> UserClaims { get; set; }
        public DbSet<ApplicationRoleClaim> RoleClaims { get; set; }
        public DbSet<ApplicationUserLogin> UserLogins { get; set; }
        public DbSet<TypeComplaint> TypeComplaints { get; set; }
        //public DbSet<TypeBeneficiari> TypeBeneficiaris { get; set; }
        //public DbSet<Beneficiarie> Beneficiaries { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Directorate> Directorates { get; set; }
        public DbSet<SubDirectorate> SubDirectorates { get; set; }
        //public DbSet<Village> Villages { get; set; }
        public DbSet<LimitationOrder> LimitationOrders { get; set; }
        public DbSet<UsersCommunication> UsersCommunications { get; set; }
        public DbSet<Compalints_Solution> Compalints_Solutions { get; set; }
        public DbSet<ComplaintsRejected> ComplaintsRejecteds { get; set; }

        public DbSet<Society> Societys { get; set; }
        public DbSet<StagesComplaint> StagesComplaints { get; set; }
        public DbSet<StatusCompalint> StatusCompalints { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<UploadsComplainte> UploadsComplaintes { get; set; }
        public DbSet<TypeCommunication> TypeCommunications { get; set; }








    }

}
