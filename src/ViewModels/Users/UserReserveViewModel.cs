using System.ComponentModel.DataAnnotations;

namespace ViewModels.Users
{
    public  class UserReserveViewModel
    {
        public string Id { get; set; }

        public string RoomId { get; set; }

     
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

    }
}
