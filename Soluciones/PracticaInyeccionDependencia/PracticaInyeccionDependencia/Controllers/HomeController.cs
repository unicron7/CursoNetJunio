using Microsoft.AspNetCore.Mvc;
using PracticaInyeccionDependencia.Models;
using System.Diagnostics;

namespace PracticaInyeccionDependencia.Controllers
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
            ///var con = new CursosVirtualesContext();

            var consultaContinentes = from c in con.Continentes
                              select c;
            var continentes= consultaContinentes.ToList();


            return View(continentes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}