using Microsoft.AspNetCore.Http;

namespace Commun.Utilidades
{
    public interface IAlmacenamientoAzureStorage
    {
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> EditarArchivo(string contenedor, IFormFile archivo, string ruta);
        Task<string> GuardarArchivo(string contenedor, IFormFile archivo);
    }
}