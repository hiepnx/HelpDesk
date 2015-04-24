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
using HelpDesk.Domain.Utilities;
using System.ComponentModel.Composition;

namespace HelpDesk.Web.Client.Controllers
{
    [Export("Markdown", typeof(IController))]
    public partial class MarkdownController : Controller
    {
        [ValidateInput(false)]
        public virtual ContentResult MarkdownPreview(string data)
        {
            var c = new ContentResult();

            var md = new Markdown();
            c.Content = "<style>body{font-size: 8pt;font-family: Verdana, Helvetica, Sans-Serif;margin: 0;padding: 2px;color: #555;}\n</style>";
            c.Content += md.Transform(data, true);

            return c;
        }


    }
}
