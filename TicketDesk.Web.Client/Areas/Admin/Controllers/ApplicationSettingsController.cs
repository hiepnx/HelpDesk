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
using System.ComponentModel.Composition;
using HelpDesk.Domain.Services;
using HelpDesk.Domain.Models;
using HelpDesk.Web.Client.Helpers;
using HelpDesk.Web.Client.Controllers;
using HelpDesk.Domain.Services.Base;

namespace HelpDesk.Web.Client.Areas.Admin.Controllers
{
    [Export("ApplicationSettings", typeof(IController))]
    [AuthorizeAdminOnly]
    public partial class ApplicationSettingsController : ApplicationController
    {
        private SettingsService Settings { get; set; }

        [ImportingConstructor]
        public ApplicationSettingsController(ISecurityService security, SettingsService settings)
            : base(security)
        {
            Settings = settings;
        }


        public virtual ActionResult List()
        {
            
            var model = Settings.ApplicationSettings.CurrentSettings;
            return View(model);
        }

       
        public virtual ActionResult Edit(string settingName)
        {
            var setting = Settings.ApplicationSettings.CurrentSettings.SingleOrDefault(s => s.SettingName == settingName);
            return View(setting);
        }

        [HttpPost]
        [ValidateOnlyIncomingValues]
        public virtual ActionResult Edit(Setting setting)
        {
            try
            {
                var currentSetting = Settings.ApplicationSettings.CurrentSettings.SingleOrDefault(s => s.SettingName == setting.SettingName);
                TryUpdateModel(currentSetting, new[] { "SettingValue"});
                
                if (ModelState.IsValid)
                {
                    Settings.ApplicationSettings.SaveSettings(new[] { currentSetting });
                    // TODO: Add update logic here

                    return RedirectToAction(MVC.Admin.ApplicationSettings.List());
                }
                else
                {
                    return View(currentSetting);
                }
            }
            catch
            {
                return View();
            }
        }


    }
}
