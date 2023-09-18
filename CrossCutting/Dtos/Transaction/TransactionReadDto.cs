namespace CrossCutting.Dtos.Transaction
{
    public class TransactionReadDto
    {
        public Guid IdTransaction { get; set; }

        public decimal Value { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
