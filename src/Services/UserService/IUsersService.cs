using ViewModels.Users;

using System.Threading.Tasks;

namespace Services.UserService
{
    public interface IUsersService
    {
        UserReserveViewModel GetUser(string userId);

        Task DeleteCartCollectionAsync(string userId);
    }
}
