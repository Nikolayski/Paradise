using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserRooms = new HashSet<UserRoom>();
            //this.UserCart = new HashSet<UserCart>();
        }

        public string CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<UserRoom> UserRooms { get; set; }
    
    }
}
