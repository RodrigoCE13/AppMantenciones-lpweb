using AppMantenciones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppMantenciones.Controllers
{
    public class MantencionController : Controller
    {
        private readonly MantencionesDbContext db = new();
        public IActionResult Index()
        {
            //calcular total
            decimal sumaTotal = db.Mantencions.Sum(x => x.Precio);
            ViewBag.SumaTotal = sumaTotal;

            var mantencion = db.Mantencions.Include(m => m.IdVehiculoNavigation)
                .Include(m=>m.IdTipoMantencionNavigation)
                .Include(m=>m.IdTallerNavigation);
            return View(mantencion);
        }
        public IActionResult Create()
        {
            ViewData["IdVehiculo"] = new SelectList(db.Vehiculos, "Id", "Patente");
            ViewData["IdTipoMantencion"] = new SelectList(db.TipoMantencions, "Id", "Nombre");
            ViewData["IdTaller"] = new SelectList(db.Tallers, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Mantencion mantencion)
        {
            db.Mantencions.Add(mantencion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var mantencion = db.Mantencions.Find(id);
                if (mantencion != null)
                {
                    ViewData["IdVehiculo"] = new SelectList(db.Vehiculos, "Id", "Patente", mantencion.IdVehiculo);
                    ViewData["IdTipoMantencion"] = new SelectList(db.TipoMantencions, "Id", "Nombre", mantencion.IdTipoMantencion);
                    ViewData["IdTaller"] = new SelectList(db.Tallers, "Id", "Nombre", mantencion.IdTaller);
                    return View(mantencion);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Mantencion mantencion)
        {
            db.Update(mantencion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var mantencion = db.Mantencions.Find(id);
                if (mantencion != null)
                {
                    db.Mantencions.Remove(mantencion);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


    }
}
