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
        public IActionResult ListadoAutores()
        {
            var autores = _context.autores.ToList(); 
            return PartialView(autores);
        }

        public IActionResult ListadoLibroAutor(int idAutor)
        {
            var libros = _context.libros.Where(l => l.id_autor == idAutor).ToList();
            var autor = _context.autores.FirstOrDefault(a => a.id == idAutor);

            ViewBag.Autor = autor?.autor ?? "Autor Desconocido"; 
            return PartialView(libros);
        }

        public IActionResult ComentariosExistentes(int idLibro)
        {
            var libro = _context.libros.FirstOrDefault(l => l.id == idLibro);
            if (libro == null)
            {
                return NotFound(); 
            }

            var autor = _context.autores.FirstOrDefault(a => a.id == libro.id_autor);
            var comentarios = _context.comentarios_Libros.Where(c => c.id_libro == idLibro).ToList();

            ViewBag.Libro = libro.nombre;
            ViewBag.Autor = autor?.autor ?? "Autor Desconocido";
            ViewBag.IdLibro = libro.id;
            ViewBag.IdAutor = libro.id_autor;

            ViewData["IdLibro"] = libro.id;
            ViewData["IdAutor"] = libro.id_autor;

            return PartialView(comentarios);
        }

        private static List<object> ComentariosDB = new List<object>();

        public IActionResult Confirmacion(int idLibro, int idAutor)
        {
            var libro = _context.libros.FirstOrDefault(l => l.id == idLibro);
            var autor = _context.autores.FirstOrDefault(a => a.id == idAutor);

            // Obtener los comentarios desde la bd
            var comentarios = _context.comentarios_Libros
                                      .Where(c => c.id_libro == idLibro)
                                      .OrderByDescending(c => c.created_at)
                                      .ToList();

            ViewBag.Comentarios = comentarios;
            ViewBag.ComentarioNuevo = TempData["ComentarioNuevo"] as string ?? "";
            ViewBag.IdLibro = idLibro;
            ViewBag.Libro = libro?.nombre ?? "Libro Desconocido";
            ViewBag.Autor = autor?.autor ?? "Autor Desconocido";
            ViewBag.IdAutor = idAutor;

            return View();
        }

        [HttpPost]
        public IActionResult GuardarComentario(string Comentario, int idLibro, int idAutor)
        {
            if (string.IsNullOrWhiteSpace(Comentario))
            {
                return RedirectToAction("Confirmacion", new { idLibro = idLibro, idAutor = idAutor });
            }

            int nuevoId = (_context.comentarios_Libros.Any() ? _context.comentarios_Libros.Max(c => c.id) + 1 : 1);

            var nuevoComentario = new comentarios_libros
            {
                id = nuevoId,
                id_libro = idLibro,
                comentarios = Comentario,
                usuario = "UsuarioActual", 
                created_at = DateTime.Now
            };

            _context.comentarios_Libros.Add(nuevoComentario);
            _context.SaveChanges();

            TempData["ComentarioNuevo"] = Comentario;

            return RedirectToAction("Confirmacion", new { idLibro = idLibro, idAutor = idAutor });
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
