using Microsoft.AspNetCore.Mvc;
using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Models;
using mvcProyectoWeb1.Models.ViewModels;
using System.Diagnostics;

namespace mvcProyectoWeb1.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll(),
            };

            
            ViewBag.IsHome = true;

            return View(homeVM);
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
