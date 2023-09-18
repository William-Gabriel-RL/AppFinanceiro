using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.Transaction
{
    public class TransactionCreateDto
    {
        private decimal _value;

        [Required]
        public decimal Value {
            get => _value;
            set
            {
                if (value == 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _value = value;
            }
        }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Description { get; set; } = string.Empty;
    }
}
