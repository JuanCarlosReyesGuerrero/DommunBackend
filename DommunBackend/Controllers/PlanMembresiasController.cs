using DommunBackend.Common;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static DommunBackend.Common.Enums;

namespace DommunBackend.Controllers
{
    public class PlanMembresiasController : Controller
    {
        private readonly IPlanMembresiaService objService;
        private readonly IAutenticacionAppService objAutenticacion;

        private string userId = "";
        private bool permisoUsuario = false;

        public PlanMembresiasController(IAutenticacionAppService _objAutenticacion, IPlanMembresiaService _objService)
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
                    vMenu = Convert.ToString(MenuOptions.PlanMembresia),
                    vPermiso = Convert.ToString(MenuPermiso.View)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    List<PlanMembresiaDto> model = new List<PlanMembresiaDto>();

                    objService.GetAllPlanMembresias().ToList().ForEach(u =>
                    {
                        PlanMembresiaDto objModel = new PlanMembresiaDto
                        {
                            Id = u.Id,                            
                            Nombre = u.Nombre,
                            PrecioFijo = u.PrecioFijo,
                            PrecioPromocion = u.PrecioPromocion,
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
                    vMenu = Convert.ToString(MenuOptions.PlanMembresia),
                    vPermiso = Convert.ToString(MenuPermiso.View)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    PlanMembresiaDto model = new PlanMembresiaDto();

                    if (id.HasValue && id != 0)
                    {
                        PlanMembresia Entity = objService.GetPlanMembresiaById(id);

                        model.Id = Entity.Id;                       
                        model.Nombre = Entity.Nombre;
                        model.PrecioFijo = Entity.PrecioFijo;
                        model.PrecioPromocion = Entity.PrecioPromocion;
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
                    vMenu = Convert.ToString(MenuOptions.PlanMembresia),
                    vPermiso = Convert.ToString(MenuPermiso.Create)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    PlanMembresiaDto model = new PlanMembresiaDto();

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
        public async Task<IActionResult> Create(PlanMembresiaDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.PlanMembresia),
                    vPermiso = Convert.ToString(MenuPermiso.Create)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    PlanMembresia Entity = new PlanMembresia
                    {
                        Id = model.Id,                        
                        Nombre = model.Nombre,
                        PrecioFijo = model.PrecioFijo,
                        PrecioPromocion = model.PrecioPromocion,
                        IsActive = model.IsActive,
                        CreatedDate = DateTime.UtcNow,
                    };

                    objService.InsertPlanMembresia(Entity);

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
                    vMenu = Convert.ToString(MenuOptions.PlanMembresia),
                    vPermiso = Convert.ToString(MenuPermiso.Edit)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    PlanMembresiaDto model = new PlanMembresiaDto();

                    if (id.HasValue && id != 0)
                    {
                        PlanMembresia Entity = objService.GetPlanMembresiaById(id.Value);

                        model.Id = Entity.Id;
                        model.Nombre = Entity.Nombre;
                        model.PrecioFijo = Entity.PrecioFijo;
                        model.PrecioPromocion = Entity.PrecioPromocion;
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
        public async Task<IActionResult> Edit(PlanMembresiaDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.PlanMembresia),
                    vPermiso = Convert.ToString(MenuPermiso.Edit)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    PlanMembresia Entity = objService.GetPlanMembresiaById(model.Id);

                    Entity.Id = model.Id;                    
                    Entity.Nombre = model.Nombre;
                    Entity.PrecioFijo = model.PrecioFijo;
                    Entity.PrecioPromocion = model.PrecioPromocion;
                    Entity.IsActive = model.IsActive;
                    Entity.ModifiedDate = DateTime.UtcNow;

                    objService.UpdatePlanMembresia(Entity);

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
                    vMenu = Convert.ToString(MenuOptions.PlanMembresia),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    PlanMembresiaDto model = new PlanMembresiaDto();

                    if (id.HasValue && id != 0)
                    {
                        PlanMembresia Entity = objService.GetPlanMembresiaById(id);

                        model.Id = Entity.Id;                       
                        model.Nombre = Entity.Nombre;
                        model.PrecioFijo = Entity.PrecioFijo;
                        model.PrecioPromocion = Entity.PrecioPromocion;
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
                    vMenu = Convert.ToString(MenuOptions.PlanMembresia),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    objService.DeletePlanMembresia(id);
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
