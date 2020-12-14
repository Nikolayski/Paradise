using Models.Enums;

using System.ComponentModel.DataAnnotations;

namespace ViewModels.Recipes
{
    public   class AddRecipeInputViewModel
    {
        [Required]
        [MinLength(4,ErrorMessage = "Name should be at least 4 characters long!")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(1, 3)]
        public ProductType ProductType { get; set; }

        [Required]
        [MinLength(20, ErrorMessage = "Instructions should be at least 20 characters long!")]
        public string Instructions { get; set; }

        [Range(1, int.MaxValue,ErrorMessage = "Cooking time cannot be zero or negative number!")]
        public int CookingTime { get; set; }
    }
}
