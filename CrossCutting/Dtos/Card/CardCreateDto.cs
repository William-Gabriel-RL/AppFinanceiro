using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.Card
{
    public class CardCreateDto
    {
        private string _type = string.Empty;

        [Required]
        public string Type
        {
            get => _type;
            set
            {
                if (value != "virtual" && value != "physical")
                    throw new ArgumentException(null, nameof(value));
                _type = value;
            }
        }

        private string _number = string.Empty;

        [Required]
        [StringLength(19)]
        public string? Number
        {
            get => _number[(_number.Length - 4).._number.Length];
            set => _number = value!;
        }

        [Required]
        [StringLength(3)]
        public string Cvv { get; set; } = string.Empty;

    }
}
