using Microsoft.AspNetCore.Mvc;
using PadillaProyectoGYM.Areas.Administrador.Models.ViewModels;
using PadillaProyectoGYM.Models.Entities;
using PadillaProyectoGYM.Models.ViewModels;
using PadillaProyectoGYM.Repositories;
using SubcategoriasModel = PadillaProyectoGYM.Areas.Administrador.Models.ViewModels.SubcategoriasModel;

namespace PadillaProyectoGYM.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    //[Route("/Administrador/[controller]/[action]/{id?}")]
   
    public class HomeController : Controller
    {
        GymContext context;
        Repository<Productos> productosRepository;
        Repository<Categorias> categoriasRepository;
        Repository<Subcategorias> subcategoriasRepository;
      
        public HomeController()
        {
            context = new GymContext();
            productosRepository = new(context);
            categoriasRepository = new(context);
            subcategoriasRepository = new(context);
        }
        [Route("/Administrador")]
        public IActionResult Index(int? subcategoriaId)
        {
            var query = context.Productos.Where(x => x.IdCategoria == x.IdCategoria);
            if (subcategoriaId.HasValue)
            {
                query = query.Where(x => x.IdSubCategoria == subcategoriaId.Value);
            }

            var productos = query
                                .Select(p => new ProductosModel
                                {
                                    productos = p
                                })
                                .ToList();

            var categorias = context.Categorias.Where(x => x.Id == x.Id)
                                               .Select(c => new CategoriasModel
                                               {
                                                   categorias = c
                                               })
                                               .ToList();

            var subcategorias = context.Subcategorias.Where(x => x.IdCategoria == x.IdCategoria)
                                                      .Select(s => new SubcategoriasModel
                                                      {
                                                          subcategorias = s
                                                      })
                                                      .ToList();

            AgregarEditarViewModel vm = new()
            {
                Productos = productos,
                Subcategorias = subcategorias,
                Categorias = categorias
            };

            return View(vm);
        }




        [HttpGet]
        [Route("/Administrador/Agregar")]
        public IActionResult Agregar()
        {
            AgregarEditarViewModel vm = new();

            vm.Categorias = categoriasRepository.GetAll().Select(c => new CategoriasModel
            {
                categorias = c
            });

            vm.Subcategorias = subcategoriasRepository.GetAll().Select(s => new SubcategoriasModel
            {
                subcategorias = s
            });

            return View(vm);
        }

        [HttpPost]
        [Route("/Administrador/Agregar")]
        public IActionResult Agregar(AgregarEditarViewModel vm)
        {
            if(vm.producto == null)
{
                ModelState.AddModelError("", "La lista de 'items' no puede ser nula.");
                return View(vm);
            }

            ModelState.Clear();
           if(string.IsNullOrWhiteSpace(vm.producto.Nombre))
            {
                ModelState.AddModelError("", "Escribe un nombre.");
            }
           if(string.IsNullOrWhiteSpace(vm.producto.Descripcion))
            {
                ModelState.AddModelError("", "Escribe una descripción para el producto.");
            }
           if(vm.producto.Precio <= 0)
            {
                ModelState.AddModelError("", "El precio no puede ser menor a cero.");
            }
           if(vm.producto.Stock == 0 || vm.producto.Stock < 0)
            {
                ModelState.AddModelError("", "El stock no puede ser menor o igual a cero.");
            }
            if (ModelState.IsValid)
            {
                vm.producto.IdCategoria = vm.SeleccionarCategoria.Id;
                vm.producto.IdSubCategoria = vm.SeleccionarSubcategoria.Id;
                productosRepository.Insert(vm.producto);
                var ruta = $"wwwroot/imgaccesorios/{vm.producto.Id}.jpg";
                if (vm.Imagen != null)
                {
                    FileStream fs = System.IO.File.Create(ruta);
                    vm.Imagen.CopyTo(fs);
                    fs.Close();
                }


            }
            else
            {
                return View(vm);
            }




            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("/Administrador/Editar/{id?}")]
        public IActionResult Editar(int id)
        {

            var producto = productosRepository.Get(id);
            if (producto == null)
            {
                return RedirectToAction("Index");
            }

            AgregarEditarViewModel vm = new();
            vm.producto= producto;

            vm.Categorias = categoriasRepository.GetAll().Select(c => new CategoriasModel
            {
                categorias = c
            });

            vm.Subcategorias = subcategoriasRepository.GetAll().Select(s => new SubcategoriasModel
            {
                subcategorias = s
            });
            return View(vm);
        }
        [HttpPost]
        [Route("/Administrador/Editar/{id?}")]
        public IActionResult Editar(AgregarEditarViewModel vm)
        {
            var producto = productosRepository.Get(vm.producto.Id);
            if (producto == null)
            {
                return RedirectToAction("Index");
            }
            producto.Descripcion = vm.producto.Descripcion;
            producto.Nombre = vm.producto.Nombre;
            producto.Precio = vm.producto.Precio;
            producto.Stock = vm.producto.Stock;
            producto.IdCategoria = vm.SeleccionarCategoria.Id;
            producto.IdSubCategoria = vm.SeleccionarSubcategoria.Id;


            productosRepository.Update(producto);


            if (vm.Imagen != null)
            {
                var ruta = $"wwwroot/imgaccesorios/{vm.producto.Id}.jpg";
                var fs = System.IO.File.Create(ruta);
                vm.Imagen.CopyTo(fs);
                fs.Close();
            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        [Route("/Administrador/Eliminar/{id?}")]
        public IActionResult Eliminar(int id)
        {
            var producto = productosRepository.Get(id);
            if (producto == null)
            {
                return RedirectToAction("Index");
            }

            return View(producto);

        }
        [HttpPost]
        [Route("/Administrador/Eliminar/{id?}")]
        public IActionResult Eliminar(Productos vm)
        {
            var producto = productosRepository.Get(vm.Id);
            if (producto == null)
            {
                return RedirectToAction("Index");
            }
            productosRepository.Delete(producto);
          

            return RedirectToAction("index");
        }
    }
}
