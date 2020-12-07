using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Users
{
    public   class UserReserveFinishViewModel
    {
        public string Id { get; set; }

        public string RoomId { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        public DateTime  CheckIn{ get; set; }
        public DateTime  CheckOut{ get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-z]* [A-Z]{1}[a-z]*$")]
        public string NameOfCard { get; set; }


        [Required]
        [RegularExpression(@"\d{16}")]
        public string CreaditCardNumber { get; set; }

        [Required]
        public string Expiration { get; set; }
        public int Cvv { get; set; }

        [Required]
        [RegularExpression(@"\d{10}")]
        public string PhoneNumber { get; set; }

       
    }
}
