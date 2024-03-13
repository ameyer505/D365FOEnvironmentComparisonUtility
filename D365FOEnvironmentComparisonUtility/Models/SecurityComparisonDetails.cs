namespace D365FOEnvironmentComparisonUtility.Models
{
    public class SecurityComparisonDetails
    {
        public List<SecurityAccessChanges> AddedRoleAccess { get; set; }
        public List<SecurityAccessChanges> RemovedRoleAccess { get; set; }
        public List<SecurityAccessChanges> ModifiedRoleAccess { get; set; }

        public SecurityComparisonDetails()
        {
            AddedRoleAccess = new List<SecurityAccessChanges>();
            ModifiedRoleAccess = new List<SecurityAccessChanges>();
            RemovedRoleAccess = new List<SecurityAccessChanges>();
        }
    }
}
