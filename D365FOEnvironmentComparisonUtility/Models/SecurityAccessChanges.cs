using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365FOEnvironmentComparisonUtility.Models
{
    public class SecurityAccessChanges
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
                string.Equals(RoleSystemName, sac.RoleSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(SubRoleSystemName, sac.SubRoleSystemName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(DutySystemName, sac.DutySystemName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(PrivilegeSystemName, sac.PrivilegeSystemName, StringComparison.CurrentCultureIgnoreCase) &&
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
            hash.Add(RoleSystemName);
            hash.Add(SubRoleSystemName);
            hash.Add(DutySystemName);
            hash.Add(PrivilegeSystemName);
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
