using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

/// <summary>
/// This is the entity configuration for the User entity, generally the Entity Framework will figure out most of the configuration but,
/// for some specifics such as unique keys, indexes and foreign keys it is better to explicitly specify them.
/// Note that the EntityTypeBuilder implements a Fluent interface, meaning it is a highly declarative interface using method-chaining.
/// </summary>
public class RecenzieProdusConfiguration : IEntityTypeConfiguration<RecenzieProdus>
{
    public void Configure(EntityTypeBuilder<RecenzieProdus> builder)
    {
        builder.ToTable("RecenziiProduse");

        builder.HasKey(rp => new { rp.RecenzieId, rp.ProdusId });

        builder.HasOne(rp => rp.Recenzie)
            .WithMany(r => r.RecenziiProduse)
            .HasForeignKey(rp => rp.RecenzieId);

        builder.HasOne(rp => rp.Produs)
            .WithMany(p => p.RecenziiProduse)
            .HasForeignKey(rp => rp.ProdusId);
    }
}