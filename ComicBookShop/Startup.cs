using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ComicBookShop.Context;
using Microsoft.EntityFrameworkCore;
using ComicBookShop.Repository;
using ComicBookShop.Service;
using ComicBookShop.Helper;
using ComicBookShop.Model;

namespace ComicBookShop
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

            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddDbContextPool<MySqlContext>(
                options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<IComicBookRepository, ComicBookRepository>();
            services.AddTransient<IOrderComicBookRepository, OrderComicBookRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IComicBookService, ComicBookService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICartItemService, CartItemService>();

            services.AddControllers(opt => opt.Filters.Add(new HttpResponseExceptionFilter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
