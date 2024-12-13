using System;
using System.Collections.Generic;

namespace PadillaProyectoGYM.Models.Entities;

public partial class Productos
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int? Stock { get; set; }

    public int? IdSubCategoria { get; set; }

    public int? IdTipo { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categorias? IdCategoriaNavigation { get; set; }

    public virtual Subcategorias? IdSubCategoriaNavigation { get; set; }

    public virtual Tipoproducto? IdTipoNavigation { get; set; }
}
