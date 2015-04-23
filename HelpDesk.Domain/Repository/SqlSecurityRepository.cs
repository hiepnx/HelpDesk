﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using HelpDesk.Domain.Repository.Base;

namespace HelpDesk.Domain.Repository
{
    [Export(typeof(ISecurityRepository))]
    [ExportMetadata("SecurityMode", "SQL")]
    public class SqlSecurityRepository : SecurityRepositoryBase
    {
        ///// <summary>
        ///// Initializes a new instance of the <see cref="TdSqlSecurityRepository"/> class.
        ///// </summary>
        //public SqlSecurityRepository()
        //    : base()
        //{
        //    MembershipSource = Membership.Provider;
        //}

        /// <summary>
        /// Unit test ctor, Initializes a new instance of the <see cref="TdSqlSecurityRepository"/> class.
        /// </summary>
        /// <param name="membershipProvider">The membership provider.</param>
        /// <param name="roleProvider">The role provider.</param>
        /// <param name="profile">The profile.</param>
        [ImportingConstructor]
        public SqlSecurityRepository(MembershipProvider membershipProvider, RoleProvider roleProvider)
            : base(roleProvider)
        {
            MembershipSource = membershipProvider;
        }

        /// <summary>
        /// Gets or (private) sets the membership provider.
        /// </summary>
        /// <value>The membership provider.</value>
        public MembershipProvider MembershipSource { get; private set; }

        /// <summary>
        /// Gets the display name for the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public override string GetUserDisplayName(string userName)
        {
            var u = userName;
            if (!string.IsNullOrEmpty(userName))
            {
                MembershipUser user = MembershipSource.GetUser(userName, false);
                if (user != null && !string.IsNullOrEmpty(user.Comment))
                {
                    u = user.Comment;
                }
            }
            return u;
        }



        public override string GetUserEmailAddress(string userName)
        {
            string e = null;
            var user = MembershipSource.GetUser(userName, false);
            if (user != null)
            {
                e = user.Email;
            }
            return e;
        }

        public override void AddUserToRole(string userName, string roleName)
        {
            RoleSource.AddUsersToRoles(new[] { userName }, new[] { roleName });
        }

        public override void RemoveUserFromRole(string userName, string roleName)
        {
            RoleSource.RemoveUsersFromRoles(new[] { userName }, new[] { roleName });

        }
    }
}
