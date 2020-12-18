using Models.Enums;

using System.ComponentModel.DataAnnotations;

namespace ViewModels.Recipes
{
    public   class AddRecipeInputViewModel
    {
        private const string NameErrorMessage = "Name should be at least 4 characters long!";
        private const string InstructionsErrorMessage = "Instructions should be at least 30 characters long!";
        private const string CookingTimeErrorMessage = "Cooking time cannot be zero or negative number!";

        [Required]
        [MinLength(4,ErrorMessage = NameErrorMessage)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(1, 3)]
        public ProductType ProductType { get; set; }

        [Required]
        [MinLength(30, ErrorMessage = InstructionsErrorMessage)]
        public string Instructions { get; set; }

        [Range(1, int.MaxValue,ErrorMessage = CookingTimeErrorMessage)]
        public int CookingTime { get; set; }
    }
}
