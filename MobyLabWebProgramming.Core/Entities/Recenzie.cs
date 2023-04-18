using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

/// <summary>
/// This is an example for a user entity, it will be mapped to a single table and each property will have it's own column except for entity object references also known as navigation properties.
/// </summary>
public class Recenzie : BaseEntity
{
    public string Produs { get; set; }
    public string User { get; set; }
    public int Nota { get; set; }
    public string TextRecenzie { get; set; }
    public DateTime DataRecenzie { get; set; }
    public List<RecenzieProdus> RecenziiProduse { get; set; }
}
