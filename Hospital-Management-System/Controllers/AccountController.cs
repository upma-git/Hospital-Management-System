using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hospital_Management_System.Controllers
{
    public class AccountController : Controller
    {
        AccountContext acDb = new AccountContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            if(ModelState.IsValid)
            {
                acDb.accounts.Add(account);
                acDb.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(account);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                var user = acDb.accounts.FirstOrDefault(u => u.username == account.username && u.password == account.password);
                if (user != null)
                {
                    // 1. Store role in FormsAuthenticationTicket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        user.username,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        false,
                        user.role, // role stored as UserData
                        FormsAuthentication.FormsCookiePath
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);

                    // 2. Store session info (for UI)
                    Session["username"] = user.username;
                    Session["role"] = user.role;

                    // 3. Redirect
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View(account);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}