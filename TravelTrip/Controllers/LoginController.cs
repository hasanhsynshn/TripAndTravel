using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTrip.Classes;

namespace TravelTrip.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var data = c.Admins.FirstOrDefault(x => x.User == admin.User && x.Password == admin.Password);
            if (data!=null)
            {
                FormsAuthentication.SetAuthCookie(data.User,false);
                Session["User"] = data.User.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
           
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
    }
}