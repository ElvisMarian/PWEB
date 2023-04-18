using MobyLabWebProgramming.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobyLabWebProgramming.Core.Entities;

/// <summary>
/// This is an example for a user entity, it will be mapped to a single table and each property will have it's own column except for entity object references also known as navigation properties.
/// </summary>
public class Livrare : BaseEntity
{
    public DateTime DataLivrare { get; set; }
    public string Status { get; set; }
    public string NumeCurier { get; set; }
    public Guid AdresaLivrareId { get; set; }
    public Adresa AdresaLivrare { get; set; }
    public Guid ComandaId { get; set; }
    public Comanda Comanda { get; set; }

}

