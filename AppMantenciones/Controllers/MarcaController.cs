using Microsoft.AspNetCore.Mvc;
using AppMantenciones.Models;

namespace AppMantenciones.Controllers
{
    public class MarcaController : Controller
    {
        //conexion bd
        private readonly MantencionesDbContext db = new();
        public IActionResult Index()
        {
            return View(db.MarcaVehiculos.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MarcaVehiculo marcaVehiculo)
        {

            var existe=db.MarcaVehiculos.FirstOrDefault(x => x.Nombre == marcaVehiculo.Nombre);
            if (existe==null)
            {
                db.Add(marcaVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alert = "la marca "+marcaVehiculo.Nombre+" ya existe";
            return View(marcaVehiculo);

        }
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var marcaVehiculo = db.MarcaVehiculos.Find(id);
                if (marcaVehiculo != null)
                {
                    return View(marcaVehiculo);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(MarcaVehiculo marcaVehiculo)
        {
            db.Update(marcaVehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var marcaVehiculo = db.MarcaVehiculos.Find(id);
                if (marcaVehiculo != null)
                {
                    db.MarcaVehiculos.Remove(marcaVehiculo);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
