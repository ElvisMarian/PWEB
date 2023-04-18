using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

/// <summary>
/// This is the entity configuration for the User entity, generally the Entity Framework will figure out most of the configuration but,
/// for some specifics such as unique keys, indexes and foreign keys it is better to explicitly specify them.
/// Note that the EntityTypeBuilder implements a Fluent interface, meaning it is a highly declarative interface using method-chaining.
/// </summary>
/*public class ComandaConfiguration : IEntityTypeConfiguration<Comanda>
{
    public void Configure(EntityTypeBuilder<Comanda> builder)
    {
        builder.Property(c => c.DataComanda)
            .IsRequired();

        builder.Property(c => c.Cantitate)
            .IsRequired();

        builder.Property(c => c.PretTotal)
            .IsRequired();

        builder.Property(c => c.StatusComanda)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(c => c.Utilizator)
            .WithMany(u => u.IstoricComenzi)
            .HasForeignKey(c => c.Id)
            .IsRequired();

        builder.HasOne(c => c.AdresaLivrare)
            .WithMany(a => a.Comenzi)
            .HasForeignKey(c => c.Id)
            .IsRequired();

        builder.HasMany(c => c.ProduseComandate)
            .WithMany(p => p.Comenzi)
            .UsingEntity(j => j.ToTable("ComandaProduse"));

        builder.HasOne(c => c.Livrare)
            .WithOne(l => l.Comanda)
            .HasForeignKey<Livrare>(l => l.ComandaId)
            .IsRequired(false);
    }
}*/

public class ComandaConfiguration : IEntityTypeConfiguration<Comanda>
{
    public void Configure(EntityTypeBuilder<Comanda> builder)
    {
        builder.ToTable("Comenzi");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Cantitate).IsRequired();
        builder.Property(c => c.PretTotal).HasColumnType("decimal(18,2)").IsRequired();
        builder.HasOne(c => c.AdresaLivrare)
            .WithMany()
            .HasForeignKey(c => c.AdresaLivrareId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        builder.HasOne(c => c.Utilizator).WithMany(u => u.IstoricComenzi).HasForeignKey(c => c.UtilizatorId).OnDelete(DeleteBehavior.Restrict);
    }
}