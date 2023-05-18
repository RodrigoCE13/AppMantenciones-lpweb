using AppMantenciones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppMantenciones.Controllers
{
    public class TipoMantencionController : Controller
    {
        private readonly MantencionesDbContext db = new();
        public IActionResult Index()
        {
            return View(db.TipoMantencions.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TipoMantencion tipoMantencion)
        {
            var existe = db.TipoMantencions.FirstOrDefault(x => x.Nombre == tipoMantencion.Nombre);
            if (existe == null)
            {
                db.Add(tipoMantencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alert = "el tipo " + tipoMantencion.Nombre + " ya existe";
            return View(tipoMantencion);
        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var tipoMantencion = db.TipoMantencions.Find(id);
                if (tipoMantencion != null)
                {
                    return View(tipoMantencion);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(TipoMantencion tipoMantencion)
        {
                db.Update(tipoMantencion);
                db.SaveChanges();
                return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var tipoMantencion = db.TipoMantencions.Find(id);
                if (tipoMantencion != null)
                {
                    db.TipoMantencions.Remove(tipoMantencion);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
