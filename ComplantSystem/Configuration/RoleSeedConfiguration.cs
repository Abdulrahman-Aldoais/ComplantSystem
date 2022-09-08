using ComplantSystem.Const;
using ComplantSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ComplantSystem.Configuration
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
                 new ApplicationRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = UserRoles.AdminGeneralFederation,
                     NormalizedName = UserRoles.AdminGeneralFederation.ToUpper(),

                 },
                 new ApplicationRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = UserRoles.AdminGovernorate,
                     NormalizedName = UserRoles.AdminGovernorate.ToUpper(),

                 }
                 ,
                 new ApplicationRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = UserRoles.AdminDirectorate,
                     NormalizedName = UserRoles.AdminDirectorate.ToUpper(),


                 },
                 new ApplicationRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = UserRoles.AdminSubDirectorate,
                     NormalizedName = UserRoles.AdminSubDirectorate.ToUpper(),

                 },

                  new ApplicationRole
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = UserRoles.Beneficiarie,
                      NormalizedName = UserRoles.Beneficiarie.ToUpper(),

                  }

            );
        }
    }
}