using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

/// <summary>
/// This is the entity configuration for the User entity, generally the Entity Framework will figure out most of the configuration but,
/// for some specifics such as unique keys, indexes and foreign keys it is better to explicitly specify them.
/// Note that the EntityTypeBuilder implements a Fluent interface, meaning it is a highly declarative interface using method-chaining.
/// </summary>
/*public class LivrareConfiguration : IEntityTypeConfiguration<Livrare>
{
    public void Configure(EntityTypeBuilder<Livrare> builder)
    {
        *//*       builder.ToTable("Livrari");*//*

        builder.Property(e => e.Id)
                    .IsRequired();
        builder.HasKey(x => x.Id);

        builder.Property(l => l.DataLivrare)
            .IsRequired();

        builder.Property(l => l.Status)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(l => l.NumeCurier)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(l => l.AdresaLivrare)
            .WithMany(a => a.Livrari)
            .HasForeignKey(l => l.AdresaLivrareId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Comanda)
            .WithOne(c => c.Livrare)
            .HasForeignKey<Livrare>(l => l.ComandaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}*/
public class LivrareConfiguration : IEntityTypeConfiguration<Livrare>
{
    public void Configure(EntityTypeBuilder<Livrare> builder)
    {
        builder.ToTable("Livrari");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.DataLivrare).IsRequired();
        builder.Property(l => l.Status).HasMaxLength(50).IsRequired();
        builder.Property(l => l.NumeCurier).HasMaxLength(100).IsRequired();

        builder.HasOne(l => l.AdresaLivrare)
            .WithMany()
            .HasForeignKey(l => l.AdresaLivrareId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Comanda)
            .WithOne(c => c.Livrare)
            .HasForeignKey<Livrare>(l => l.ComandaId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}

