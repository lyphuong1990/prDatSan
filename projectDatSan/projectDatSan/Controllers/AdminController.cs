using log4net;
using projectDatSan.Models;
using projectDatSan.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace projectDatSan.Controllers
{
   
    public class AdminController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        DBContext db = new DBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        //
        // POST: /admin/Login
        //@Methor:  ProcessLogin 
        //@Author cuongnt
        //@Descript: methor check use and password in form Login  
        [HttpPost]
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
                Session[UserRole1.Username] = UserRole1;
                FormsAuthentication.SetAuthCookie(UserRole1.Username, true);
            }
            if (!string.IsNullOrEmpty(Request.Params["ReturnUrl"]))
                return Redirect(Request.Params["ReturnUrl"]);
            return RedirectToAction("Home");
        }
        public UserRole GetUserRole1(string user, string pass)
        {
            var User = db.accounts.Where(m => m.username.ToLower() == user.ToLower() && m.password == pass && m.active == true).FirstOrDefault();
            if (User != null)
            {
                UserRole _User = new UserRole();
                _User.Username = User.username;
                _User.Role = User.role.Value;
                _User.Active = User.active.Value;
                return _User;
            }
            return null;
        }
       
        public ActionResult Home()
        {

            return View();
        }
    }
}