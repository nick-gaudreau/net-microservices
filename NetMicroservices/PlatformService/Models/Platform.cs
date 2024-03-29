﻿using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required] // Cannot be null
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Publisher { get; set; }

        [Required]
        [MaxLength(64)]
        public string Cost { get; set; }
    }
}