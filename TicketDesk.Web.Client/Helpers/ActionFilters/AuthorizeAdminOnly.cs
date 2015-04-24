// HelpDesk - Attribution notice
// Contributor(s):
//
//      Stephen Redd (stephen@reddnet.net, http://www.reddnet.net)
//
// This file is distributed under the terms of the Microsoft Public 
// License (Ms-PL). See http://HelpDesk.codeplex.com/license
// for the complete terms of use. 
//
// For any distribution that contains code from this file, this notice of 
// attribution must remain intact, and a copy of the license must be 
// provided to the recipient.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelpDesk.Web.Client.Controllers;

namespace HelpDesk.Web.Client.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeAdminOnly : AuthorizeAttribute
    {
        private ApplicationController controller;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAdmin = (controller != null && controller.Security != null && controller.Security.IsTdAdmin());
            
            return isAdmin ? base.AuthorizeCore(httpContext) : false;


        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            controller = filterContext.Controller as ApplicationController;

            base.OnAuthorization(filterContext);
        }
    }
}