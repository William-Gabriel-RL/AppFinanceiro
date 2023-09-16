using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class People
    {
        [Key]
        public Guid IdPeople { get; set; }

        [Required]
        [MaxLength(18)]
        [MinLength(14)]
        public string Document { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}