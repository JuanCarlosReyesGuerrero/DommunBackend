using DommunBackend.Common;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static DommunBackend.Common.Enums;

namespace DommunBackend.Controllers
{
    public class ZonificacionesController : Controller
    {
        private readonly IZonificacionService objService;
        private readonly IAutenticacionAppService objAutenticacion;

        private string userId = "";
        private bool permisoUsuario = false;

        public ZonificacionesController(IAutenticacionAppService _objAutenticacion, IZonificacionService _objService)
        {
            this.objService = _objService;
            this.objAutenticacion = _objAutenticacion;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Zonificacion),
                    vPermiso = Convert.ToString(MenuPermiso.View)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    List<ZonificacionDto> model = new List<ZonificacionDto>();

                    objService.GetAllZonificaciones().ToList().ForEach(u =>
                    {
                        ZonificacionDto objModel = new ZonificacionDto
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
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Zonificacion),
                    vPermiso = Convert.ToString(MenuPermiso.View)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    ZonificacionDto model = new ZonificacionDto();

                    if (id.HasValue && id != 0)
                    {
                        Zonificacion Entity = objService.GetZonificacionById(id);

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
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Zonificacion),
                    vPermiso = Convert.ToString(MenuPermiso.Create)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    ZonificacionDto model = new ZonificacionDto();

                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ZonificacionDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Zonificacion),
                    vPermiso = Convert.ToString(MenuPermiso.Create)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    Zonificacion Entity = new Zonificacion
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        IsActive = model.IsActive,
                        CreatedDate = DateTime.UtcNow,
                    };

                    objService.InsertZonificacion(Entity);

                    if (Entity.Id > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return View(model);

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Zonificacion),
                    vPermiso = Convert.ToString(MenuPermiso.Edit)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    ZonificacionDto model = new ZonificacionDto();

                    if (id.HasValue && id != 0)
                    {
                        Zonificacion Entity = objService.GetZonificacionById(id.Value);

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
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ZonificacionDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Zonificacion),
                    vPermiso = Convert.ToString(MenuPermiso.Edit)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    Zonificacion Entity = objService.GetZonificacionById(model.Id);

                    Entity.Id = model.Id;
                    Entity.Codigo = model.Codigo;
                    Entity.Nombre = model.Nombre;
                    Entity.IsActive = model.IsActive;
                    Entity.ModifiedDate = DateTime.UtcNow;

                    objService.UpdateZonificacion(Entity);

                    if (Entity.Id > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Zonificacion),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    ZonificacionDto model = new ZonificacionDto();

                    if (id.HasValue && id != 0)
                    {
                        Zonificacion Entity = objService.GetZonificacionById(id);

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
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Zonificacion),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    objService.DeleteZonificacion(id);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }
    }
}
