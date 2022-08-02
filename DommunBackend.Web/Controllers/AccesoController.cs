using Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using ServiceLayer.Interfaces;

namespace DommunBackend.Web.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IUserService userService;

        public AccesoController(IUserService userService)
        {

            this.userService = userService;
        }

        //https://www.youtube.com/watch?v=IvoDzgrjMOY


        public async Task<IActionResult> Index(ApplicationUser _usuario)
        {
            var usuario = await GetUserIdentity(_usuario.Email, _usuario.PasswordHash);

            if (usuario != null)
            {
                if (usuario.Email != null && usuario.PasswordHash != null)
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

            return View();
        }


        private async Task<ApplicationUser> GetUserIdentity(string email, string password)
        {
            string vPass = password + email + Constants.pivotePass;
            //string vPass = password ;

            ApplicationUser objTemp = new ApplicationUser();
            List<ApplicationUser> objList = new List<ApplicationUser>();

            try
            {
                ApplicationUser authUser = new ApplicationUser();

                bool vTemp = false;

                var hasher = new PasswordHasher<ApplicationUser>();
                var hash = hasher.HashPassword(authUser, vPass);

                objList = userService.FindByEmail(email).ToList();

                objTemp = objList.SingleOrDefault(s => s.Email == email);

                if (objTemp != null)
                {
                    if (objTemp.Email != null && objTemp.PasswordHash != null)
                    {
                        var verified = hasher.VerifyHashedPassword(authUser, objTemp.PasswordHash, vPass);

                        if (verified.ToString() == "Success")
                            vTemp = true;
                        else
                            objTemp = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objTemp;
        }















        // GET: AccesoController1
        //public ActionResult Index()
        //{
        //    return View();
        //}




        // GET: AccesoController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccesoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccesoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccesoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccesoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccesoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccesoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
