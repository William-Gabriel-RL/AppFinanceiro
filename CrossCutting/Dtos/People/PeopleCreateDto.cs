using CrossCutting.Extensions;
using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Dtos.People
{
    public class PeopleCreateDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; } = string.Empty;

        private string _document = string.Empty;

        [Required]
        [MaxLength(14)]
        [MinLength(11)]
        public string Document
        {
            get => _document;
            set
            {
                _document = value.ExtractNumbers();
            }
        }

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
