using Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(1,3)]
        public ProductType ProductType{ get; set; }

        [Required]
        [MinLength(30)]
        public string Instructions { get; set; }

        [Range(0,int.MaxValue)]
        public int CookingTime { get; set; }

        public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }




    }
}
