using DommunBackend.Common;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using static DommunBackend.Common.Enums;

namespace DommunBackend.Controllers
{
    public class AgentesController : Controller
    {
        private readonly IAgenteService objService;
        private readonly IAutenticacionAppService objAutenticacion;
        private readonly IMunicipioService objMunicipioService;
        private readonly IZonificacionService objZonificacionService;
        private readonly IPlanMembresiaService objPlanMembresiaService;

        private string userId = "";
        private bool permisoUsuario = false;

        ApplicationDbModel objModelAuth = new ApplicationDbModel();

        public AgentesController(
            IAgenteService _objService,
            IAutenticacionAppService _objAutenticacion,
            IMunicipioService _objMunicipioService,
            IZonificacionService _objZonificacionService,
            IPlanMembresiaService _objPlanMembresiaService)
        {
            this.objService = _objService;
            this.objAutenticacion = _objAutenticacion;
            this.objMunicipioService = _objMunicipioService;
            this.objZonificacionService = _objZonificacionService;
            this.objPlanMembresiaService = _objPlanMembresiaService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Agente),
                    vPermiso = Convert.ToString(MenuPermiso.View)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    List<AgenteDto> model = new List<AgenteDto>();

                    objService.GetAllAgentes().ToList().ForEach(u =>
                    {
                        Zonificacion objZonificacion = objZonificacionService.GetZonificacionById((int)u.ZonificacionId);
                        PlanMembresia objPlanMembresia = objPlanMembresiaService.GetPlanMembresiaById((int)u.PlanMembresiaId);
                        Municipio objMunicipio = objMunicipioService.GetMunicipioById((int)u.MunicipioId);

                        AgenteDto objModel = new AgenteDto
                        {
                            Id = u.Id,
                            Slug = u.Slug,
                            Nombre = u.Nombre,
                            Apellido = u.Apellido,
                            Email = u.Email,
                            TelefonoContacto = u.TelefonoContacto,
                            Descripcion = u.Descripcion,
                            FotoPerfil = u.FotoPerfil,
                            AceptaArriendo = u.AceptaArriendo,
                            AceptaVenta = u.AceptaVenta,
                            Publicado = u.Publicado,
                            PrecioArriendoMin = u.PrecioArriendoMin,
                            PrecioVentaMin = u.PrecioVentaMin,
                            DescripcionPerfil = u.DescripcionPerfil,
                            NumeroAvaluo = u.NumeroAvaluo,
                            FechaInicioPlan = u.FechaInicioPlan,
                            RedesSociales = u.RedesSociales,
                            ZonificacionId = u.ZonificacionId,
                            PlanMembresiaId = u.PlanMembresiaId,
                            MunicipioId = u.MunicipioId,
                            IsActive = u.IsActive
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
                    vMenu = Convert.ToString(MenuOptions.Agente),
                    vPermiso = Convert.ToString(MenuPermiso.View)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    AgenteDto model = new AgenteDto();

                    if (id.HasValue && id != 0)
                    {
                        Agente Entity = objService.GetAgenteById(id);

                        model.Id = Entity.Id;
                        model.Slug = Entity.Slug;
                        model.Nombre = Entity.Nombre;
                        model.Apellido = Entity.Apellido;
                        model.Email = Entity.Email;
                        model.TelefonoContacto = Entity.TelefonoContacto;
                        model.Descripcion = Entity.Descripcion;
                        model.FotoPerfil = Entity.FotoPerfil;
                        model.AceptaArriendo = Entity.AceptaArriendo;
                        model.AceptaVenta = Entity.AceptaVenta;
                        model.Publicado = Entity.Publicado;
                        model.PrecioArriendoMin = Entity.PrecioArriendoMin;
                        model.PrecioVentaMin = Entity.PrecioVentaMin;
                        model.DescripcionPerfil = Entity.DescripcionPerfil;
                        model.NumeroAvaluo = Entity.NumeroAvaluo;
                        model.FechaInicioPlan = Entity.FechaInicioPlan;
                        model.RedesSociales = Entity.RedesSociales;
                        model.ZonificacionId = Entity.ZonificacionId;
                        model.PlanMembresiaId = Entity.PlanMembresiaId;
                        model.MunicipioId = Entity.MunicipioId;
                        model.IsActive = Entity.IsActive;

                        Zonificacion zonificacion = objZonificacionService.GetZonificacionById((int)Entity.ZonificacionId);
                        model.ZonificacionNombre = zonificacion.Nombre;

                        PlanMembresia planMembresia = objPlanMembresiaService.GetPlanMembresiaById((int)Entity.PlanMembresiaId);
                        model.PlanMembresiaNombre = planMembresia.Nombre;

                        Municipio municipio = objMunicipioService.GetMunicipioById((int)Entity.MunicipioId);
                        model.MunicipioNombre = municipio.Nombre;
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
                    vMenu = Convert.ToString(MenuOptions.Agente),
                    vPermiso = Convert.ToString(MenuPermiso.Create)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    ViewData["ZonificacionId"] = new SelectList(objZonificacionService.GetAllZonificaciones(), "Id", "Nombre");
                    ViewData["PlanMembresiaId"] = new SelectList(objPlanMembresiaService.GetAllPlanMembresias(), "Id", "Nombre");
                    ViewData["MunicipioId"] = new SelectList(objMunicipioService.GetAllMunicipios(), "Id", "Nombre");

                    AgenteDto model = new AgenteDto();

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
        public async Task<IActionResult> Create(AgenteDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Agente),
                    vPermiso = Convert.ToString(MenuPermiso.Create)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    Agente Entity = new Agente
                    {
                        Id = model.Id,
                        Slug = model.Slug,
                        Nombre = model.Nombre,
                        Apellido = model.Apellido,
                        Email = model.Email,
                        TelefonoContacto = model.TelefonoContacto,
                        Descripcion = model.Descripcion,
                        FotoPerfil = model.FotoPerfil,
                        AceptaArriendo = model.AceptaArriendo,
                        AceptaVenta = model.AceptaVenta,
                        Publicado = model.Publicado,
                        PrecioArriendoMin = model.PrecioArriendoMin,
                        PrecioVentaMin = model.PrecioVentaMin,
                        DescripcionPerfil = model.DescripcionPerfil,
                        NumeroAvaluo = model.NumeroAvaluo,
                        FechaInicioPlan = model.FechaInicioPlan,
                        RedesSociales = model.RedesSociales,
                        ZonificacionId = model.ZonificacionId,
                        PlanMembresiaId = model.PlanMembresiaId,
                        MunicipioId = model.MunicipioId,
                        IsActive = model.IsActive,
                        CreatedDate = DateTime.UtcNow,
                    };

                    objService.InsertAgente(Entity);

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
                    vMenu = Convert.ToString(MenuOptions.Agente),
                    vPermiso = Convert.ToString(MenuPermiso.Edit)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    AgenteDto model = new AgenteDto();

                    if (id.HasValue && id != 0)
                    {
                        Agente Entity = objService.GetAgenteById(id.Value);

                        model.Id = Entity.Id;
                        model.Slug = Entity.Slug;
                        model.Nombre = Entity.Nombre;
                        model.Apellido = Entity.Apellido;
                        model.Email = Entity.Email;
                        model.TelefonoContacto = Entity.TelefonoContacto;
                        model.Descripcion = Entity.Descripcion;
                        model.FotoPerfil = Entity.FotoPerfil;
                        model.AceptaArriendo = Entity.AceptaArriendo;
                        model.AceptaVenta = Entity.AceptaVenta;
                        model.Publicado = Entity.Publicado;
                        model.PrecioArriendoMin = Entity.PrecioArriendoMin;
                        model.PrecioVentaMin = Entity.PrecioVentaMin;
                        model.DescripcionPerfil = Entity.DescripcionPerfil;
                        model.NumeroAvaluo = Entity.NumeroAvaluo;
                        model.FechaInicioPlan = Entity.FechaInicioPlan;
                        model.RedesSociales = Entity.RedesSociales;
                        model.ZonificacionId = Entity.ZonificacionId;
                        model.PlanMembresiaId = Entity.PlanMembresiaId;
                        model.MunicipioId = Entity.MunicipioId;
                        model.IsActive = Entity.IsActive;
                    }

                    if (model == null)
                    {
                        return NotFound();
                    }

                    ViewData["ZonificacionId"] = new SelectList(objZonificacionService.GetAllZonificaciones(), "Id", "Nombre", model.ZonificacionId);
                    ViewData["PlanMembresiaId"] = new SelectList(objPlanMembresiaService.GetAllPlanMembresias(), "Id", "Nombre", model.PlanMembresiaId);
                    ViewData["MunicipioId"] = new SelectList(objMunicipioService.GetAllMunicipios(), "Id", "Nombre", model.MunicipioId);

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
        public async Task<IActionResult> Edit(AgenteDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Agente),
                    vPermiso = Convert.ToString(MenuPermiso.Edit)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    Agente Entity = objService.GetAgenteById(model.Id);

                    Entity.Id = model.Id;
                    Entity.Slug = model.Slug;
                    Entity.Nombre = model.Nombre;
                    Entity.Apellido = model.Apellido;
                    Entity.Email = model.Email;
                    Entity.TelefonoContacto = model.TelefonoContacto;
                    Entity.Descripcion = model.Descripcion;
                    Entity.FotoPerfil = model.FotoPerfil;
                    Entity.AceptaArriendo = model.AceptaArriendo;
                    Entity.AceptaVenta = model.AceptaVenta;
                    Entity.Publicado = model.Publicado;
                    Entity.PrecioArriendoMin = model.PrecioArriendoMin;
                    Entity.PrecioVentaMin = model.PrecioVentaMin;
                    Entity.DescripcionPerfil = model.DescripcionPerfil;
                    Entity.NumeroAvaluo = model.NumeroAvaluo;
                    Entity.FechaInicioPlan = model.FechaInicioPlan;
                    Entity.RedesSociales = model.RedesSociales;
                    Entity.ZonificacionId = model.ZonificacionId;
                    Entity.PlanMembresiaId = model.PlanMembresiaId;
                    Entity.MunicipioId = model.MunicipioId;
                    Entity.IsActive = model.IsActive;
                    Entity.ModifiedDate = DateTime.UtcNow;

                    objService.UpdateAgente(Entity);

                    if (Entity.Id > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ViewData["ZonificacionId"] = new SelectList(objZonificacionService.GetAllZonificaciones(), "Id", "Nombre", model.ZonificacionId);
                    ViewData["PlanMembresiaId"] = new SelectList(objPlanMembresiaService.GetAllPlanMembresias(), "Id", "Nombre", model.PlanMembresiaId);
                    ViewData["MunicipioId"] = new SelectList(objMunicipioService.GetAllMunicipios(), "Id", "Nombre", model.MunicipioId);

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
                    vMenu = Convert.ToString(MenuOptions.Agente),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    AgenteDto model = new AgenteDto();

                    if (id.HasValue && id != 0)
                    {
                        Agente Entity = objService.GetAgenteById(id);

                        model.Id = Entity.Id;
                        model.Slug = Entity.Slug;
                        model.Nombre = Entity.Nombre;
                        model.Apellido = Entity.Apellido;
                        model.Email = Entity.Email;
                        model.TelefonoContacto = Entity.TelefonoContacto;
                        model.Descripcion = Entity.Descripcion;
                        model.FotoPerfil = Entity.FotoPerfil;
                        model.AceptaArriendo = Entity.AceptaArriendo;
                        model.AceptaVenta = Entity.AceptaVenta;
                        model.Publicado = Entity.Publicado;
                        model.PrecioArriendoMin = Entity.PrecioArriendoMin;
                        model.PrecioVentaMin = Entity.PrecioVentaMin;
                        model.DescripcionPerfil = Entity.DescripcionPerfil;
                        model.NumeroAvaluo = Entity.NumeroAvaluo;
                        model.FechaInicioPlan = Entity.FechaInicioPlan;
                        model.RedesSociales = Entity.RedesSociales;
                        model.ZonificacionId = Entity.ZonificacionId;
                        model.PlanMembresiaId = Entity.PlanMembresiaId;
                        model.MunicipioId = Entity.MunicipioId;

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
                    vMenu = Convert.ToString(MenuOptions.Agente),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    objService.DeleteAgente(id);
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
