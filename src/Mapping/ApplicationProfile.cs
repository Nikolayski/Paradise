using AutoMapper;
using Models;
using ViewModels.Comments;
using ViewModels.Contacts;
using ViewModels.Index;
using ViewModels.Posts;
using ViewModels.Products;
using ViewModels.Recipes;
using ViewModels.Rooms;
using ViewModels.Users;

namespace Mapping
{
  public  class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //products

            this.CreateMap<Product, ProductsAllViewModel>();
            this.CreateMap<Product, SingleProductViewModel>();
            this.CreateMap<Product, RandomProductsViewComponentViewModel>()
                        .ForMember(vm => vm.Description,
                                   map => map.MapFrom(p => p.Description.Substring(0, 50)));

            //rooms

            this.CreateMap<Room, RoomsAllViewModel>()
                            .ForMember(vm => vm.RoomType,
                                       map => map.MapFrom(r => r.RoomType.ToString()));

           this.CreateMap<Room, RoomDetailsViewModel>();
            this.CreateMap<Room, RoomCheckViewModel>();

            //index images

            this.CreateMap<Image, IndexImageViewModel>();

            //comments

            this.CreateMap<Comment, CommentAllViewModel>()
                                .ForMember(dto => dto.FirstName,
                                           opt => opt.MapFrom(c => c.User.FirstName));

            //users

            this.CreateMap<ApplicationUser,UserReserveViewModel>();

            //recipes

            this.CreateMap<AddRecipeInputViewModel, Recipe>();
            this.CreateMap<Recipe, RecipeAllViewModel>();
            this.CreateMap<Recipe, RecipeDetailsViewModel>();
            this.CreateMap<Recipe, UserRecipesViewModel>();

           //posts

            this.CreateMap<PostInputViewModel, Post>();
            this.CreateMap<Post, PostAllViewModel>();
            this.CreateMap<Post, PostsDetailsViewModel>();

            //contacts
            this.CreateMap<AddContactViewModel, Contact>();

        }
    }
}
