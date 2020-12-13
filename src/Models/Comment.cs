using Models.Enums;
using System;

namespace Models
{
    public   class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public CommentType CommentType { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }


        public string PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}
