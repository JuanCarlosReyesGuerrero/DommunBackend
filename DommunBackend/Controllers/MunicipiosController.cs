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
    public class MunicipiosController : Controller
    {
        private readonly IMunicipioService objService;
        private readonly IDepartamentoService objDepartamentoService;
        private readonly IAutenticacionAppService objAutenticacion;

        private string userId = "";
        private bool permisoUsuario = false;

        public MunicipiosController(IMunicipioService _objService, IDepartamentoService _objDepartamentoService, IAutenticacionAppService _objAutenticacion)
        {
            this.objService = _objService;
            this.objDepartamentoService = _objDepartamentoService;
            this.objAutenticacion = _objAutenticacion;
        }

        public ActionResult Index()
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
                    List<MunicipioDto> model = new List<MunicipioDto>();

                    objService.ObtenerMunicipioByDepartamento().ToList().ForEach(u =>
                    {
                        MunicipioDto objModel = new MunicipioDto
                        {
                            Id = u.Id,
                            Codigo = u.Codigo,
                            Nombre = u.Nombre,
                            DepartamentoId = u.DepartamentoId,
                            DepartamentoNombre = u.DepartamentoNombre,
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

        public ActionResult Details(int? id)
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
                    if (id == null)
                    {
                        return NotFound();
                    }

                    MunicipioDto model = new MunicipioDto();

                    if (id.HasValue && id != 0)
                    {
                        Municipio Entity = objService.GetMunicipioById(id);

                        model.Id = Entity.Id;
                        model.Codigo = Entity.Codigo;
                        model.Nombre = Entity.Nombre;
                        model.DepartamentoId = Entity.DepartamentoId;
                        model.IsActive = Entity.IsActive;

                        Departamento departamento = objDepartamentoService.GetDepartamentoById((int)Entity.DepartamentoId);
                        model.DepartamentoNombre = departamento.Nombre;
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
                    ViewData["DepartamentoId"] = new SelectList(objDepartamentoService.GetAllDepartamentos(), "Id", "Nombre");

                    MunicipioDto model = new MunicipioDto();

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
        public ActionResult Create(MunicipioDto model)
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
                    Municipio Entity = new Municipio
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        DepartamentoId = model.DepartamentoId,
                        IsActive = model.IsActive,
                        CreatedDate = DateTime.UtcNow,
                    };

                    objService.InsertMunicipio(Entity);

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

        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Departamento),
                    vPermiso = Convert.ToString(MenuPermiso.Edit)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    MunicipioDto model = new MunicipioDto();

                    if (id.HasValue && id != 0)
                    {
                        Municipio Entity = objService.GetMunicipioById(id.Value);

                        model.Id = Entity.Id;
                        model.Codigo = Entity.Codigo;
                        model.Nombre = Entity.Nombre;
                        model.DepartamentoId = Entity.DepartamentoId;

                        model.IsActive = Entity.IsActive;
                    }

                    if (model == null)
                    {
                        return NotFound();
                    }

                    ViewData["DepartamentoId"] = new SelectList(objDepartamentoService.GetAllDepartamentos(), "Id", "Nombre", model.DepartamentoId);

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
        public ActionResult Edit(MunicipioDto model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Departamento),
                    vPermiso = Convert.ToString(MenuPermiso.Edit)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    Municipio Entity = objService.GetMunicipioById(model.Id);

                    Entity.Id = model.Id;
                    Entity.Codigo = model.Codigo;
                    Entity.Nombre = model.Nombre;
                    Entity.DepartamentoId = model.DepartamentoId;
                    Entity.IsActive = model.IsActive;
                    Entity.ModifiedDate = DateTime.UtcNow;

                    objService.UpdateMunicipio(Entity);

                    if (Entity.Id > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ViewData["DepartamentoId"] = new SelectList(objDepartamentoService.GetAllDepartamentos(), "Id", "Nombre", model.DepartamentoId);

                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Departamento),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    MunicipioDto model = new MunicipioDto();

                    if (id.HasValue && id != 0)
                    {
                        Municipio Entity = objService.GetMunicipioById(id);

                        model.Id = Entity.Id;
                        model.Codigo = Entity.Codigo;
                        model.Nombre = Entity.Nombre;
                        model.DepartamentoId = Entity.DepartamentoId;
                        model.IsActive = Entity.IsActive;

                        Departamento departamento = objDepartamentoService.GetDepartamentoById((int)Entity.DepartamentoId);
                        model.DepartamentoNombre = departamento.Nombre;
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
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                ApplicationDbModel objModelAuth = new ApplicationDbModel()
                {
                    vUserId = userId,
                    vMenu = Convert.ToString(MenuOptions.Departamento),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    objService.DeleteMunicipio(id);
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
