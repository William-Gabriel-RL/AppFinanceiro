using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CardType
    {
        [Key]
        public int IdCardType { get; set; }

        [Required]
        public int Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
