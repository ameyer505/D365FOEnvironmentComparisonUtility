namespace D365FOEnvironmentComparisonUtility.Models
{
    public class ComparisonDetail
    {
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
        public string Action { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string OldObject { get; set; }
        public string NewObject { get; set; }
    }
}
