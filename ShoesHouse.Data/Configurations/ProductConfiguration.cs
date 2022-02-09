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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(x => x.OriginalPrice).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(x => x.Stock).HasDefaultValue(0);

            builder.Property(x => x.DateModified).IsRequired(false);
            builder.Property(x => x.DateDeleted).IsRequired(false);
            builder.Property(x => x.Price).IsRequired(false);
            builder.Property(x => x.Note).IsRequired(false);

            builder.HasOne(x => x.Category).WithMany(y => y.Products);
            builder.HasMany(x => x.ProductImages).WithOne(y => y.Product);
            builder.HasMany(x => x.Comments).WithOne(y => y.Product);
        }
    }
}
