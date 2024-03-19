using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(x=> x.Id);
        builder.Property(x=> x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x=> x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x=> x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x=> x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x=> x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b=> b.Name, name:"UK_Brands_Name").IsUnique(); // aynı marka adından sadece bir tane olabilir.
        builder.HasMany(b => b.Models); // bir marka birden çok modele sahip olabilir.

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}
