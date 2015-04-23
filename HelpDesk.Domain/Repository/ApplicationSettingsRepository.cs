﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Enums;
using HelpDesk.Domain.Models;
using HelpDesk.Domain.Repository.Base;

namespace HelpDesk.Domain.Repository
{
    [Export(typeof(IApplicationSettingsRepository))]
    public class ApplicationSettingsRepository : IApplicationSettingsRepository
    {

        private TicketDeskContext ctx = new TicketDeskContext();

        //TODO: We can and should do some caching here so that each request 
        //          doesn't have to refetch all the configuration stuff from the DB each time
        //      It may be sufficient to simply use a static linq contex object since app settings 
        //          are unlikely to be too data heavy, but we need to check the behavior in SQL 
        //          profiler to make sure that is actually acting as a cache correctly.

        #region ISettingRepository Members


        /// <summary>
        /// Gets the default editor mode.
        /// </summary>
        /// <returns></returns>
        public EditorModes GetDefaultEditorMode()
        {
            var v = ctx.Settings.SingleOrDefault(settings => settings.SettingName == "DefaultEditorMode");
            if (v == null || string.IsNullOrEmpty(v.SettingValue))
            {
                return EditorModes.MarkDownEditor;
            }
            return (EditorModes)Convert.ToInt32(v);
        }

        /// <summary>
        /// Gets the allowed editor modes for role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public EditorModes[] GetAllowedEditorModesForRole(string roleName)
        {
            var modes = GetRoleEditorModesFromDb();

            if (modes == null || modes.Count(m => m.Key == roleName) < 1)
            {
                return new EditorModes[] { EditorModes.MarkDownEditor };
            }
            var x = modes.SingleOrDefault(m => m.Key == roleName);
            return x.Value.ToArray();
        }

        /// <summary>
        /// Gets all settings.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Setting> GetAllSettings()
        {
            return ctx.Settings;
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <remarks>
        /// In the EF implementation we don't need the settings passed as a parameter, but we pass it anyway as other repositories may not work the same way
        /// </remarks>
        /// <param name="settingsToSave">The settings to save.</param>
        /// <returns></returns>
        public bool SaveSettings(IEnumerable<Setting> settingsToSave)
        {
            foreach (var s in settingsToSave)
            {
               // if (s.EntityState == System.Data.EntityState.Detached)
               // {
                    ctx.Settings.Add(s);
               // }
            }
            ctx.SaveChanges();
            ctx = new TicketDeskContext();//reset the entities
            return true;
        }

        #endregion



        /// <summary>
        /// Gets the role editor modes from db.
        /// </summary>
        /// <remarks>
        /// The DB value structure for role editor modes is "rolename=value,value,value:rolename=value,value,value";
        /// </remarks>
        /// <returns></returns>
        private Dictionary<string, List<EditorModes>> GetRoleEditorModesFromDb()
        {
            var v = ctx.Settings.SingleOrDefault(settings => settings.SettingName == "RoleEditorModes");
            if (v == null || string.IsNullOrEmpty(v.SettingValue))
            {
                return null;
            }
            Dictionary<string, List<EditorModes>> RoleEditorModes = new Dictionary<string, List<EditorModes>>();

            string[] roleLines = v.SettingValue.Split(':');
            foreach (string roleLine in roleLines)
            {
                string[] line = roleLine.Split('=');
                if (line.Length != 2)
                {
                    throw new ApplicationException("RoleEditorModes setting in database is corrupt");
                    //TODO: we should kill the config and regen the default settings for all roles if this happens?
                }
                string role = line[0];
                string[] editorModes = line[1].Split(',');
                List<EditorModes> modes = new List<EditorModes>();
                foreach (string mode in editorModes)
                {
                    modes.Add((EditorModes)Convert.ToInt32(mode));
                }
                RoleEditorModes.Add(role, modes);

            }
            return RoleEditorModes;
        }
    }
}
