using DommunBackend.Common;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static DommunBackend.Common.Enums;

namespace DommunBackend.Controllers
{
    public class RoleManagerController : Controller
    {
        private readonly IAutenticacionAppService objAutenticacion;

        private readonly RoleManager<IdentityRole> _roleManager;

        private string userId = "";
        private bool permisoUsuario = false;

        public RoleManagerController(RoleManager<IdentityRole> roleManager, IAutenticacionAppService objAutenticacion)
        {
            _roleManager = roleManager;
            this.objAutenticacion = objAutenticacion;
        }

        // GET: RoleManagerController
        public async Task<ActionResult> IndexAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Departamento),
                    vPermiso = Convert.ToString(MenuPermiso.View)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    var roles = await _roleManager.Roles.ToListAsync();
                    return View(roles);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        // GET: RoleManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleManagerController/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Departamento),
                    vPermiso = Convert.ToString(MenuPermiso.Create)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    IdentityRole model = new IdentityRole();

                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        // POST: RoleManagerController/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(IdentityRole model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Departamento),
                    vPermiso = Convert.ToString(MenuPermiso.Create)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (model != null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        // GET: RoleManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
