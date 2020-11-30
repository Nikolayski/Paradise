﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [MinLength(10)]
        public string Address { get; set; }
        
        public string CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<UserRoom> UserRooms { get; set; }


    
    }
}
