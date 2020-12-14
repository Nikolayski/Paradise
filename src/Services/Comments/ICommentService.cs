using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Comments;

namespace Services.Comments
{
    public  interface ICommentService
    {
        Task AddCommentAsync(string userId, string name, string message);

        IEnumerable<CommentAllViewModel> GetAllAsync();
        Task AddCommentToPostAsync(string userId, string name, string message, string postId);
        Task RemoveByIdAsync(string id);
    }
}
