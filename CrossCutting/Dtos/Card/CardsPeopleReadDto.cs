namespace CrossCutting.Dtos.Card
{
    public class CardsPeopleReadDto
    {
        public IEnumerable<CardReadDto> Cards { get; set; } = new List<CardReadDto>();
    }
}
