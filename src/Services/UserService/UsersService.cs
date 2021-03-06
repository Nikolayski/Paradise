﻿using Data;
using ViewModels.Users;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using System.Linq;
using System.Threading.Tasks;

namespace Services.UserService
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public UsersService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task DeleteCartCollectionAsync(string userId)
        {
            var cartId = this.db.Users.Where(x => x.Id == userId).Select(x => x.CartId).FirstOrDefault();
            var cartProducts = this.db.CartProducts.Where(X => X.CartId == cartId).ToList();
            this.db.CartProducts.RemoveRange(cartProducts);
            await this.db.SaveChangesAsync();
        }

        public UserReserveViewModel GetUser(string userId)
        {
            return this.db.Users.Where(x => x.Id == userId)
                                .ProjectTo<UserReserveViewModel>(this.mapper.ConfigurationProvider)
                                .FirstOrDefault();
        }
    }
}
