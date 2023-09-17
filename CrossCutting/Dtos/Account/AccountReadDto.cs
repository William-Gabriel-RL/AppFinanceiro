namespace CrossCutting.Dtos.Account
{
    public class AccountReadDto
    {
        public Guid IdAccount { get; set; }
        public string? Branch { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
