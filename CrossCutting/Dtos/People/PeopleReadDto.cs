namespace CrossCutting.Dtos.People
{
    public class PeopleReadDto
    {
        public Guid IdPeople { get; set; }
        public string? Name { get; set; }
        public string? Document { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
