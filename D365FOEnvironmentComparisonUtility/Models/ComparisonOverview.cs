namespace D365FOEnvironmentComparisonUtility.Models
{
    public class ComparisonOverview
    {
        public List<ComparisonOverviewObject> AddedObjects { get; set; }
        public List<ComparisonOverviewObject> ModifiedObjects { get; set; }
        public List<ComparisonOverviewObject> RemovedObjects { get; set; }  

        public ComparisonOverview()
        {
            AddedObjects = new List<ComparisonOverviewObject>();
            ModifiedObjects = new List<ComparisonOverviewObject>();
            RemovedObjects = new List<ComparisonOverviewObject>();
        }
    }

    public class ComparisonOverviewObject
    {
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
    }
}
