using System;
using System.Collections.Generic;

namespace PadillaProyectoGYM.Models.Entities;

public partial class Categorias
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();

    public virtual ICollection<Subcategorias> Subcategorias { get; set; } = new List<Subcategorias>();
}
