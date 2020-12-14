using Models.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CartProducts = new HashSet<CartProduct>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public ProductCountry ProductCountry { get; set; }

        public ProductType ProductType { get; set; }

        [Required]
        public string Image { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }


    }
}
