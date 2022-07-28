using Common.CypherHelper;
using DomainLayer.Models;
using RepositoryLayer.RespositoryPattern;
using ServiceLayer.Interfaces;

namespace ServiceLayer.ClassServices
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository<UserInfo> usuarioRepository;

        public UsuarioService(IUsuarioRepository<UserInfo> _usuarioRepository)
        {
            this.usuarioRepository = _usuarioRepository;
        }

        public void DeleteUsuario(int id)
        {
            UserInfo usuario = GetUsuarioById(id);
            usuarioRepository.Remove(usuario);
            usuarioRepository.SaveChanges();
        }

        public IEnumerable<UserInfo> GetAllUsuarios()
        {
            return usuarioRepository.GetAll();
        }

        public UserInfo GetUsuarioById(int id)
        {
            return usuarioRepository.GetById(id);
        }

        public void InsertUsuario(UserInfo usuario)
        {
            usuarioRepository.Insert(usuario);
        }

        public void UpdateUsuario(UserInfo usuario)
        {
            usuarioRepository.Update(usuario);
        }

        public int ValidarHashUsuario(string usuarioEmail, string usuarioPassword)
        {
            ClassPasswordHash objSeguridad = new ClassPasswordHash();

            int vId = 0;

            if (usuarioEmail != "" && usuarioPassword != "")
            {
                UserInfo _usuario = usuarioRepository.GetByEmail(usuarioEmail);

                if (_usuario != null)
                    if (objSeguridad.verifyMd5Hash(usuarioPassword, Convert.ToString(_usuario.Password)))
                        vId = _usuario.Id;

            }

            return vId;
        }
    }
}