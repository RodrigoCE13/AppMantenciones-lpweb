using AppMantenciones.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppMantenciones.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly MantencionesDbContext db = new();
        public IActionResult Index()
        {
            var vehiculo = db.Vehiculos.Include(v => v.IdMarcaVehiculoNavigation);
            return View(vehiculo);
        }
        public IActionResult Create()
        {
            ViewData["IdMarcaVehiculo"] = new SelectList(db.MarcaVehiculos, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vehiculo vehiculo)
        {
            var existe = db.Vehiculos.FirstOrDefault(x => x.Patente == vehiculo.Patente);
            if (existe == null)
            {
                db.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alert = "el vehiculo " + vehiculo.Patente + " ya existe";
            return View(vehiculo);
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                //busco por pk
                var vehiculo = db.Vehiculos.Find(id);
                //verifica que encuentre datos
                if (vehiculo != null)
                {
                    ViewData["IdMarcaVehiculo"]=new SelectList(db.MarcaVehiculos,"Id","Nombre",vehiculo.IdMarcaVehiculo);
                    return View(vehiculo);
                }
            }
            //en caso de error vuelve a index
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Vehiculo vehiculo)
        {
            db.Update(vehiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //eliminar
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var vehiculo = db.Vehiculos.Find(id);
                if (vehiculo != null)
                {
                    db.Vehiculos.Remove(vehiculo);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
