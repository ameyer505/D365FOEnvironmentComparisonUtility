namespace D365FOEnvironmentComparisonUtility.Models
{
    public class SecurityLayer
    {
        public string SystemName { get; set; }
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj as SecurityLayer);
        }

        public bool Equals(SecurityLayer sl)
        {
            return sl != null &&
                string.Equals(SystemName, sl.Name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(Name, sl.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(SystemName);
            hash.Add(Name);
            return hash.ToHashCode();
        }
    }
}
