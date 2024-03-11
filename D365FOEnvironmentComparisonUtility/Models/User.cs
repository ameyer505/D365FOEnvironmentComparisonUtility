namespace D365FOEnvironmentComparisonUtility.Models
{
    public class User
    {
        public string Alias { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Enabled { get; set; }
        public string PersonName { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User u)
        {
             return u != null &&
                string.Equals(Alias, u.Alias, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Company, u.Company, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Email, u.Email, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(Enabled, u.Enabled, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(PersonName, u.PersonName, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(UserID, u.UserID, StringComparison.CurrentCultureIgnoreCase) &&
                string.Equals(UserName, u.UserName, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Alias, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(Company, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(Email, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(Enabled, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(PersonName, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(UserID, StringComparer.CurrentCultureIgnoreCase);
            hash.Add(UserName, StringComparer.CurrentCultureIgnoreCase);
            return hash.ToHashCode();
        }
    }
}
