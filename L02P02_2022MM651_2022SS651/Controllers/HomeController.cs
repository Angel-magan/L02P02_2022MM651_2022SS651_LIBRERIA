using System.Diagnostics;
using L02P02_2022MM651_2022SS651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2022MM651_2022SS651.Controllers
{
    public class HomeController : Controller
    {
        private readonly libreriaContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, libreriaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public IActionResult ListadoAutores()
        //{
        //    return View();
        //}
        //public IActionResult ListadoLibroAutor()
        //{
        //    return View();
        //}
        //public IActionResult Confirmacion()
        //{
        //    return View();
        //}
        //public IActionResult ComentariosExistentes()
        //{
        //    return View();
        //}
        //Se agrego ahorita *******
        public IActionResult ListadoAutores()
        {
            var autores = _context.autores.ToList(); // Obtiene todos los autores de la BD
            return PartialView(autores);
        }

        //public IActionResult ListadoLibroAutor()
        //{
        //    return PartialView();
        //}

        public IActionResult ListadoLibroAutor(int idAutor)
        {
            //var libros = _context.libros
            //    .Where(l => l.id_autor == idAutor) // Filtrar por autor seleccionado
            //    .ToList();

            //var autor = _context.autores.FirstOrDefault(a => a.id == idAutor);

            //ViewBag.Autor = autor != null ? autor.autor : "Desconocido";

            ////return View(libros);
            //return PartialView(libros);
            var libros = _context.libros.Where(l => l.id_autor == idAutor).ToList();
            var autor = _context.autores.FirstOrDefault(a => a.id == idAutor);

            ViewBag.Autor = autor?.autor ?? "Autor Desconocido"; // Muestra el nombre del autor
            return PartialView(libros);
        }

        public IActionResult ComentariosExistentes()
        {
            ViewBag.Comentarios = new List<object>
            {
                new { Titulo = "Comentario 1", Usuario = "Usuario1", Fecha = "01/04/2025" },
                new { Titulo = "Comentario 2", Usuario = "Usuario2", Fecha = "02/04/2025" },
                new { Titulo = "Comentario 3", Usuario = "Usuario3", Fecha = "03/04/2025" }
            };
            return View();
        }

        public IActionResult Confirmacion()
        {
            ViewBag.Comentarios = new List<object>
            {
                new { Titulo = "Comentario 1", Usuario = "Usuario1", Fecha = "01/04/2025" },
                new { Titulo = "Comentario 2", Usuario = "Usuario2", Fecha = "02/04/2025" },
                new { Titulo = "Comentario 3", Usuario = "Usuario3", Fecha = "03/04/2025" }
            };
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
