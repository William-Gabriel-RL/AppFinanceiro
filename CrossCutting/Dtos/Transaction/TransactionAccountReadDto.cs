namespace CrossCutting.Dtos.Transaction
{
    public class TransactionAccountReadDto
    {
        public IEnumerable<TransactionReadDto> Transactions { get; set; } = new List<TransactionReadDto>();
    }
}
