using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020SS603_2017LM602_2015CG601.Models;
using System.Diagnostics;

namespace P2_2020SS603_2017LM602_2015CG601.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly object _RegistroCovidContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private readonly RegistroCovidContext _context;

        public HomeController(RegistroCovidContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _context.Generos select m).ToList();


            ViewData["listaDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");
            return View();
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