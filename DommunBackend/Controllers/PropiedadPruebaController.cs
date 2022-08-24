using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DommunBackend.Controllers
{
    public class PropiedadPruebaController : Controller
    {
        // GET: PropiedadPruebaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PropiedadPruebaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PropiedadPruebaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropiedadPruebaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PropiedadPruebaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PropiedadPruebaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PropiedadPruebaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PropiedadPruebaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
