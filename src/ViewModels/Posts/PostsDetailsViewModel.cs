using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Comments;

namespace ViewModels.Posts
{
  public  class PostsDetailsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string CreatorUserName { get; set; }

        public ICollection<CommentAllViewModel> Comments{ get; set; }
        public int CommentsCount => this.Comments.Count();



    }
}
