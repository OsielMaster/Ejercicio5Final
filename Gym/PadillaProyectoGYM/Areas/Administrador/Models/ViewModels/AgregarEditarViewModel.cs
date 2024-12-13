using PadillaProyectoGYM.Models.Entities;
using PadillaProyectoGYM.Models.ViewModels;

namespace PadillaProyectoGYM.Areas.Administrador.Models.ViewModels
{
    public class AgregarEditarViewModel
    {

        public IEnumerable<ProductosModel> Productos { get; set; } = null!;
        public IEnumerable<SubcategoriasModel> Subcategorias { get; set; } = null!;
        public IFormFile Imagen { get; set; } = null!;
        public IEnumerable<CategoriasModel> Categorias { get; set; }=null!;
        public Categorias SeleccionarCategoria { get; set; } = null!;
        public Subcategorias SeleccionarSubcategoria { get; set; } = null!;

        public Productos producto { get; set; } = null!;
    }

    public class ProductosModel
    {
        public Productos productos { get; set; } = null!;
    }
    public class SubcategoriasModel
    {
        public Subcategorias subcategorias { get; set; } = null!;
    }
    public class CategoriasModel
    {
        public Categorias categorias { get; set; } = null!;
    }
}
