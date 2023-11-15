using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace Commun.Utilidades
{
    public interface IUtilidades
    {
        Bitmap RedimencionarImagen(IFormFile file, int vWidth, int vHeight);

        bool CalcularDimensionImagen(IFormFile file, int vWidth, int vHeight);
    }
}
