namespace D365FOEnvironmentComparisonUtility.Models
{
    public class Enums
    {
        public enum SecurableType
        {
            None = 0,
            MenuItemDisplay = 1,
            MenuItemOutput = 2,
            MenuItemAction = 3,
            FormControl = 11,
            TableField = 42,
            Table = 44,
            DataEntity = 67,
            ServiceOperation = 76,
            FormDatasource = 143,
            DataEntityMethod = 146
        }

        public enum SecurityLayerType
        {
            Role = 1,
            Duty = 2,
            Privilege = 3
        }
        public enum ObjectType
        {
            Display = 1,
            Output = 2,
            Action = 3,
            TableField = 42,
            Table = 44,
            DataEntity = 67,
            ServiceOperations = 76
        }

        public enum AccessType
        {
            None = 0,
            Read = 1,
            Update = 2,
            Create = 3,
            Delete = 5,
            Invoke = 6,
        }

        public enum AccessGrantPermissionType
        {
            Unset = 0,
            Allow = 1,
            Deny = 2
        }

        public enum UserLicenseType
        {
            None = 0,
            SelfServe = 1,
            Task = 2,
            Functional = 3,
            Enterprise = 4,
            Server = 5,
            Universal = 6,
            Activity = 7
        }
    }
}
