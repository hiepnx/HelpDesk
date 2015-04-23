﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using HelpDesk.Domain.Dto;

namespace HelpDesk.Domain.Repository.Base
{
    public abstract class SecurityRepositoryBase : ISecurityRepository
    {
        /// <summary>
        ///Initializes a new instance of the <see cref="TdSecurityRepositoryBase"/> class.
        /// </summary>
        /// <param name="roleProvider">The role provider.</param>
        /// <param name="profile">The profile.</param>
        public SecurityRepositoryBase(RoleProvider roleProvider)
        {
            RoleSource = roleProvider;
        }

        #region ISecuityRepository Members

        /// <summary>
        /// Gets or (private) sets the role provider.
        /// </summary>
        /// <value>The role provider.</value>
        public RoleProvider RoleSource { get; private set; }

        /// <summary>
        /// Gets the users in a role.
        /// </summary>
        /// <param name="roleName">Name of the role type.</param>
        /// <returns></returns>
        public virtual UserInfo[] GetUsersInRole(string roleName)
        {
            List<UserInfo> users = new List<UserInfo>();

            string[] sUsers = RoleSource.GetUsersInRole(roleName);
            foreach (string s in sUsers)
            {
                users.Add(new UserInfo() { Name = s.ToLower(), DisplayName = GetUserDisplayName(s) });
            }
            return users.ToArray();
        }

        /// <summary>
        /// Determines whether the the specified user name is in the role type .
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="roleName">Name of the role type.</param>
        /// <returns>
        /// 	<c>true</c> if the specified user name is in the role; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsUserInRoleName(string userName, string roleName)
        {
            return RoleSource.IsUserInRole(userName, roleName);
        }

        /// <summary>
        /// Formats the name of the user for use in TicketDesk.
        /// </summary>
        /// <param name="unformattedName">The unformatted username (usually from an authentication provider or IPrincipal).</param>
        /// <returns></returns>
        public virtual string FormatUserName(string unformattedName)
        {
            return unformattedName;
        }


        #region abstract members
        /// <summary>
        /// Gets the display name for the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public abstract string GetUserDisplayName(string userName);

        public abstract string GetUserEmailAddress(string userName);

        public abstract void AddUserToRole(string userName, string roleName);

        public abstract void RemoveUserFromRole(string userName, string roleName);

        #endregion

        #endregion







    }
}
