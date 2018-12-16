using MyHomeOrg.Common.Enums;

namespace MyHomeOrg.Common.DTO.User
{
    public class LoginDto
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public PermissionTypes Permissions { get; set; }
    }
}