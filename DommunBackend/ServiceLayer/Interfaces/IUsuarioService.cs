using DommunBackend.DomainLayer.Models;

namespace DommunBackend.ServiceLayer.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<ApplicationUser> GetAllUsuarios();

        ApplicationUser GetUsuarioById(string id);

        void InsertUsuario(ApplicationUser usuario);

        void UpdateUsuario(ApplicationUser usuario);

        void DeleteUsuario(string id);

        //int ValidarHashUsuario(string usuarioLogin, string usuarioPassword);
    }
}
