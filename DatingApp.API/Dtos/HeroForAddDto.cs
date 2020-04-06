using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class HeroForAddDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Capes { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Description { get; set; }
    }
}