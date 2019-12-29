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

        // �����ע�������
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
        
            //Identity��ӵĶ���
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            //����Identity������Ҫ����ϸ�,���Կ������õĿ���һЩ
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireLowercase = false; //��ҪСд
                options.Password.RequireNonAlphanumeric = false;//��Ҫ��ĸ
                options.Password.RequireUppercase = false;//��Ҫ��д
            });
            //��֤�ĵ�ַ����ΪAccount/Login
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });
            //AutoMapperע��
            services.AddAutoMapper(typeof(Startup));

            //ע���Լ�д�Ľӿ�,�����ַ�ʽ������,�Ӳ���typeof����,����ʹ��AddSingleton����,��֪��Ϊɶ,ֻ��ʹ��AddScoped
            services.AddScoped(typeof(IMovieService), typeof(MovieService));
            services.AddScoped(typeof(IMovieRepository), typeof(MovieRepository));
            //services.AddScoped<IMovieService, MovieService>();
            //services.AddScoped<IMovieRepository, MovieRepository>();

        }

        // �м��
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
