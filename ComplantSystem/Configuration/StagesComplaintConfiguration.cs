using ComplantSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ComplantSystem.Configuration
{
    public class StagesComplaintConfiguration : IEntityTypeConfiguration<StagesComplaint>
    {
        public void Configure(EntityTypeBuilder<StagesComplaint> builder)
        {
            builder.HasData(
                    new StagesComplaint
                    {
                        Id = 1,
                        Name = "القرية",
                    },
                    new StagesComplaint
                    {
                        Id = 2,
                        Name = "العزلة",
                    },
                     new StagesComplaint
                     {
                         Id = 3,
                         Name = "المديرية",
                     },
                      new StagesComplaint
                      {
                          Id =4,
                          Name = "المحافظة",
                      },
                       new StagesComplaint
                       {
                           Id = 5,
                           Name = "الإتحاد العام",
                       }
                );
        }


    }

}