using DommunBackend.Common;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static DommunBackend.Common.Enums;

namespace DommunBackend.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly IDepartamentoService objService;
        private readonly IAutenticacionAppService objAutenticacion;

        private string userId = "";
        private bool permisoUsuario = false;

        ApplicationDbModel objModelAuth = new ApplicationDbModel();

        public DepartamentosController(IDepartamentoService _objService, IAutenticacionAppService _objAutenticacion)
        {
            this.objService = _objService;
            this.objAutenticacion = _objAutenticacion;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
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
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                //permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.View));

                //if (permisoUsuario)
                //{
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
                    //}

                    return View(model);

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        // GET: Departamentos/Create
        public IActionResult Create()
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

        // POST: Departamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartamentoDto model)
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
                    return RedirectToAction(nameof(Index));
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

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartamentoDto model)
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
                    Departamento Entity = objService.GetDepartamentoById(model.Id);

                Entity.Id = model.Id;
                Entity.Codigo = model.Codigo;
                Entity.Nombre = model.Nombre;
                Entity.IsActive = model.IsActive;
                Entity.ModifiedDate = DateTime.UtcNow;

                objService.UpdateDepartamento(Entity);

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
                return Redirect(Constants.routeLogin);
            }
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Departamentos/Delete/5
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
                    vMenu = Convert.ToString(MenuOptions.Departamento),
                    vPermiso = Convert.ToString(MenuPermiso.Delete)
                };

                permisoUsuario = objAutenticacion.ObtenerListPermissions(objModelAuth);

                if (permisoUsuario)
                {
                    objService.DeleteDepartamento(id);
                return RedirectToAction(nameof(Index));
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
