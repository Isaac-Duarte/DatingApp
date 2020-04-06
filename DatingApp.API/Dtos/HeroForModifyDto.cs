using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class HeroForModifyDto
    {
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Capes { get; set; }
        public string Origin { get; set; }
        public string Description { get; set; }
    }
}