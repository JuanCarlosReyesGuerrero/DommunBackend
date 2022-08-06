using DomainLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace DommunBackend.Web.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly IMunicipioService objService;

        public MunicipioController(IMunicipioService _objService)
        {
            this.objService = _objService;
        }

        public async Task<ActionResult> IndexAsync()
        {
            List<MunicipioDto> listMunicipios = new List<MunicipioDto>();

            var listTemp = objService.ObtenerMunicipioByDepartamento();

            foreach (var u in listTemp)
            {
                MunicipioDto objModel = new MunicipioDto
                {
                    Id = u.Id,
                    Codigo = u.Codigo,
                    Nombre = u.Nombre,
                    IsActive = u.IsActive,
                    DepartamentoNombre = u.DepartamentoNombre,
                };

                listMunicipios.Add(objModel);
            }

            return View(listMunicipios);

            return RedirectToAction("Index", "Home");
        }
    }
}
