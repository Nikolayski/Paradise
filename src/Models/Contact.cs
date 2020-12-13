using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public  class Contact
    {
        public Contact()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(6)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Message { get; set; }

    }
}
