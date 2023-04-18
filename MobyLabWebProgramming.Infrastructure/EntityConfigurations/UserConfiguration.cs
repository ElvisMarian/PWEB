using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations;

/// <summary>
/// This is the entity configuration for the User entity, generally the Entity Framework will figure out most of the configuration but,
/// for some specifics such as unique keys, indexes and foreign keys it is better to explicitly specify them.
/// Note that the EntityTypeBuilder implements a Fluent interface, meaning it is a highly declarative interface using method-chaining.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Password)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Role)
            .IsRequired();

        builder.HasMany(u => u.IstoricComenzi)
            .WithOne(c => c.Utilizator)
            .HasForeignKey(c => c.UtilizatorId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(u => u.Adrese).WithOne(a => a.User)
            .HasForeignKey(a => a.UserIdAdresa)
            .IsRequired(false);
    }
}

