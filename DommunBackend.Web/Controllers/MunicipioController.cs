using DomainLayer.DTOs;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace DommunBackend.Web.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly IMunicipioService objService;
        private readonly IDepartamentoService objDepartamentoService;

        public MunicipioController(IMunicipioService _objService, IDepartamentoService _objDepartamentoService)
        {
            this.objService = _objService;
            this.objDepartamentoService = _objDepartamentoService;
        }

        public async Task<ActionResult> IndexAsync()
        {

            //userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //permisoUsuario = objAutenticacion.ListPermissions(userId, Convert.ToString(MenuOptions.Departamento), Convert.ToString(MenuPermiso.View));

            //if (permisoUsuario)
            //{
            List<MunicipioDto> model = new List<MunicipioDto>();

            objService.GetAllMunicipios().ToList().ForEach(u =>
            {
                Departamento departamento = objDepartamentoService.GetDepartamentoById((int)u.DepartamentoId);

                MunicipioDto objModel = new MunicipioDto
                {
                    Id = u.Id,
                    Codigo = u.Codigo,
                    Nombre = u.Nombre,
                    IsActive = u.IsActive,
                    DepartamentoNombre = departamento.Nombre
                };

                model.Add(objModel);
            });

            return View(model);
            
            return RedirectToAction("Index", "Home");
        }
    }
}
