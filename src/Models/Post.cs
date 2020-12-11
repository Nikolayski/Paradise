using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public   class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime  CreatedOn{ get; set; }

        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
    }
}
