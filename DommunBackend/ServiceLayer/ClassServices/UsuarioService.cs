using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.Interfaces;

namespace DommunBackend.ServiceLayer.ClassServices
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository<ApplicationUser> usuarioRepository;

        public UsuarioService(IUsuarioRepository<ApplicationUser> _usuarioRepository)
        {
            this.usuarioRepository = _usuarioRepository;
        }

        public void DeleteUsuario(string id)
        {
            ApplicationUser usuario = GetUsuarioById(id);
            usuarioRepository.Remove(usuario);
            usuarioRepository.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetAllUsuarios()
        {
            return usuarioRepository.GetAll();
        }

        public ApplicationUser GetUsuarioById(string id)
        {
            return usuarioRepository.GetById(id);
        }

        public void InsertUsuario(ApplicationUser usuario)
        {
            usuarioRepository.Insert(usuario);
        }

        public void UpdateUsuario(ApplicationUser usuario)
        {
            usuarioRepository.Update(usuario);
        }

        //public int ValidarHashUsuario(string usuarioEmail, string usuarioPassword)
        //{
        //    ClassPasswordHash objSeguridad = new ClassPasswordHash();

        //    int vId = 0;

        //    if (usuarioEmail != "" && usuarioPassword != "")
        //    {
        //        ApplicationUser _usuario = usuarioRepository.GetByEmail(usuarioEmail);

        //        if (_usuario != null)
        //            if (objSeguridad.verifyMd5Hash(usuarioPassword, Convert.ToString(_usuario.Password)))
        //                vId = _usuario.Id;

        //    }

        //    return vId;
        //}
    }
}