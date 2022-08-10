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
    public class UserRolesController : Controller
    {
        private readonly IAutenticacionAppService objAutenticacion;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private string userId = "";
        private bool permisoUsuario = false;

        public UserRolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IAutenticacionAppService _objAutenticacion)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            this.objAutenticacion = _objAutenticacion;
        }

        // GET: UserRolesController
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
                    var users = await _userManager.Users.ToListAsync();

                    var userRolesViewModel = new List<UserRolesDto>();

                    foreach (IdentityUser user in users)
                    {
                        var thisViewModel = new UserRolesDto();

                        thisViewModel.UserId = user.Id;
                        thisViewModel.Email = user.Email;
                        thisViewModel.FirstName = user.UserName;
                        thisViewModel.LastName = user.NormalizedUserName;
                        thisViewModel.Roles = await GetUserRoles(user);

                        userRolesViewModel.Add(thisViewModel);
                    }

                    return View(userRolesViewModel);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        // GET: UserRolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRolesController/Create
        public async Task<ActionResult> CreateAsync()
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
                    ViewBag.userId = userId;

                    var user = await _userManager.FindByIdAsync(userId);

                    if (user == null)
                    {
                        ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                        return View("NotFound");
                    }

                    ViewBag.UserName = user.UserName;

                    var model = new List<ManageUserRolesDto>();

                    foreach (var role in _roleManager.Roles)
                    {
                        var userRolesViewModel = new ManageUserRolesDto
                        {
                            RoleId = role.Id,
                            RoleName = role.Name
                        };
                        if (await _userManager.IsInRoleAsync(user, role.Name))
                        {
                            userRolesViewModel.Selected = true;
                        }
                        else
                        {
                            userRolesViewModel.Selected = false;
                        }
                        model.Add(userRolesViewModel);
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

        // POST: UserRolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(List<ManageUserRolesDto> model)
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
                    var user = await _userManager.FindByIdAsync(userId);

                    if (user == null)
                    {
                        return View();
                    }

                    var roles = await _userManager.GetRolesAsync(user);

                    var result = await _userManager.RemoveFromRolesAsync(user, roles);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot remove user existing roles");
                        return View(model);
                    }

                    result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Cannot add selected roles to user");
                        return View(model);
                    }

                    return RedirectToAction("Index");

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction(Constants.Index, Constants.Home);
            }
        }

        // GET: UserRolesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRolesController/Edit/5
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

        // GET: UserRolesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRolesController/Delete/5
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
        
        private async Task<List<string>> GetUserRoles(IdentityUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}
