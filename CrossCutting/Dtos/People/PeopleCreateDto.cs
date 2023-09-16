using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.People
{
    public class PeopleCreateDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(18)]
        [MinLength(14)]
        public string Document { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
