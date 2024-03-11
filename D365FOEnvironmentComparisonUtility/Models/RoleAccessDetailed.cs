using static D365FOEnvironmentComparisonUtility.Models.Enums;

namespace D365FOEnvironmentComparisonUtility.Models
{
    public class RoleAccessDetailed
    {
        public string RoleSystemName { get; set; }
        public string RoleName { get; set; }
        public string SubRoleSystemName { get; set; }
        public string SubRoleName { get; set; }
        public string DutySystemName { get; set; }
        public string DutyName { get; set; }
        public string PrivilegeSystemName { get; set; }
        public string PrivilegeName { get; set; }
        public string SecurableObject { get; set; }
        public SecurableType SecurableType { get; set; }
        public AccessGrantPermissionType Read { get; set; }
        public AccessGrantPermissionType Update { get; set; }
        public AccessGrantPermissionType Create { get; set; }
        public AccessGrantPermissionType Delete { get; set; }
        public AccessGrantPermissionType Invoke { get; set; }
        public UserLicenseType ComputedLicense { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as RoleAccessDetailed);
        }

        public bool Equals(RoleAccessDetailed ra)
        {
            return ra != null &&
                string.Equals(RoleSystemName, ra.RoleSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SubRoleSystemName, ra.SubRoleSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(DutySystemName, ra.DutySystemName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(PrivilegeSystemName, ra.PrivilegeSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SecurableObject, ra.SecurableObject, StringComparison.CurrentCultureIgnoreCase) &&
                SecurableType == ra.SecurableType &&
                Read == ra.Read &&
                Update == ra.Update &&
                Create == ra.Create &&
                Delete == ra.Delete &&
                Invoke == ra.Invoke;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(RoleSystemName, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SubRoleSystemName, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(DutySystemName, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(PrivilegeSystemName, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SecurableObject, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SecurableType);
            hash.Add(Read);
            hash.Add(Update);
            hash.Add(Create);
            hash.Add(Delete);
            hash.Add(Invoke);
            return hash.ToHashCode();
        }
    }
}
