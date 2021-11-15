
using AutoMapper;
using CommissionSystem.Data;
using CommissionSystem.Data.Sepidar;
using CommissionSystem.Services.Concretes;
using CommissionSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace CommissionSystem.WebApplication
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
            //Enable cookie authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddHttpContextAccessor();
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            #region Injection

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddScoped<Models.OpenQuote, Models.OpenQuote>();

            #endregion

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Dashboard", policy => policy.RequireClaim("Dashboard"));
                options.AddPolicy("ReadProducts", policy => policy.RequireClaim("ReadProducts"));
                // options.AddPolicy("ExpertDashboardPolicy", policy => policy.RequireClaim("ExpertDashboard"));
                // options.AddPolicy("ReadProductsPolicy", policy => policy.RequireClaim("ReadProducts"));
            });

            services.AddDbContext<CommisionContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


            services.AddDbContext<SepidarContext>(
                options => options.UseSqlServer("name=ConnectionStrings:SepidarConnection",
            sqlServerOptions => sqlServerOptions.CommandTimeout(1000))
            );

            services.AddRazorPages()
                .AddViewOptions(options =>
                {
                    options.HtmlHelperOptions.ClientValidationEnabled = true;
                });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            #region AutoMapper

            services.AddAutoMapper(Assembly.GetAssembly(typeof(Mappings)),Assembly.GetAssembly(typeof(Services.Mappings)));
            // services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();



            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("/brand/list");
            app.UseDefaultFiles(options);
        }
    }
}
