using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpOverrides;
using AspCorePractie.ActionFilters;

namespace AspCorePractie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public  const string CookieScheme = "MyAuthentication";

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
      
            services.AddDbContext<Data.EmpContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EmpContext")));
           
            services.AddHttpClient();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddScoped<Services.Depend, Services.MyDependency>();
            services.AddControllers();
            services.AddScoped<Validationfilters>();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "First API",
                    Description = "A simple example for swagger api information",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Your Name XYZ",
                        Email = "xyz@gmail.com",
                        Url = new Uri("https://example.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under OpenApiLicense",
                        Url = new Uri("https://example.com/license"),
                    }
                });

            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication()
                .AddCookie(CookieScheme, options =>
                {
                    options.AccessDeniedPath = "/Index";
                    options.LoginPath = "/Index";
                });
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
   
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseStaticFiles();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
         
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
          
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMvc();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });


        }
    }
}
