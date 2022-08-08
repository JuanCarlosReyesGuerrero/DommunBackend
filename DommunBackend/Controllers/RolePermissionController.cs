using DommunBackend.Common;
using DommunBackend.DomainLayer.DTOs;
using DommunBackend.DomainLayer.Models;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static DommunBackend.Common.Enums;

namespace DommunBackend.Controllers
{
    public class RolePermissionController : Controller
    {
        private readonly IAutenticacionAppService objAutenticacion;

        private readonly RoleManager<IdentityRole> _roleManager;

        private string userId = "";
        private bool permisoUsuario = false;

        public RolePermissionController(RoleManager<IdentityRole> roleManager, IAutenticacionAppService _objAutenticacion)
        {
            _roleManager = roleManager;
            this.objAutenticacion = _objAutenticacion;
        }

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

                    var rolePermissionDto = new List<RolePermissionDto>();

                    foreach (IdentityRole role in roles)
                    {
                        var thisViewModel = new RolePermissionDto();

                        thisViewModel.RoleId = role.Id;
                        thisViewModel.Name = role.Name;
                        thisViewModel.Claim = await GetRolepermissions(role);

                        rolePermissionDto.Add(thisViewModel);
                    }

                    return View(rolePermissionDto);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        public async Task<ActionResult> CreateAsync(string roleId)
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
                    ViewBag.roleId = roleId;

                    var role = await _roleManager.FindByIdAsync(roleId);

                    if (role == null)
                    {
                        ViewBag.ErrorMessage = $"User with Id = {roleId} cannot be found";
                        return View("NotFound");
                    }

                    ViewBag.RoleName = role.Name;

                    var model = new List<RoleClaimsDto>();

                    var existingUserClaims = await GetRolepermissions(role);

                    foreach (Claim claim in ClaimsStore.AllClaims)
                    {
                        RoleClaimsDto userClaim = new RoleClaimsDto
                        {
                            ClaimType = claim.Type,
                            ClaimValue = claim.Value,
                        };

                        if (existingUserClaims.Exists(c => c.Type == claim.Type && c.Value == claim.Value))
                        {
                            userClaim.Selected = true;
                        }
                        else
                        {
                            userClaim.Selected = false;
                        }

                        model.Add(userClaim);
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
        public async Task<ActionResult> CreateAsync(List<RoleClaimsDto> model, string roleId)
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
                    IdentityResult result = new IdentityResult();

                    var role = await _roleManager.FindByIdAsync(roleId);

                    if (role == null)
                    {
                        return View();
                    }

                    IList<Claim> claims = await _roleManager.GetClaimsAsync(role);

                    foreach (var p in claims)
                    {
                        result = await _roleManager.RemoveClaimAsync(role, p);
                    }

                    foreach (var p in model)
                    {
                        if (p.Selected)
                            await _roleManager.AddClaimAsync(role, new Claim(p.ClaimType, p.ClaimValue));
                    }

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot add selected roles to user");
                        return View(model);
                    }

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(Constants.routeLogin);
            }
        }

        private async Task<List<Claim>> GetRolepermissions(IdentityRole role)
        {
            return new List<Claim>(await _roleManager.GetClaimsAsync(role));
        }
    }
}