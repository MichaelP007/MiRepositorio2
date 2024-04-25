using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Models;
using System.Linq;

namespace mvcProyectoWeb1.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductoController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProductoController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewBag.Categorias = new SelectList(_contenedorTrabajo.Categoria.GetAll(), "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Producto.Add(producto);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = new SelectList(_contenedorTrabajo.Categoria.GetAll(), "Id", "Nombre");
            return View(producto);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            Producto producto = _contenedorTrabajo.Producto.Get(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = new SelectList(_contenedorTrabajo.Categoria.GetAll(), "Id", "Nombre");
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Producto.Update(producto);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = new SelectList(_contenedorTrabajo.Categoria.GetAll(), "Id", "Nombre");
            return View(producto);
        }

        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Producto.GetAll() });
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Producto.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Producto" });
            }
            _contenedorTrabajo.Producto.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borró el producto" });
        }
        #endregion
    }
}
