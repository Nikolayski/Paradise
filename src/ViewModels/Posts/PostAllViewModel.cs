using System;
using System.Globalization;

namespace ViewModels.Posts
{
  public  class PostAllViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn{ get; set; }

        public string CreatedOnToString => this.CreatedOn.AddHours(2).ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
