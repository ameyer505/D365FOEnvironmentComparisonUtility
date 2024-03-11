namespace D365FOEnvironmentComparisonUtility.Models
{
    public class SecurityUserRoleOrganization
    {
        public string UserId { get; set; }
        public string SecurityRoleIdentifier { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationType { get; set; }
        public string OperatingUnitType { get; set; }
        public string HierarchyType { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SecurityUserRoleOrganization);
        }

        public bool Equals(SecurityUserRoleOrganization s)
        {
            return s != null &&
                string.Equals(UserId, s.UserId, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SecurityRoleIdentifier, s.SecurityRoleIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(OrganizationId, s.OrganizationId, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(OrganizationType, s.OrganizationType, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(OperatingUnitType, s.OperatingUnitType, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(HierarchyType, s.HierarchyType, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(UserId, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SecurityRoleIdentifier, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(OrganizationId, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(OrganizationType, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(OperatingUnitType, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(HierarchyType, StringComparer.CurrentCultureIgnoreCase);
            return hash.ToHashCode();
        }
    }
}
