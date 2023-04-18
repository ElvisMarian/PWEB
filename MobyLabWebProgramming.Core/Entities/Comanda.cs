using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

/// <summary>
/// This is an example for a user entity, it will be mapped to a single table and each property will have it's own column except for entity object references also known as navigation properties.
/// </summary>
public class Comanda : BaseEntity
{
    public List<Produs> Produse { get; set; }
    public int Cantitate { get; set; }
    public decimal PretTotal { get; set; }
    public Adresa AdresaLivrare { get; set; }
    public Guid AdresaLivrareId { get; set; }
    public Livrare Livrare { get; set; }
    public string StatusComanda { get; set; }
    public Guid UtilizatorId { get; set; }
    public User Utilizator { get; set; }
}
