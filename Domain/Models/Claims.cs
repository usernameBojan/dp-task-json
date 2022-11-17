namespace Domain.Models
{
    public class Claims
    {
        public Claims(int claimType, string value)
        {
            ClaimType = claimType;
            Value = value;
        }

        public int ClaimType { get; set; }
        public string Value { get; set; }
    }
}