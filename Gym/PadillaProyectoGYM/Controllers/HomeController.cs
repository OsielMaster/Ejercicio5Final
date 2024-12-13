using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using PadillaProyectoGYM.Models.Entities;
using PadillaProyectoGYM.Models.ViewModels;
using PadillaProyectoGYM.Repositories;

namespace PadillaProyectoGYM.Controllers
{
    public class HomeController : Controller
    {
        GymContext context;
        Repository <Productos> suplementosRepository;
        public HomeController()
        {
            context = new GymContext();
            suplementosRepository = new(context);
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Vestimenta(int? subcategoriaId)
        {
            var query = context.Productos.Where(x => x.IdCategoria == 1);
            if (subcategoriaId.HasValue)
            {
                query = query.Where(x => x.IdSubCategoria == subcategoriaId.Value);
            }

            var suplementos = query
                                .Select(p => new SuplementosModel
                                {
                                    Productos = p
                                })
                                .ToList();


            var subcategorias = context.Subcategorias.Where(x => x.IdCategoria == 1)
                                                      .Select(s => new SubcategoriasModel
                                                      {
                                                          DatosSubcategorias = s
                                                      })
                                                      .ToList();
            SuplementosViewModel vm = new()
            {
                Suplementos = suplementos,
                Subcategorias = subcategorias
            };


            return View(vm);
        }
        public IActionResult Suplementos(int? subcategoriaId)
        {
           
            var query = context.Productos.Where(x => x.IdCategoria == 2);
            if (subcategoriaId.HasValue)
            {
                query = query.Where(x => x.IdSubCategoria == subcategoriaId.Value);
            }

            var suplementos = query
                                .Select(p => new SuplementosModel
                                {
                                    Productos = p
                                })
                                .ToList();

          
            var subcategorias = context.Subcategorias.Where(x => x.IdCategoria == 2)
                                                      .Select(s => new SubcategoriasModel
                                                      {
                                                          DatosSubcategorias = s
                                                      })
                                                      .ToList();
           SuplementosViewModel vm = new()
            {
                Suplementos = suplementos,
                Subcategorias = subcategorias
            };

        
            return View(vm);
        }
        public IActionResult Accesorios(int? subcategoriaId)
        {
            var query = context.Productos.Where(x => x.IdCategoria == 3);
            if (subcategoriaId.HasValue)
            {
                query = query.Where(x => x.IdSubCategoria == subcategoriaId.Value);
            }

            var suplementos = query
                                .Select(p => new SuplementosModel
                                {
                                    Productos = p
                                })
                                .ToList();


            var subcategorias = context.Subcategorias.Where(x => x.IdCategoria == 3)
                                                      .Select(s => new SubcategoriasModel
                                                      {
                                                          DatosSubcategorias = s
                                                      })
                                                      .ToList();
            SuplementosViewModel vm = new()
            {
                Suplementos = suplementos,
                Subcategorias = subcategorias
            };


            return View(vm);
        }
        public IActionResult VerSuplementos(int id)
        {
            
            var suplemento = context.Productos.FirstOrDefault(x => x.Id == id);

           
            if (suplemento == null)
            {
                return RedirectToAction("Suplementos"); 
            }
            return View(suplemento);

        }
        public IActionResult VerVestimenta(int id)
        {
            var vestimenta = context.Productos.FirstOrDefault(x => x.Id == id);


            if (vestimenta == null)
            {
                return RedirectToAction("Suplementos");
            }
            return View(vestimenta);

        }
        public IActionResult VerAccesorios(int id)
        {
            var accesorio = context.Productos.FirstOrDefault(x => x.Id == id);


            if (accesorio == null)
            {
                return RedirectToAction("Suplementos");
            }
            return View(accesorio);

        }
    }
}
