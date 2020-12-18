using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Rooms
{
    public class ReserveRoomViewModel
    {
        private const string PhoneNumberErrorMessage = "Phone Number should have 9 digits.";

        public string RoomId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,}$", ErrorMessage = PhoneNumberErrorMessage)]
        public string PhoneNumber { get; set; }

    }
}
