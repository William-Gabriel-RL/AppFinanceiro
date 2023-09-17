using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.Account
{
    public class AccountCreateDto
    {
        [Required]
        [StringLength(3)]
        public string? Branch { get; set; }

        [Required]
        [StringLength(9)]
        public string AccountNumber { get; set; } = string.Empty;
    }
}
