namespace Domain.Models
{
    public class GroupOfPrivileges
    {
        public string _id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; }
        public List<Claims> Claims { get; set; } = new List<Claims>();
    }
}