using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.ModelId).HasColumnName("ModelId").IsRequired();
        builder.Property(x => x.Kilometer).HasColumnName("Kilometer").IsRequired();
        builder.Property(x => x.CarState).HasColumnName("State");
        builder.Property(x => x.ModelYear).HasColumnName("ModelYear");

        builder.HasOne(b => b.Model); // bir arabanın sadece bir markası olabilir.

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}