using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

/// <summary>
/// This is the entity configuration for the User entity, generally the Entity Framework will figure out most of the configuration but,
/// for some specifics such as unique keys, indexes and foreign keys it is better to explicitly specify them.
/// Note that the EntityTypeBuilder implements a Fluent interface, meaning it is a highly declarative interface using method-chaining.
/// </summary>
public class RecenzieConfiguration : IEntityTypeConfiguration<Recenzie>
{
    public void Configure(EntityTypeBuilder<Recenzie> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.TextRecenzie)
            .IsRequired();

        builder.Property(r => r.Nota)
            .IsRequired();

        builder.Property(r => r.DataRecenzie)
            .IsRequired();
 
        builder.HasMany(rp => rp.RecenziiProduse)
           .WithOne(r => r.Recenzie)
           .HasForeignKey(r => r.RecenzieId);
    }
}