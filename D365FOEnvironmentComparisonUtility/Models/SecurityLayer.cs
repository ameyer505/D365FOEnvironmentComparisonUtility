namespace D365FOEnvironmentComparisonUtility.Models
{
    public class SecurityLayer
    {
        public string Identifier { get; set; }
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj as SecurityLayer);
        }

        public bool Equals(SecurityLayer sl)
        {
            return sl != null &&
                string.Equals(Identifier, sl.Name, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(Name, sl.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Identifier);
            hash.Add(Name);
            return hash.ToHashCode();
        }
    }
}
