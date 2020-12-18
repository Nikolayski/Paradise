using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Users
{
    public class UserReserveFinishViewModel
    {
        private const string FirstNameErrorMessage = "First name should be at least 2 characters long!";
        private const string LastNameErrorMessage = "Last name should be at least 2 characters long!";
        private const string NameOfCardErrorMessage = "Invalid names!";
        private const string CreaditCardNumberErrorMessage = "Invalid card number!";
        private const string ExpirationErrorMessage = "Invalid expiration date!";
        private const string CvvErrorMessage = "Invalid CVV number!";
        private const string PhoneNumberErrorMessage = "Invalid phone number!";

        public string Id { get; set; }

        public string Room { get; set; }

        [Required]
        [Display(Name = "First name")]
        [MinLength(2, ErrorMessage = FirstNameErrorMessage)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [MinLength(2, ErrorMessage = LastNameErrorMessage)]
        public string LastName { get; set; }

        [Display(Name = "Check-in-date")]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check-out-date")]
        public DateTime CheckOut { get; set; }

        [Required]
        [Display(Name = "Cardholder names")]
        [RegularExpression(@"^[A-Z][a-z]* [A-Z]{1}[a-z]*$", ErrorMessage = NameOfCardErrorMessage)]
        public string NameOfCard { get; set; }


        [Required]
        [Display(Name = "Card number")]
        [RegularExpression(@"\d{16}", ErrorMessage = CreaditCardNumberErrorMessage)]
        public string CreaditCardNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}\/\d{2}$", ErrorMessage = ExpirationErrorMessage)]
        public string Expiration { get; set; }

        [RegularExpression(@"^\d{3,4}$", ErrorMessage = CvvErrorMessage)]
        public int Cvv { get; set; }

        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = PhoneNumberErrorMessage)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
