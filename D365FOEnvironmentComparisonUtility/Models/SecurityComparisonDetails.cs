namespace D365FOEnvironmentComparisonUtility.Models
{
    public class SecurityComparisonDetails
    {
        public List<SecurityLayer> AddedRoles { get; set; }
        public List<SecurityAccessChanges> AddedRoleAccess { get; set; }
        public List<SecurityLayer> RemovedRoles { get; set; }
        public List<SecurityAccessChanges> RemovedRoleAccess { get; set; }
        public List<SecurityLayer> ModifiedRoles { get; set; }
        public List<SecurityAccessChanges> ModifiedRoleAccess { get; set; }
        public List<SecurityLayer> AddedDuties { get; set; }
        public List<SecurityAccessChanges> AddedDutyAccess { get; set; }
        public List<SecurityLayer> RemovedDuties { get; set; }
        public List<SecurityAccessChanges> RemovedDutyAccess { get; set; }
        public List<SecurityLayer> ModifiedDuties { get; set; }
        public List<SecurityAccessChanges> ModifiedDutyAccess { get; set; }
        public List<SecurityLayer> AddedPrivileges { get; set; }
        public List<SecurityAccessChanges> AddedPrivilegeAccess { get; set; }
        public List<SecurityLayer> RemovedPrivileges { get; set; }
        public List<SecurityAccessChanges> RemovedPrivilegeAccess { get; set; }
        public List<SecurityLayer> ModifiedPrivilges { get; set; }
        public List<SecurityAccessChanges> ModifiedPrivilegeAccess { get; set; }

        public SecurityComparisonDetails()
        {
            AddedRoles = new List<SecurityLayer>();
            AddedRoleAccess = new List<SecurityAccessChanges>();
            RemovedRoles = new List<SecurityLayer>();
            RemovedRoleAccess = new List<SecurityAccessChanges>();
            ModifiedRoles = new List<SecurityLayer>();
            ModifiedRoleAccess = new List<SecurityAccessChanges>();
            AddedDuties = new List<SecurityLayer>();
            AddedDutyAccess = new List<SecurityAccessChanges>();
            RemovedDuties = new List<SecurityLayer>();
            RemovedDutyAccess = new List<SecurityAccessChanges>();
            ModifiedDuties = new List<SecurityLayer>();
            ModifiedDutyAccess = new List<SecurityAccessChanges>();
            AddedPrivileges = new List<SecurityLayer>();
            AddedPrivilegeAccess = new List<SecurityAccessChanges>();
            RemovedPrivileges = new List<SecurityLayer>();
            RemovedPrivilegeAccess = new List<SecurityAccessChanges>();
            ModifiedPrivilges = new List<SecurityLayer>();
            ModifiedPrivilegeAccess = new List<SecurityAccessChanges>();
        }
    }
}
