using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TourneyTracker.Logic;
using TourneyTracker.Models.Account;

namespace TourneyTracker.Controllers
{
    public class AccountController : Controller
    {
        private AccountLogic AccLogic = new AccountLogic();

        // GET: Account
        public ActionResult Register()
        {
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            //kijk of e-mail al bestaat
            if (AccLogic.EmailInUse(model.Email))
            {
                ModelState.AddModelError("Email", "E-mailadres al in gebruik.");
            }

            if (ModelState.IsValid)
            {
                //voeg gebruiker toe aan de database 
                AccLogic.RegisterAccount(model);
                return RedirectToAction("Login");
            }

            //er iets fout gegaan
            ModelState.Remove("Password");
            model.Password = "";
            return View(model);
        }

        public ActionResult Login(string returnUrl = "")
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //zoek database naar user en wachtwoord
                if (AccLogic.ValidateLogin(model))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.IsPersistent);

                    //check for valid return url
                    var returnUrl = model.ReturnUrl;
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1)
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.Remove("Password");
                ModelState.AddModelError("Password", "Wachtwoord komt niet overeen met e-mailadres");
            }

            model.Password = "";
            //er is iets fout gegaan
            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}