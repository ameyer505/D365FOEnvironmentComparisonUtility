namespace D365FOEnvironmentComparisonUtility.Models
{
    public class SecurityAccessChanges
    {
        public string RoleIdentifier { get; set; }
        public string RoleName { get; set; }
        public string SubRoleIdentifier { get; set; }
        public string SubRoleName { get; set; }
        public string DutyIdentifier { get; set; }
        public string DutyName { get; set; }
        public string PrivilegeIdentifier { get; set; }
        public string PrivilegeName { get; set; }
        public string SecurableObject { get; set; }
        public string SecurableObjectType { get; set; }
        public string Read { get; set; }
        public string Update { get; set; }
        public string Create { get; set; }
        public string Delete { get; set; }
        public string Invoke { get; set; }
        public string Action { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SecurityAccessChanges);
        }

        public bool Equals(SecurityAccessChanges sac)
        {
            return sac != null &&
                string.Equals(RoleIdentifier, sac.RoleIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SubRoleIdentifier, sac.SubRoleIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(DutyIdentifier, sac.DutyIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(PrivilegeIdentifier, sac.PrivilegeIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SecurableObject, sac.SecurableObject, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SecurableObjectType, sac.SecurableObjectType, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Read, sac.Read, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Update, sac.Update, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Create, sac.Create, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Delete, sac.Delete, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Invoke, sac.Invoke, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(RoleIdentifier);
            hash.Add(SubRoleIdentifier);
            hash.Add(DutyIdentifier);
            hash.Add(PrivilegeIdentifier);
            hash.Add(SecurableObject);
            hash.Add(SecurableObjectType);
            hash.Add(Read);
            hash.Add(Update);
            hash.Add(Create);
            hash.Add(Delete);
            hash.Add(Invoke);
            return hash.ToHashCode();
        }
    }
}
