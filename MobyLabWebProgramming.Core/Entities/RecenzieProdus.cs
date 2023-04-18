using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

/// <summary>
/// This is an example for a user entity, it will be mapped to a single table and each property will have it's own column except for entity object references also known as navigation properties.
/// </summary>
public class RecenzieProdus
{
    public Guid RecenzieId { get; set; }
    public Recenzie Recenzie { get; set; }

    public Guid ProdusId { get; set; }
    public Produs Produs { get; set; }
}
