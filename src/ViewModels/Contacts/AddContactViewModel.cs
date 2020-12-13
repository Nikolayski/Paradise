using System.ComponentModel.DataAnnotations;

namespace ViewModels.Contacts
{
    public  class AddContactViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name cannot be less than 2 characters long.")]
        [MaxLength(30, ErrorMessage ="Name cannot be more than 30 characters long")]
        public string Name { get; set; }

        [Required]
        [MinLength(6,ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [MinLength(2,ErrorMessage = "Invalid subject")]
        public string Subject { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Message should be at least 5 characters long!")]
        public string Message { get; set; }
        
    }
}
