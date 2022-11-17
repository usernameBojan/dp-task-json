namespace Domain.Models
{
    public class Root
    {
        public string _id { get; set; } = string.Empty;
        public string FizickoLiceId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string SaltHash { get; set; } = string.Empty;
        public string SecurityStamp { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Embg { get; set; }
        public string? Telefon { get; set; }
        public string? Mobilen { get; set; } = string.Empty;
        public string? Adresa { get; set; } = string.Empty;
        public List<Claims> Claims { get; set; } = new List<Claims>();
        public List<Claims> CanAddClaims { get; set; } = new List<Claims>();
        public bool Active { get; set; }
        public string? PublicKey { get; set; }
        public string? SecurityQuestion { get; set; } = string.Empty;
        public string? SecurityAnswer { get; set; }
        public string? FizickoLiceIme { get; set; }
        public string? FizickoLicePrezime { get; set; }
        public int? FizickoLiceEmbg { get; set; }
        public string? MojTerminSessionToken { get; set; }
        public bool MojTerminAutomaticLoginFaildFlag { get; set; }
        public List<GroupOfPrivileges> GroupOfPrivileges { get; set; } = new List<GroupOfPrivileges>();
        public string? Company { get; set; }
        public string? SoftverskaKukjaId { get; set; }
        public string? LoginAsUserId { get; set; }
        public string? AuthorizedUserId { get; set; }
        public string? SubscribedResources { get; set; }
    }
}