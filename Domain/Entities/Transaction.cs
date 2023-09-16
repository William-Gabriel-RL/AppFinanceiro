using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Transaction
    {
        [Key]
        public Guid IdTransaction { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        [ForeignKey("Account")]
        public Guid IdAccount { get; set; }

        public virtual Account? Account { get; set; }

        [Required]
        [MaxLength(256)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
