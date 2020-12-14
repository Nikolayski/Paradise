using Microsoft.AspNetCore.Identity;

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
            this.Comments = new HashSet<Comment>();
            this.Posts = new HashSet<Post>();
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

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
