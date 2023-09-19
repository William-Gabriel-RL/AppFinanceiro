using CrossCutting.Dtos.Pagination;

namespace CrossCutting.Dtos.Transaction
{
    public class TransactionAccountReadDto
    {
        public IEnumerable<TransactionReadDto> Transactions { get; set; } = new List<TransactionReadDto>();
        public PaginationDto Pagination { get; set; } = new PaginationDto();
    }
}
