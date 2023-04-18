using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

/// <summary>
/// This is the entity configuration for the User entity, generally the Entity Framework will figure out most of the configuration but,
/// for some specifics such as unique keys, indexes and foreign keys it is better to explicitly specify them.
/// Note that the EntityTypeBuilder implements a Fluent interface, meaning it is a highly declarative interface using method-chaining.
/// </summary>
/*public class ProdusConfiguration : IEntityTypeConfiguration<Produs>
{
    public void Configure(EntityTypeBuilder<Produs> builder)
    {
        builder.Property(p => p.Nume)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Descriere)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(p => p.Pret)
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        builder.Property(p => p.Categorie)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Rating)
            .HasColumnType("decimal(3,2)")
            .IsRequired();

        builder.Property(p => p.Disponibilitate)
            .IsRequired();

        builder.HasOne(p => p.Comanda)
            .WithMany(c => c.ProduseComandate)
            .HasForeignKey(p => p.ComandaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Recenzii)
            .WithOne(r => r.Produs)
            .HasForeignKey(r => r.ProdusId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasMany(p => p.Fisiere)
            .WithMany(f => f.Produse)
            .UsingEntity(j => j.ToTable("ProdusFiles"));

        builder.HasMany(p => p.Comenzi) // New configuration
            .WithMany(c => c.ProduseComandate)
            .UsingEntity(j => j.ToTable("ComandaProduse"));
    }
}*/

public class ProdusConfiguration : IEntityTypeConfiguration<Produs>
{
    public void Configure(EntityTypeBuilder<Produs> builder)
    {
        builder.ToTable("Produse");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nume)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Descriere)
            .HasMaxLength(500);

        builder.Property(p => p.Pret)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.Categorie)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Rating)
            .HasColumnType("decimal(2,1)");

        builder.HasMany(rp => rp.RecenziiProduse)
                    .WithOne(r => r.Produs)
                    .HasForeignKey(r => r.ProdusId);
    }
}
