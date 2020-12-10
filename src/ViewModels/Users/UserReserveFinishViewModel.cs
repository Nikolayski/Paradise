using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Users
{
    public   class UserReserveFinishViewModel
    {
        public string Id { get; set; }

        public string Room { get; set; }

        [Required]
        [Display(Name = "First name")]
        [MinLength(2,ErrorMessage = "First name should be at least 2 characters long!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [MinLength(2,ErrorMessage ="Last name should be at least 2 characters long!")]
        public string LastName { get; set; }

        [Display(Name = "Check In Date")]
        public DateTime  CheckIn{ get; set; }

        [Display(Name = "Check out Date")]
        public DateTime  CheckOut{ get; set; }

        [Required]
        [Display(Name = "Cardholder names")]
        [RegularExpression(@"^[A-Z][a-z]* [A-Z]{1}[a-z]*$",ErrorMessage ="Invalid card names!")]
        public string NameOfCard { get; set; }


        [Required]
        [Display(Name = "Card number")]
        [RegularExpression(@"\d{16}",ErrorMessage ="Invalid card number!")]
        public string CreaditCardNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}\/\d{2}$",ErrorMessage ="Invalid expiration date!")]
        public string Expiration { get; set; }

        [RegularExpression(@"^\d{3,4}$",ErrorMessage ="Invalid CVV number!")]
        public int Cvv { get; set; }

        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage ="Invalid phone number!")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

       
    }
}
