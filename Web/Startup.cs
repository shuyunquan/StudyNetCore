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
using Service;
using Repository;
using IService;
using IRepository;
using System;
using Autofac;
using Microsoft.AspNetCore.Mvc;

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
            //services.AddScoped(typeof(IMovieService), typeof(MovieService));
            //services.AddScoped(typeof(IMovieRepository), typeof(MovieRepository));
            //services.AddScoped<IMovieService, MovieService>();
            //services.AddScoped<IMovieRepository, MovieRepository>();

            //使用缓存
            services.AddMemoryCache();

            //url全部转换成小写
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            //防止CSRF攻击
            services.AddAntiforgery(options =>
            {
                //使用cookiebuilder属性设置cookie属性。
                options.FormFieldName = "AntiforgeryKey_shuyunquan";
                options.HeaderName = "X-CSRF-TOKEN-shuyunquan";
                options.SuppressXFrameOptionsHeader = false;
            });
            services.AddMvc(options =>
            {
                //这个是给所有的post Action都开启了防止CSRF攻击
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

        }

        /// <summary>
        /// Autofac依赖注入
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(typeof(Program).Assembly).
            //    Where(x => x.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes();

            builder.RegisterType<MovieService>().As<IMovieService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();

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

            //这个使用静态文件就是确定了静态目录是wwwroot
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
