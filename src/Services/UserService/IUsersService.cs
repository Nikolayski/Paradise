using System.Threading.Tasks;
using ViewModels.Users;

namespace Services.UserService
{
    public interface IUsersService
    {
        UserReserveViewModel GetUser(string userId);
        Task DeleteCartCollectionAsync(string userId);
    }
}
