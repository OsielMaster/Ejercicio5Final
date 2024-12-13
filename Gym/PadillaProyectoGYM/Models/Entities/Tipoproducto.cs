using System;
using System.Collections.Generic;

namespace PadillaProyectoGYM.Models.Entities;

public partial class Tipoproducto
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
