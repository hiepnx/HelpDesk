using System;
using System.Collections.Generic;

namespace HelpDesk.Domain.Models
{
    public partial class vw_aspnet_UsersInRoles
    {
        public System.Guid UserId { get; set; }
        public System.Guid RoleId { get; set; }
    }
}
