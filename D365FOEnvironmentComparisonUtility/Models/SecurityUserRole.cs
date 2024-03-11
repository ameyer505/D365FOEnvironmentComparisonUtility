namespace D365FOEnvironmentComparisonUtility.Models
{
    public class SecurityUserRole
    {
        public string UserId { get; set; }
        public string SecurityRoleName { get; set; }
        public string SecurityRoleIdentifier { get; set; }
        public string AssignmentStatus { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SecurityUserRole);
        }

        public bool Equals(SecurityUserRole sur)
        {
            return sur != null &&
                string.Equals(UserId, sur.UserId, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SecurityRoleName, sur.SecurityRoleName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SecurityRoleIdentifier, sur.SecurityRoleIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(AssignmentStatus, sur.AssignmentStatus, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(UserId, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SecurityRoleName, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SecurityRoleIdentifier, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(AssignmentStatus, StringComparer.CurrentCultureIgnoreCase);
            return hash.ToHashCode();
        }
    }
}
