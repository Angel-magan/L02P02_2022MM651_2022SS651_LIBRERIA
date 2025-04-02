using System.Diagnostics;
using L02P02_2022MM651_2022SS651.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022MM651_2022SS651.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            return View();
        }
        public IActionResult ListadoLibroAutor()
        {
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
