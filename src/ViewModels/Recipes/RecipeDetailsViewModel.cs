namespace ViewModels.Recipes
{
    public   class RecipeDetailsViewModel
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public string CreatorUserName { get; set; }

        public int CookingTime { get; set; }
    }
}
