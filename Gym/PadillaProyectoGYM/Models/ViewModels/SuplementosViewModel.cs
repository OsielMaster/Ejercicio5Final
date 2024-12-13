using PadillaProyectoGYM.Models.Entities;

namespace PadillaProyectoGYM.Models.ViewModels
{
    public class SuplementosViewModel
    {
        public IEnumerable<SuplementosModel> Suplementos { get; set; } = null!;
      

        public IEnumerable<SubcategoriasModel> Subcategorias { get; set;} = null!;
    }
    public class SuplementosModel
    {
        public Productos Productos { get; set; } = null!;
    }
 

    public class SubcategoriasModel 
    {
        public Subcategorias DatosSubcategorias { get; set; } = null!;
    }
}
