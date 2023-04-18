using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;
using System.Security.Claims;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

/// <summary>
/// This is the entity configuration for the User entity, generally the Entity Framework will figure out most of the configuration but,
/// for some specifics such as unique keys, indexes and foreign keys it is better to explicitly specify them.
/// Note that the EntityTypeBuilder implements a Fluent interface, meaning it is a highly declarative interface using method-chaining.
/// </summary>
public class AdresaConfiguration : IEntityTypeConfiguration<Adresa>
{
    public void Configure(EntityTypeBuilder<Adresa> builder)
    {
        builder.ToTable("Adrese");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Strada).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Oras).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Tara).HasMaxLength(50).IsRequired();
        builder.HasOne(a => a.User).WithMany(u => u.Adrese).HasForeignKey(a => a.UserIdAdresa).OnDelete(DeleteBehavior.Restrict);
    }
}





