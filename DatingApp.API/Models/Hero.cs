using System;

namespace DatingApp.API.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int Capes { get; set; }
        public DateTime Origin { get; set; }
    }
}