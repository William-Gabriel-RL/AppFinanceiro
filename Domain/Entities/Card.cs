﻿using System.ComponentModel.DataAnnotations;
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

        private string _type = string.Empty;

        [Required]
        public string Type {
            get => _type;
            set
            {
                if (value != "virtual" && value != "physical")
                    throw new ArgumentException(null, nameof(value));
                _type = value;
            }
        }

        private string _number = string.Empty;

        [Required]
        [StringLength(19)]
        public string? Number
        {
            get => _number[(_number.Length - 4).._number.Length];
            set => _number = value!;
        }

        [Required]
        [StringLength(3)]
        public string Cvv { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
