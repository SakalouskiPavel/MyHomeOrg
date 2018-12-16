using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MyHomeOrg.Common.Enums;

namespace MyHomeOrg.Common.DbModels.User
{
    public class Account : Entity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public PermissionTypes Permissions { get; set; }
    }
}
