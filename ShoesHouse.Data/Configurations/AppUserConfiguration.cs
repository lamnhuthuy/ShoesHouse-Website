using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesHouse.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesHouse.Data.Configurations
{
    class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.Property(x => x.Name).IsRequired().HasMaxLength(225);
            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(225);
            builder.Property(p => p.Avatar).HasDefaultValue("default-avatar.png");

        }
    }
}
