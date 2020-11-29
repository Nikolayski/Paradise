using System;
using System.Collections.Generic;

namespace Models
{
    public class Cart
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CartProducts = new HashSet<CartProduct>();
            this.Users = new HashSet<ApplicationUser>();
        }
        public string Id { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }


    }
}
