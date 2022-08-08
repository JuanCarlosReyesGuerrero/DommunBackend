//using DommunBackend.Data;

//namespace DommunBackend.Common
//{
//    public class AutenticacionApp
//    {
//        private ApplicationDbContext _context = new ApplicationDbContext();

//        public bool ListPermissions(string vUserId, string vMenu, string vPermiso)
//        {
//            bool vResultado = false;

//            var listPermisos = (from a in _context.UserRoles
//                                join r in _context.Roles on a.RoleId equals r.Id
//                                join c in _context.RoleClaims on r.Id equals c.RoleId
//                                where a.UserId == vUserId && c.ClaimType == vMenu && c.ClaimValue == vPermiso
//                                select new
//                                {
//                                    c.ClaimType,
//                                    c.ClaimValue
//                                }).ToList();

//            if (listPermisos.Count() != 0)
//            {
//                vResultado = true;
//            }

//            return vResultado;
//        }
//    }
//}
