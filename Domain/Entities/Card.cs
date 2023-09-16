using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Card
    {
        [Key]
        public Guid IdCard { get; set; }

        [Required]
        [ForeignKey("Account")]
        public Guid IdAccount {  get; set; }

        public Account? Account { get; set; }

        [Required]
        [ForeignKey("CardType")]
        public int IdCardType { get; set; }

        public virtual CardType? CardType { get; set; }

        [Required]
        [StringLength(19)]
        public string Number { get; set; } = string.Empty;

        [Required]
        [StringLength(3)]
        public string Cvv { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
