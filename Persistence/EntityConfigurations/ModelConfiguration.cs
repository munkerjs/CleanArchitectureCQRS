using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(x => x.FuelId).HasColumnName("FuelId").IsRequired();
        builder.Property(x => x.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(x => x.DailyPrice).HasColumnName("DailyPrice").IsRequired();
        builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsRequired();


        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Models_Name").IsUnique(); // aynı marka adından sadece bir tane olabilir.
        builder.HasOne(b => b.Brand); // bir modelin sadece bir tane markası olur.
        builder.HasOne(b => b.Fuel); // bir modelin sadece bir tane yakıt türü olur.
        builder.HasOne(b => b.Transmission); // bir modelin sadece bir vites türü olur.

        builder.HasMany(b => b.Cars); // bir modelin birden fazla arabaya tanımlı olabilir.

        builder.HasQueryFilter(x => !x.DeletedDate.HasValue);
    }
}
