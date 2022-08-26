using ComplantSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ComplantSystem.Configuration
{
    public class TypeComplaintConfiguration : IEntityTypeConfiguration<TypeComplaint>
    {
        public void Configure(EntityTypeBuilder<TypeComplaint> builder)
        {
            builder.HasData(
                    new TypeComplaint
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = "زراعية",
                        UsersNameAddType = "قيمة افتراضية من النضام",
                        CreatedDate = DateTime.Now,
                    },
                    new TypeComplaint
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = "فساد",
                        UsersNameAddType = "قيمة افتراضية من النضام",
                        CreatedDate = DateTime.Now,

                    }
                );
        }


    }

}
