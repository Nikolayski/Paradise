using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public   class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Comments = new HashSet<Comment>();
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

        public bool IsDeleted { get; set; }

        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public virtual ICollection<Comment> Comments{ get; set; }
    }
}
