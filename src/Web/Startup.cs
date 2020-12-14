using AutoMapper;
using Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Data;
using Models;
using System.Linq;
using Services.CartService;
using Services.Comments;
using Services.ContactService;
using Services.ImageService;
using Services.ProductService;
using Services.PostService;
using Services.RoomService;
using Services.RecipeService;
using Services.SeedService;
using Services.UserService;

namespace Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //db
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   this.configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //automapper
            services.AddAutoMapper(typeof(ApplicationProfile).Assembly);

            //services
            services.AddTransient<ISeedService, SeedService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IContactService, ContactService>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                if (!dbContext.Products.Any())
                {
                    new SeedService(dbContext, serviceScope.ServiceProvider).AddProductsAsync().GetAwaiter().GetResult();

                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
