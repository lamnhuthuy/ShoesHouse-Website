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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DateDeleted).IsRequired(false);
            builder.Property(x => x.DateModified).IsRequired(false);
            builder.Property(x => x.DeliveryDate).IsRequired(false);
            builder.Property(x => x.Total).HasColumnType("decimal(10,2)");

        }
    }
}
