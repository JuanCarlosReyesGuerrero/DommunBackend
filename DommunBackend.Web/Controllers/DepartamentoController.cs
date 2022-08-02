using Common;
using DomainLayer.DTOs;
using DomainLayer.Models;
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

        readonly AutenticacionApp objAutenticacion = new AutenticacionApp();

        private string userId = "";
        private bool permisoUsuario = false;

        public DepartamentoController(IDepartamentoService _objService)
        {
            this.objService = _objService;
        }

        public async Task<ActionResult> IndexAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.View));

                if (permisoUsuario)
                {
                    List<DepartamentoDTO> model = new List<DepartamentoDTO>();

                    objService.GetAllDepartamentos().ToList().ForEach(u =>
                    {
                        DepartamentoDTO objModel = new DepartamentoDTO
                        {
                            Id = u.Id,
                            Codigo = u.Codigo,
                            Nombre = u.Nombre,
                            IsActive = u.IsActive,
                        };

                        model.Add(objModel);
                    });

                    return View(model);
                }
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

                    DepartamentoDTO model = new DepartamentoDTO();

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
                    DepartamentoDTO model = new DepartamentoDTO();

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
        public ActionResult Create(DepartamentoDTO model)
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

                    DepartamentoDTO model = new DepartamentoDTO();

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
        public ActionResult Edit(DepartamentoDTO model)
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

                    DepartamentoDTO model = new DepartamentoDTO();

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
