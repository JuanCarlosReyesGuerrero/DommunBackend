using DommunBackend.Common.Logs;
using DommunBackend.Data;
using DommunBackend.DomainLayer.Models;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;

namespace DommunBackend.RepositoryLayer.RespositoryPattern.ClassRepository
{
    public class AutenticacionAppRepository : IAutenticacionAppRepository, IDisposable
    {
        EnviarLog enviarLog = new EnviarLog();

        private bool disposed = false;

        private ApplicationDbContext context;

        public AutenticacionAppRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool ObtenerListPermissions(ApplicationDbModel entity)
        {
            bool vResultado = false;

            var listPermisos = (from a in context.UserRoles
                                join r in context.Roles on a.RoleId equals r.Id
                                join c in context.RoleClaims on r.Id equals c.RoleId
                                where a.UserId == entity.vUserId && c.ClaimType == entity.vMenu && c.ClaimValue == entity.vPermiso
                                select new
                                {
                                    c.ClaimType,
                                    c.ClaimValue
                                }).ToList();

            if (listPermisos.Count() != 0)
            {
                vResultado = true;
            }

            return vResultado;
        }
    }
}
