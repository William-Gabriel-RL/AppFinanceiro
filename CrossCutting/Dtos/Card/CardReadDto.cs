namespace CrossCutting.Dtos.Card
{
    public class CardReadDto
    {
        public Guid IdCard { get; set; }
        public string? Type { get; set; }

        private string _number = string.Empty;

        public string? Number
        {
            get => _number[(_number.Length-4).._number.Length];
            set => _number = value!;
        }

        public string? Cvv { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
