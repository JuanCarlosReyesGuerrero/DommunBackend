using Commun.Utilidades;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DommunBackend.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlobStorageController : Controller
    {
        private readonly IAlmacenamientoAzureStorage _almacenamientoAzureStorage;

        private readonly string contenedor = "agentes";

        public BlobStorageController(IAlmacenamientoAzureStorage almacenamientoAzureStorage)
        {
            _almacenamientoAzureStorage = almacenamientoAzureStorage;
        }

        [HttpPost(nameof(UploadFile))]
        public async Task<Result> UploadFile(IFormFile files)
        {
            Result oRespuesta = new Result();

            try
            {
                string vFotoPerfil = await _almacenamientoAzureStorage.GuardarArchivo(contenedor, files);

                oRespuesta.Success = true;
                oRespuesta.Data = vFotoPerfil;

            }
            catch (Exception ex)
            {
                //_createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        [HttpPost(nameof(UploadMultiFile))]
        public async Task<Result> UploadMultiFile(List<IFormFile> files)
        {
            Result oRespuesta = new Result();

            List<string> vNombreArchivos = new List<string>();

            try
            {
                foreach (IFormFile file in files)
                {
                    string vFotoPerfil = await _almacenamientoAzureStorage.GuardarArchivo(contenedor, file);

                    vNombreArchivos.Add(vFotoPerfil);
                }

                oRespuesta.Success = true;
                oRespuesta.Data = vNombreArchivos;

            }
            catch (Exception ex)
            {
                //_createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }


        //Delete

        //Descaragr        
    }
}
