using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

/// <summary>
/// This is an example for a user entity, it will be mapped to a single table and each property will have it's own column except for entity object references also known as navigation properties.
/// </summary>
public class Adresa : BaseEntity
{
    public string Strada { get; set; }
    public string Oras { get; set; }
    public string Tara { get; set; }
    public Guid UserIdAdresa { get; set; }
    public User User { get; set; }

}
