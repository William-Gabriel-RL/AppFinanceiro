using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Transaction
    {
        [Key]
        public Guid IdTransaction { get; set; }

        private decimal _value;

        [Required]
        public decimal Value
        {
            get => _value;
            set
            {
                if (value == 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _value = value;
            }
        }

        [Required]
        [ForeignKey("Account")]
        public Guid IdAccount { get; set; }

        public virtual Account? Account { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Description { get; set; } = string.Empty;

        public bool IsReverted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
