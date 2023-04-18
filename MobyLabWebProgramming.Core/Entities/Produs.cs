using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

/// <summary>
/// This is an example for a user entity, it will be mapped to a single table and each property will have it's own column except for entity object references also known as navigation properties.
/// </summary>
public class Produs : BaseEntity
{
    public string Nume { get; set; }
    public string Descriere { get; set; }
    public decimal Pret { get; set; }
    public string Categorie { get; set; }
    public decimal Rating { get; set; }
    public int Disponibilitate { get; set; }
    public List<RecenzieProdus> RecenziiProduse { get; set; }

}
