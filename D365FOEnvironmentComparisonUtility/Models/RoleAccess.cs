namespace D365FOEnvironmentComparisonUtility.Models
{
    public class RoleAccess
    {
        public string RoleIdentifier { get; set; }
        public string RoleName { get; set; }
        public string SubRoleIdentifer { get; set; }
        public string SubRoleName { get; set; }
        public string DutyIdentifier { get; set; }
        public string DutyName { get; set; }
        public string PrivilegeIdentifier { get; set; }
        public string PrivilegeName { get; set; }
        public string SecurableObject { get; set; }
        public string SecurableType { get; set; }
        public string Invoke { get; set; }
        public string Read { get; set; }
        public string Update { get; set; }
        public string Create { get; set; }
        public string Delete { get; set; }
        public string ComputedLicense { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as RoleAccess);
        }

        public bool Equals(RoleAccess ra)
        {
            return ra != null &&
                string.Equals(RoleIdentifier, ra.RoleIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SubRoleIdentifer, ra.SubRoleIdentifer, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(DutyIdentifier, ra.DutyIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(PrivilegeIdentifier, ra.PrivilegeIdentifier, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SecurableObject, ra.SecurableObject, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SecurableType, ra.SecurableType, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Read, ra.Read, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Update, ra.Update, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Create, ra.Create, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Delete, ra.Delete, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Invoke, ra.Invoke, StringComparison.CurrentCultureIgnoreCase); //&&
                //string.Equals(ComputedLicense, ra.ComputedLicense, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(RoleIdentifier, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SubRoleIdentifer, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(DutyIdentifier, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(PrivilegeIdentifier, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SecurableObject, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(SecurableType, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(Read, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(Update, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(Create, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(Delete, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(Invoke, StringComparer.CurrentCultureIgnoreCase);
            //hash.Add(ComputedLicense, StringComparer.CurrentCultureIgnoreCase);
            return hash.ToHashCode();
        }
    }
}
