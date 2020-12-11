using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Mapping;

using Data;
using Models;
using Services.SeedService;
using Services.ProductService;
using Services.ImageService;
using Services.CartService;
using Services.RoomService;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Services.Comments;
using Services.UserService;
using Services.RecipeService;
using Services.PostService;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //db
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
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

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //if (!userManager.Users.Any(x => x.UserName == "nikolayski@abv.bg"))
            //{
            //    userManager.CreateAsync(new ApplicationUser
            //    {
            //        UserName = "nikolayski@abv.bg",
            //        Email = "nikolayski@abv.bg",
            //        EmailConfirmed = true
            //    }, "Dadada1122_").GetAwaiter().GetResult();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
