using DomainLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<UserInfo> GetAllUsuarios();

        UserInfo GetUsuarioById(int id);
        
        void InsertUsuario(UserInfo usuario);
        
        void UpdateUsuario(UserInfo usuario);
        
        void DeleteUsuario(int id);
        
        int ValidarHashUsuario(string usuarioLogin, string usuarioPassword);
    }
}
