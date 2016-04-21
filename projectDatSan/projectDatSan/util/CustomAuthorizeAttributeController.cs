using projectDatSan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectDatSan.util
{
    public class CustomAuthorizeAttributeController : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
            if (httpContext.Session[httpContext.User.Identity.Name] == "")
                return false;
            var _UserRole = (UserRole)httpContext.Session[httpContext.User.Identity.Name];
            if (_UserRole == null)
                return false;
            string[] _Roles = Roles.Split('|');
            foreach (var i in _Roles)
            {
                if (i == _UserRole.Role.ToString())
                    return true;
            }
            return true;
        }
    }
}