using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Account
    {
        [Key]
        public Guid IdAccount {  get; set; }

        [Required]
        [StringLength(3)]
        public string Branch { get; set; } = string.Empty;

        [Required]
        [StringLength(9)]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        [ForeignKey("People")]
        public Guid IdPeople { get; set; }

        public virtual People? People { get; set; }

        [Required]
        public double Balance { get; set; } = 0.0;

        [Required]
        public bool IsActive { get; set;} = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
