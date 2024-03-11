namespace D365FOEnvironmentComparisonUtility.Models
{
    public class EnvConfig
    {
        public string EnvironmentName { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<SecurityUserRole> SecurityUserRoles { get; set; }
        public IEnumerable<SecurityUserRoleOrganization> SecurityUserRoleOrgs { get; set; }
        public IEnumerable<RoleAccess> RoleAccessList { get; set; }

        public EnvConfig()
        {
            Users = new List<User>();
            SecurityUserRoles = new List<SecurityUserRole>();
            SecurityUserRoleOrgs = new List<SecurityUserRoleOrganization>();
            RoleAccessList = new List<RoleAccess>();
        }
    }
}
