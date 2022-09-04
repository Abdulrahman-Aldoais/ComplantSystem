using ComplantSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ComplantSystem.Configuration
{
    public class TypeCommuncationConfiguration : IEntityTypeConfiguration<TypeCommunication>
    {
        public void Configure(EntityTypeBuilder<TypeCommunication> builder)
        {
            builder.HasData(
                    new TypeCommunication
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = "تماطل",
                        UsersNameAddType = "قيمة افتراضية من النضام",
                        CreatedDate = DateTime.Now,
                    },
                    new TypeCommunication
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = "تلاعب بالحلول",
                        UsersNameAddType = "قيمة افتراضية من النضام",
                        CreatedDate = DateTime.Now,

                    }
                );
        }


    }

}
