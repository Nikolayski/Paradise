using System.ComponentModel.DataAnnotations;

namespace ViewModels.Recipes
{
    public   class RecipeEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Name should be at least 4 characters long!")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MinLength(30,ErrorMessage = "Instructions should be at least 20 characters long!")]
        public string Instructions { get; set; }

        [Range(0, int.MaxValue)]
        public int CookingTime { get; set; }
    }
}



