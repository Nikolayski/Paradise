using System.ComponentModel.DataAnnotations;

namespace ViewModels.Users
{
    public class UserOrderInputViewModel
    {

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3 )]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MinLength(10)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$")]
        public string PhoneNumber { get; set; }
    }
}
