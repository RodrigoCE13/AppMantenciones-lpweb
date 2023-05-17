using Microsoft.AspNetCore.Mvc;
using AppMantenciones.Models;
using System.Text.RegularExpressions;

namespace AppMantenciones.Controllers
{
    public class TallerController : Controller
    {
        //conexion bd
        private readonly MantencionesDbContext db = new();
        public IActionResult Index()
        {
            return View(db.Tallers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Taller taller)
        {
            var existe=db.Tallers.FirstOrDefault(x => x.Nombre == taller.Nombre);
            if (existe == null)
            {
                db.Add(taller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alert = "el mecanico/taller "+taller.Nombre+" ya existe";
            return View(taller);

        }
        public IActionResult Edit(int? id)
        {
            if (id !=null)
            {
                var taller = db.Tallers.Find(id);
                if(taller != null)
                {
                    return View(taller);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Taller taller)
        {
            db.Update(taller);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var taller = db.Tallers.Find(id);
                if (taller != null)
                {
                    db.Tallers.Remove(taller);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
