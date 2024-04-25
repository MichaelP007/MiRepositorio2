using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb1.Models;

namespace mvcProyectoWeb1.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class TransaccionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public TransaccionController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "Administrador")]

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Transaccion.Add(transaccion);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(transaccion);
        }
        //[Authorize(Roles = "Administrador")]

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Transaccion transaccion = new Transaccion();
            transaccion = _contenedorTrabajo.Transaccion.Get(id);
            if (transaccion == null)
            {
                return NotFound();

            }
            return View(transaccion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Transaccion transaccion)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Transaccion.Update(transaccion);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(transaccion);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Transaccion.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Transaccion.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando transaccion" });
            }
            _contenedorTrabajo.Transaccion.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la transaccion" });
        }
        #endregion
    }
}
