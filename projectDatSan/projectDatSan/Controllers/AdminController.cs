using log4net;
using projectDatSan.Models;
using projectDatSan.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace projectDatSan.Controllers
{

    public class AdminController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        DBContext db = new DBContext();
        // GET: Admin
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        //
        // POST: /admin/Login
        //@Methor:  ProcessLogin 
        //@Author cuongnt
        //@Descript: methor check use and password in form Login  
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ProcessLogin(String userID, String Password)
        {

            Password = class_string.MD5Hash(Password);
            var UserRole1 = GetUserRole1(userID, Password);
            var infomationUser = db.accounts.Where(m => m.username == userID.ToUpper().Trim() && m.password == Password && m.active == true).ToList();
            account acc = new account();
            acc.username = userID;
            if (UserRole1 == null)
            {
                Session["Login"] = acc;
                return RedirectToAction("Login");
            }
            else
            {
                // Session[UserRole1.Username] = UserRole1;
                //Session["username"] = UserRole1.Username;
                FormsAuthentication.SetAuthCookie(UserRole1.Username, true);
            }
            if (!string.IsNullOrEmpty(Request.Params["ReturnUrl"]))
                return Redirect(Request.Params["ReturnUrl"]);
            //return RedirectToAction("Home");
            return RedirectToAction("AccountManager");
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginAction(String userID, String Password)
        {
            Password = class_string.MD5Hash(Password);
            var UserRole1 = GetUserRole1(userID, Password);
            var infomationUser = db.accounts.Where(m => m.username == userID.ToUpper().Trim() && m.password == Password && m.active == true).ToList();
            account acc = new account();
            acc.username = userID;
            if (UserRole1 != null)
            {
                Session[UserRole1.Username] = UserRole1;
                HttpContext.GetOwinContext().Authentication
                  .SignOut(DefaultAuthenticationTypes.ExternalCookie);

                Claim claim1 = new Claim(ClaimTypes.Name, userID);
                Claim[] claims = new Claim[] { claim1 };
                ClaimsIdentity claimsIdentity =
                  new ClaimsIdentity(claims,
                    DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.GetOwinContext().Authentication
                 .SignIn(new AuthenticationProperties() { IsPersistent = false }, claimsIdentity);

                return RedirectToAction("Home", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        public UserRole GetUserRole1(string user, string pass)
        {
            var acount = db.accounts.ToList();
            var User = db.accounts.Where(m => m.username.ToLower() == user.ToLower() && m.password == pass && m.active == true).ToList();
            if (User != null)
            {
                // User = User.FirstOrDefault();
                UserRole _User = new UserRole();
                _User.Username = User.FirstOrDefault().username;
                _User.Role = User.FirstOrDefault().role.Value;
                _User.Active = User.FirstOrDefault().active.Value;
                return _User;
            }
            return null;
        }
        [CustomAuthorizeAttributeController(Roles = "1")]
        public ActionResult Home()
        {

            return View();
        }
        //@Methor:  LogOut 
        //@Author cuongnt
        //@Descript: process Logout system
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Test()
        {
            return View();
        }
        [CustomAuthorizeAttributeController(Roles = "1")]
        public ActionResult AccountManager(string UserID = "", int page = 1)
        {
            IQueryable<account> acc;
            List<account> acc1 = new List<account>();

            ViewBag.listRole = db.roles.Where(m => m.active == true).ToList();
            if (!string.IsNullOrEmpty(UserID))
            {
                acc1 = db.accounts.Where(m => m.username.ToLower() == UserID.ToLower()).ToList();
                return View(acc1.ToPagedList(page, 20));
            }
            else
            {
                acc1 = db.accounts.Select(m => m).ToList();
                return View(acc1.ToPagedList(page, 5));
            }
        }
        public ActionResult DeleteAccount(int id)
        {
            var account = db.accounts.Where(m => m.id == id).FirstOrDefault();
            account.active = false;
            db.SaveChanges();
            return RedirectToAction("AccountManager", "Admin");
        }

    }
}