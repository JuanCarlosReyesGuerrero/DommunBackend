using DomainLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace DommunBackend.Web.Controllers
{
    public class ZonaController : Controller
    {
        private readonly IZonaService objService;
        
        public ZonaController(IZonaService _objService)
        {
            this.objService = _objService;
        }

        public async Task<ActionResult> IndexAsync()
        {
           
            //userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.View));

            //if (permisoUsuario)
            //{
                List<ZonaDto> model = new List<ZonaDto>();

                objService.GetAllZonas().ToList().ForEach(u =>
                {
                    ZonaDto objModel = new ZonaDto
                    {
                        Id = u.Id,
                        Slug = u.Slug,
                        Nombre = u.Nombre,
                        IsActive = u.IsActive,
                    };

                    model.Add(objModel);
                });

                return View(model);
            //}
            return RedirectToAction("Index", "Home");           
        }


















        // GET: ZonaController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: ZonaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ZonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZonaController/Create
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

        // GET: ZonaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ZonaController/Edit/5
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

        // GET: ZonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ZonaController/Delete/5
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
