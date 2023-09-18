using CrossCutting.Dtos.Card;

namespace CrossCutting.Dtos.Account
{
    public class AccountAndCardReadDto
    {
        public Guid IdAccount { get; set; }
        public string? Branch { get; set; }
        public string? AccountNumber { get; set; }
        public IEnumerable<CardReadDto> Cards { get; set; } = new List<CardReadDto>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
