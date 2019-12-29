using DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Models;
using Microsoft.AspNetCore.Identity;
using Web.DB;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;
using System.Reflection;
using Autofac;
using Alexinea.Autofac.Extensions.DependencyInjection;
using Service;
using Repository;
using IService;
using IRepository;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // 服务的注入和配置
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
        
            //Identity添加的东西
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            //由于Identity对密码要求很严格,所以可以设置的宽松一些
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireLowercase = false; //需要小写
                options.Password.RequireNonAlphanumeric = false;//需要字母
                options.Password.RequireUppercase = false;//需要大写
            });
            //认证的地址设置为Account/Login
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });
            //AutoMapper注入
            services.AddAutoMapper(typeof(Startup));

            //注入自己写的接口,这两种方式都可以,加不加typeof都行,但是使用AddSingleton报错,不知道为啥,只能使用AddScoped
            services.AddScoped(typeof(IMovieService), typeof(MovieService));
            services.AddScoped(typeof(IMovieRepository), typeof(MovieRepository));
            //services.AddScoped<IMovieService, MovieService>();
            //services.AddScoped<IMovieRepository, MovieRepository>();

        }

        // 中间件
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            });
        }
    }
}
