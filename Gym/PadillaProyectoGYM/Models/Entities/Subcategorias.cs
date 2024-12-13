using System;
using System.Collections.Generic;

namespace PadillaProyectoGYM.Models.Entities;

public partial class Subcategorias
{
    public int Id { get; set; }

    public string NombreSub { get; set; } = null!;

    public int? IdCategoria { get; set; }

    public virtual Categorias? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
