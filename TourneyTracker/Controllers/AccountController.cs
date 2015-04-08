using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TourneyTracker.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(/*RegisterModel model*/string dummy)
        {
            if (ModelState.IsValid)
            {
                //voeg gebruiker toe aan de database
                return Login();
            }

            return View(/*RegisterModel*/);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(/*LoginModel model, */string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool userValid = default(bool);
                //zoek database naar user en wachtwoord
                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie("username", false /* = remember me*/);

                    //check for valid return url
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            //Error's in model
            return View(/*model*/);
        }
    }
}