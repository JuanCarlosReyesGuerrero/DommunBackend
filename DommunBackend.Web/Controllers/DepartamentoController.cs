using Common;
using DomainLayer.DTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System.Security.Claims;
using static Common.Enums;

namespace DommunBackend.Web.Controllers
{

    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService objService;

        private readonly IHttpContextAccessor objSession;

        readonly AutenticacionApp objAutenticacion = new AutenticacionApp();

        private string userId = "";
        private bool permisoUsuario = false;

        public DepartamentoController(IDepartamentoService _objService, IHttpContextAccessor _objSession)
        {
            this.objService = _objService;
            this.objSession = _objSession;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var message = objSession.HttpContext.Session.GetString("SessionVar");

            if (message == Constants.Autorizado)
            {
                userId = objSession.HttpContext.Session.GetString("UserId"); ;

                //permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.View));

                //if (permisoUsuario)
                //{
                    List<DepartamentoDto> model = new List<DepartamentoDto>();

                    objService.GetAllDepartamentos().ToList().ForEach(u =>
                    {
                        DepartamentoDto objModel = new DepartamentoDto
                        {
                            Id = u.Id,
                            Codigo = u.Codigo,
                            Nombre = u.Nombre,
                            IsActive = u.IsActive,
                        };

                        model.Add(objModel);
                    });

                    return View(model);
                //}
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.View));

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    DepartamentoDto model = new DepartamentoDto();

                    if (id.HasValue && id != 0)
                    {
                        Departamento Entity = objService.GetDepartamentoById(id);

                        model.Id = Entity.Id;
                        model.Codigo = Entity.Codigo;
                        model.Nombre = Entity.Nombre;
                        model.IsActive = Entity.IsActive;
                    }

                    return View(model);

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.Create));

                if (permisoUsuario)
                {
                    DepartamentoDto model = new DepartamentoDto();

                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartamentoDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.Create));

                if (permisoUsuario)
                {
                    Departamento Entity = new Departamento
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        IsActive = model.IsActive,
                        CreatedDate = DateTime.UtcNow,
                    };

                    objService.InsertDepartamento(Entity);

                    if (Entity.Id > 0)
                    {
                        return RedirectToAction(nameof(IndexAsync));
                    }

                    return View(model);

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.Edit));

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    DepartamentoDto model = new DepartamentoDto();

                    if (id.HasValue && id != 0)
                    {
                        Departamento Entity = objService.GetDepartamentoById(id.Value);

                        model.Id = Entity.Id;
                        model.Codigo = Entity.Codigo;
                        model.Nombre = Entity.Nombre;
                        model.IsActive = Entity.IsActive;
                    }

                    if (model == null)
                    {
                        return NotFound();
                    }

                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartamentoDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.Edit));

                if (permisoUsuario)
                {
                    Departamento Entity = objService.GetDepartamentoById(model.Id);

                    Entity.Id = model.Id;
                    Entity.Codigo = model.Codigo;
                    Entity.Nombre = model.Nombre;
                    Entity.IsActive = model.IsActive;
                    Entity.ModifiedDate = DateTime.UtcNow;

                    objService.UpdateDepartamento(Entity);

                    if (Entity.Id > 0)
                    {
                        return RedirectToAction(nameof(IndexAsync));
                    }

                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.Delete));

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    DepartamentoDto model = new DepartamentoDto();

                    if (id.HasValue && id != 0)
                    {
                        Departamento Entity = objService.GetDepartamentoById(id);

                        model.Id = Entity.Id;
                        model.Codigo = Entity.Codigo;
                        model.Nombre = Entity.Nombre;
                        model.IsActive = Entity.IsActive;
                    }

                    if (model == null)
                    {
                        return NotFound();
                    }

                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.Delete));

                if (permisoUsuario)
                {
                    objService.DeleteDepartamento(id);
                    return RedirectToAction(nameof(IndexAsync));
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }
    }
}
