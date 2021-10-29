using CommisionSystem.WebApplication.Data.Sepidar;
using CommisionSystem.WebApplication.Models;
using CommisionSystem.WebApplication.Services.Concretes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication
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

            services.AddTransient<Services.Interfaces.IUserService, UserService>();
            services.AddTransient<Services.Interfaces.IProductService, ProductService>();
            services.AddTransient<Services.Interfaces.IBrandService, BrandService>();

            #endregion



            services.AddAuthorization(options =>
            {
                options.AddPolicy("4", policy => policy.RequireClaim("4"));

                options.AddPolicy("ExpertDashboardPolicy", policy => policy.RequireClaim("ExpertDashboard"));
                options.AddPolicy("ReadProductsPolicy", policy => policy.RequireClaim("ReadProducts"));
            });

            services.AddDbContext<Data.CommisionContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


            services.AddDbContext<SepidarContext>(
                options => options.UseSqlServer("name=ConnectionStrings:SepidarConnection",
            sqlServerOptions => sqlServerOptions.CommandTimeout(600))
            );

            services.AddRazorPages()
                .AddViewOptions(options =>
                {
                    options.HtmlHelperOptions.ClientValidationEnabled = true;
                });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
           // services.AddMvcCore().AddNewtonsoftJson(x => x.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.All);
            // services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler= ReferenceHandler.Preserve);
            // services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.WriteIndented=true);

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
        }
    }
}
