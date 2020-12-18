using System.ComponentModel.DataAnnotations;

namespace ViewModels.Contacts
{
    public  class AddContactViewModel
    {
        private const string NameMinLengthtErrorMessage = "Name cannot be less than 2 characters long.";
        private const string NameMaxLengthErrorMessage = "Name cannot be more than 30 characters long";
        private const  string SubjectErrorMessage = "Invalid subject!";
        private const  string EmailErrorMessage = "Invalid email!";
        private const  string MessageErrorMessage = "Message should be at least 5 characters long!";
        [Required]
        [MinLength(2, ErrorMessage = NameMinLengthtErrorMessage)]
        [MaxLength(30, ErrorMessage = NameMaxLengthErrorMessage)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b",ErrorMessage = EmailErrorMessage)]
        public string Email { get; set; }

        [Required]
        [MinLength(2,ErrorMessage = SubjectErrorMessage)]
        public string Subject { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = MessageErrorMessage)]
        public string Message { get; set; }
        
    }
}
